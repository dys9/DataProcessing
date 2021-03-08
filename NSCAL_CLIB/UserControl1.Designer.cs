namespace NSCAL_CLIB
{
    partial class UserControl1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbPath = new System.Windows.Forms.TextBox();
            this.btnOpen = new System.Windows.Forms.Button();
            this.OPD = new System.Windows.Forms.OpenFileDialog();
            this.tbX = new System.Windows.Forms.TextBox();
            this.tbY = new System.Windows.Forms.TextBox();
            this.tbValue = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tbL = new System.Windows.Forms.TextBox();
            this.tbR = new System.Windows.Forms.TextBox();
            this.tbD = new System.Windows.Forms.TextBox();
            this.tbU = new System.Windows.Forms.TextBox();
            this.tbLRstep = new System.Windows.Forms.TextBox();
            this.tbDUstep = new System.Windows.Forms.TextBox();
            this.btnAreaModi = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbPath
            // 
            this.tbPath.Location = new System.Drawing.Point(4, 4);
            this.tbPath.Name = "tbPath";
            this.tbPath.ReadOnly = true;
            this.tbPath.Size = new System.Drawing.Size(314, 24);
            this.tbPath.TabIndex = 0;
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(324, 3);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(83, 24);
            this.btnOpen.TabIndex = 1;
            this.btnOpen.Text = "Open..";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // OPD
            // 
            this.OPD.FileName = "openFileDialog1";
            // 
            // tbX
            // 
            this.tbX.Location = new System.Drawing.Point(4, 34);
            this.tbX.Name = "tbX";
            this.tbX.Size = new System.Drawing.Size(100, 24);
            this.tbX.TabIndex = 2;
            this.tbX.TextChanged += new System.EventHandler(this.tbX_TextChanged);
            // 
            // tbY
            // 
            this.tbY.Location = new System.Drawing.Point(110, 34);
            this.tbY.Name = "tbY";
            this.tbY.Size = new System.Drawing.Size(100, 24);
            this.tbY.TabIndex = 3;
            this.tbY.TextChanged += new System.EventHandler(this.tbY_TextChanged);
            // 
            // tbValue
            // 
            this.tbValue.Location = new System.Drawing.Point(216, 34);
            this.tbValue.Name = "tbValue";
            this.tbValue.ReadOnly = true;
            this.tbValue.Size = new System.Drawing.Size(100, 24);
            this.tbValue.TabIndex = 4;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(4, 95);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(793, 355);
            this.textBox1.TabIndex = 4;
            // 
            // tbL
            // 
            this.tbL.Location = new System.Drawing.Point(4, 65);
            this.tbL.Name = "tbL";
            this.tbL.Size = new System.Drawing.Size(100, 24);
            this.tbL.TabIndex = 5;
            // 
            // tbR
            // 
            this.tbR.Location = new System.Drawing.Point(110, 64);
            this.tbR.Name = "tbR";
            this.tbR.Size = new System.Drawing.Size(100, 24);
            this.tbR.TabIndex = 6;
            // 
            // tbD
            // 
            this.tbD.Location = new System.Drawing.Point(218, 64);
            this.tbD.Name = "tbD";
            this.tbD.Size = new System.Drawing.Size(100, 24);
            this.tbD.TabIndex = 7;
            // 
            // tbU
            // 
            this.tbU.Location = new System.Drawing.Point(324, 64);
            this.tbU.Name = "tbU";
            this.tbU.Size = new System.Drawing.Size(100, 24);
            this.tbU.TabIndex = 8;
            // 
            // tbLRstep
            // 
            this.tbLRstep.Location = new System.Drawing.Point(430, 64);
            this.tbLRstep.Name = "tbLRstep";
            this.tbLRstep.Size = new System.Drawing.Size(100, 24);
            this.tbLRstep.TabIndex = 9;
            // 
            // tbDUstep
            // 
            this.tbDUstep.Location = new System.Drawing.Point(536, 64);
            this.tbDUstep.Name = "tbDUstep";
            this.tbDUstep.Size = new System.Drawing.Size(100, 24);
            this.tbDUstep.TabIndex = 10;
            // 
            // btnAreaModi
            // 
            this.btnAreaModi.Location = new System.Drawing.Point(642, 63);
            this.btnAreaModi.Name = "btnAreaModi";
            this.btnAreaModi.Size = new System.Drawing.Size(94, 23);
            this.btnAreaModi.TabIndex = 11;
            this.btnAreaModi.Text = "Area Modi";
            this.btnAreaModi.UseVisualStyleBackColor = true;
            this.btnAreaModi.Click += new System.EventHandler(this.btnAreaModi_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(322, 32);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(83, 24);
            this.btnClear.TabIndex = 1;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // UserControl1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnAreaModi);
            this.Controls.Add(this.tbDUstep);
            this.Controls.Add(this.tbLRstep);
            this.Controls.Add(this.tbU);
            this.Controls.Add(this.tbD);
            this.Controls.Add(this.tbR);
            this.Controls.Add(this.tbL);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.tbValue);
            this.Controls.Add(this.tbY);
            this.Controls.Add(this.tbX);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.tbPath);
            this.Name = "UserControl1";
            this.Size = new System.Drawing.Size(800, 450);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbPath;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.OpenFileDialog OPD;
        private System.Windows.Forms.TextBox tbX;
        private System.Windows.Forms.TextBox tbY;
        private System.Windows.Forms.TextBox tbValue;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox tbL;
        private System.Windows.Forms.TextBox tbR;
        private System.Windows.Forms.TextBox tbD;
        private System.Windows.Forms.TextBox tbU;
        private System.Windows.Forms.TextBox tbLRstep;
        private System.Windows.Forms.TextBox tbDUstep;
        private System.Windows.Forms.Button btnAreaModi;
        private System.Windows.Forms.Button btnClear;
    }
}
