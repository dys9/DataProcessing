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
        private int L, R, U, D, Xmax, Ymax = 0;
        private double Xstep, Ystep, Flux = 0.0;
        private double[,] arr;


        public UserControl1()
        {
            InitializeComponent();
        }

        private double Bi_Interpolation(double X, double Y)
        {
            double result = 0;
            // 보간이 필요없을 경우
            if (((X - D) % Xstep) == 0 && ((Y - L) % Ystep) == 0)
            {
                int xi = (int)((X - D) / Xstep);
                int yi = (int)((Y - L) / Ystep);

                result = (arr[xi, yi]);
            }
            // X 보간
            else if (((X - D) % Xstep) != 0 && ((Y - L) % Ystep) == 0)
            {
                int xmi = (int)((X - D) / Xstep);
                int ymi = (int)((Y - L) / Ystep);
                int xMi = xmi + 1;

                double t = (X % Xstep) / Xstep;

                if (xmi > 0 && xmi < Xmax &&
                    xMi > 0 && xMi < Xmax &&
                    ymi > 0 && ymi < Ymax)
                {
                    double valm = arr[xmi, ymi];
                    double valM = arr[xMi, ymi];

                    result = valm * (1 - t) + t * valM;
                }
            }
            // Y 보간
            else if (((X - D) % Xstep) == 0 && ((Y - L) % Ystep) != 0)
            {
                int xmi = (int)((X - D) / Xstep);
                int ymi = (int)((Y - L) / Ystep);
                int yMi = xmi + 1;

                double t = (Y % Xstep) / Ystep;

                if (xmi > 0 && xmi < Xmax &&
                    ymi > 0 && ymi < Ymax &&
                    yMi > 0 && yMi < Ymax
                    )
                {
                    double valm = arr[xmi, ymi];
                    double valM = arr[xmi, yMi];

                    result = valm * (1 - t) + t * valM;
                }
            }
            // 이중 보간
            else
            {
                int xmi = (int)((X - D) / Xstep);
                int ymi = (int)((Y - L) / Ystep);

                int xMi = xmi + 1;
                int yMi = ymi + 1;

                if (xmi > 0 && xmi < Xmax &&
                     xMi > 0 && xMi < Xmax &&
                     ymi > 0 && ymi < Ymax &&
                     yMi > 0 && yMi < Ymax)
                {
                    double valm = arr[xmi, ymi];
                    double valM = arr[xMi, yMi];

                    result = 0;
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
                                U = Convert.ToInt32(header[0]);
                                D = Convert.ToInt32(header[1]);
                                Xstep = Convert.ToDouble(header[2]);
                                R = Convert.ToInt32(header[3]);
                                L = Convert.ToInt32(header[4]);
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

                            arr = new double[Xmax, Ymax];
                        }

                        // Insert Data to Array
                        while ((line = SR.ReadLine()) != null)
                        {
                            if (((Xidx < Xmax) && (Yidx < Ymax)))
                            {
                                textBox1.Text += String.Format("{0,5}", Convert.ToDouble(line));
                                arr[Xidx, Yidx] = Convert.ToDouble(line);
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
                        if (line == null)
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

        private void tbY_TextChanged(object sender, EventArgs e)
        {
            double X, Y;
            if (arr != null)
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
            if (arr != null)
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
    }
}
