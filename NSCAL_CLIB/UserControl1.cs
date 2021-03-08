using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace NSCAL_CLIB
{
    public partial class UserControl1 : UserControl
    {
        private int Xmax, Ymax = 0;
        private double L, R, U, D, Xstep, Ystep, Flux = 0.0;
        private double[,] data;
        private double[,] AreaModi;

        public UserControl1()
        {
            InitializeComponent();
            tbD.Text = "-.5";
            tbL.Text = "-.5";
            tbU.Text = ".5";
            tbR.Text = ".5";

        }

        private double Bi_Interpolation(double X, double Y)
        {
            double result = 0;
            // 보간이 필요없을 경우
            if (((X - D) % Xstep) == 0 && ((Y - L) % Ystep) == 0)
            {
                int xi = (int)((X - D) / Xstep);
                int yi = (int)((Y - L) / Ystep);

                result = (data[xi, yi]);
            }
            // X 보간
            else if (((X - D) % Xstep) != 0 && ((Y - L) % Ystep) == 0)
            {
                int xmi = (int)((X - D) / Xstep);
                int ymi = (int)((Y - L) / Ystep);
                int xMi = xmi + 1;

                double t = Math.Abs((X % Xstep) / Xstep);

                if (xmi >= 0 && xmi < Xmax &&
                    ymi >= 0 && ymi < Ymax &&
                    xMi > 0 && xMi < Xmax
                    )
                {
                    double valm = data[xmi, ymi];
                    double valM = data[xMi, ymi];

                    result = valM * (1 - t) + t * valm;
                }
            }
            // Y 보간
            else if (((X - D) % Xstep) == 0 && ((Y - L) % Ystep) != 0)
            {
                int xmi = (int)((X - D) / Xstep);
                int ymi = (int)((Y - L) / Ystep);
                int yMi = ymi + 1;

                double t = Math.Abs((Y % Ystep) / Ystep);

                if (xmi >= 0 && xmi < Xmax &&
                    ymi >= 0 && ymi < Ymax &&
                    yMi > 0 && yMi < Ymax)
                {

                    double valm = data[xmi, ymi];
                    double valM = data[xmi, yMi];

                    result = valM * (1 - t) + t * valm;
                }
            }
            // 이중 보간
            else
            {
                int xmi = (int)((X - D) / Xstep);
                int ymi = (int)((Y - L) / Ystep);

                int xMi = xmi + 1;
                int yMi = ymi + 1;

                if (xmi >= 0 && xmi < Xmax &&
                     ymi >= 0 && ymi < Ymax &&
                     xMi > 0 && xMi < Xmax &&
                     yMi > 0 && yMi < Ymax)
                {
                    double valA = data[xmi, ymi];
                    double valB = data[xmi, yMi];
                    double valC = data[xMi, ymi];
                    double valD = data[xMi, yMi];

                    double d1 = ((Math.Abs(X) % Xstep) / Xstep);
                    double d2 = 1 - d1;
                    double d3 = ((Math.Abs(Y) % Ystep) / Ystep);
                    double d4 = 1 - d3;

                    double fI = (d1 * valB + d2 * valA) / (d1 + d2);
                    double fJ = (d1 * valD + d2 * valC) / (d1 + d2);

                    result = (d3 * fJ + d4 * fI) / (d3 + d4);
                }
            }
            return result;
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            tbPath.Clear();
            OPD.InitialDirectory = "C:\\Users\\dys9\\Desktop";

            if (OPD.ShowDialog() == DialogResult.OK)
            {
                tbPath.Text = OPD.FileName;
            }

            if (tbPath.Text != "")
            {
                try
                {
                    using (StreamReader SR = new StreamReader(tbPath.Text))
                    {
                        int Xidx = 0;
                        int Yidx = 0;
                        string line = "";

                        // Parse Header 
                        if ((line = SR.ReadLine()) != null)
                        {
                            string[] header = line.Split(new char[] { ' ', '\t' });
                            if (header.Length == 7)
                            {
                                D = Convert.ToDouble(header[0]);
                                U = Convert.ToDouble(header[1]);
                                Xstep = Convert.ToDouble(header[2]);
                                L = Convert.ToDouble(header[3]);
                                R = Convert.ToDouble(header[4]);
                                Ystep = Convert.ToDouble(header[5]);
                                Flux = Convert.ToDouble(header[6]);
                            }
                            else
                            {
                                MessageBox.Show("Input Header Error!");
                            }
                            Xmax = (int)((U - D) / Xstep) + 1;
                            Ymax = (int)((R - L) / Ystep) + 1;

                            textBox1.Text += String.Format("[({0}, {1})], " +
                                "[X : ({3} ~ {2}) , {4}], " +
                                "[Y : ({6} ~ {5}) , {7}], " +
                                "[Flux : {8}]\r\n\r\n",
                                Xmax, Ymax, U, D, Xstep, R, L, Ystep, Flux);

                            data = new double[Xmax, Ymax];
                        }

                        // Insert Data to dataay
                        int cnt = 0;
                        while ((line = SR.ReadLine()) != null)
                        {
                            if (((Xidx < Xmax) && (Yidx < Ymax)))
                            {
                                textBox1.Text += String.Format("{0,5}", Convert.ToDouble(line));
                                data[Xidx, Yidx] = Convert.ToDouble(line);
                                cnt++;
                            }
                            else
                            {
                                break;
                            }

                            Yidx++;

                            if (Yidx == Ymax)
                            {
                                Xidx++;
                                Yidx = 0;
                                textBox1.Text += "\r\n";
                            }
                        }

                        // Throw Exception, If header's not match.
                        if (cnt != Xmax * Ymax)
                        {
                            throw new Exception();
                        }
                        SR.Close();
                    }
                } // Exceptions
                catch (IOException)
                {
                    MessageBox.Show("IOException");
                }
                catch (IndexOutOfRangeException)
                {
                    MessageBox.Show("IndexOutOfRangeException");
                }
                catch (Exception)
                {
                    MessageBox.Show("InputDataIndexException");
                }
            }
        }

        private void btnAreaModi_Click(object sender, EventArgs e)
        {
            if (data != null)
            {
                double Ln, Rn, Dn, Un, LRstep, DUstep;
                if ( double.TryParse(tbL.Text, out Ln) &&
                     double.TryParse(tbR.Text, out Rn) &&
                     double.TryParse(tbD.Text, out Dn) &&
                     double.TryParse(tbU.Text, out Un) &&
                     double.TryParse(tbLRstep.Text, out LRstep) &&
                     double.TryParse(tbDUstep.Text, out DUstep))
                {
                    if (Ln < Rn && Dn < Un && LRstep > 0 && DUstep > 0)
                    {
                        int Xmaxn = (int)((Un - Dn) / DUstep) + 1;
                        int Ymaxn = (int)((Rn - Ln) / LRstep) + 1;

                        textBox1.Text += string.Format("[{0}, {1}], [{2}, {3}, {4}][{5}, {6}, {7}]\r\n", Xmaxn, Ymaxn, Ln, Rn, LRstep, Dn, Un, DUstep);

                        AreaModi = new double[Xmaxn, Ymaxn];

                        for (double i = Dn; i <= Un; i += DUstep)
                        {
                            string temp = "";
                            for (double j = Ln; j <= Rn; j += LRstep)
                            {
                                int x = Convert.ToInt32((-Dn + i) / DUstep);
                                int y = Convert.ToInt32((-Ln + j) / LRstep);

                                AreaModi[x, y] = Bi_Interpolation(i, j);
                                temp += AreaModi[x, y].ToString("F") + "  ";
                            }
                            textBox1.Text += temp + "\r\n";
                        }

                        textBox1.Text += "##############################################################\r\n";
                        for (double i = Dn; i <= Un; i += DUstep)
                        {
                            string temp = "";
                            for (double j = Ln; j <= Rn; j += LRstep)
                            {
                                int x = Convert.ToInt32((-Dn + i) / DUstep);
                                int y = Convert.ToInt32((-Ln + j) / LRstep);

                                temp += string.Format("[{0}, {1}] ", x, y);
                            }
                            textBox1.Text += temp + "\r\n";
                        }

                        textBox1.Text += "##############################################################\r\n";

                        for (int i = 0; i < AreaModi.GetLength(0); i++)
                        {
                            for (int j = 0; j < AreaModi.GetLength(1); j++)
                            {
                                textBox1.Text += AreaModi[i, j].ToString("F") + "  ";
                            }
                            textBox1.Text += "\r\n";
                        }
                    }
                }
            }
        }

        private void tbY_TextChanged(object sender, EventArgs e)
        {
            double X, Y;
            if (data != null)
            {
                if (double.TryParse(tbY.Text, out Y) && double.TryParse(tbX.Text, out X))
                {
                    if ((X <= U && X >= D) && (Y <= R && Y >= L))
                    {
                        tbValue.Text = Bi_Interpolation(X, Y).ToString();
                    }
                }
            }
        }

        private void tbX_TextChanged(object sender, EventArgs e)
        {
            double X, Y;
            if (data != null)
            {
                if (double.TryParse(tbY.Text, out Y) && double.TryParse(tbX.Text, out X))
                {
                    if ((X <= U && X >= D) && (Y <= R && Y >= L))
                    {
                        tbValue.Text = Bi_Interpolation(X, Y).ToString();
                    }
                }
            }
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }


    }
}
