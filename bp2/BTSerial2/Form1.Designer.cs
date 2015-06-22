namespace BTSerial2
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.speedlb = new System.Windows.Forms.Label();
            this.fuellb = new System.Windows.Forms.Label();
            this.motorLeft = new System.Windows.Forms.TrackBar();
            this.motorRight = new System.Windows.Forms.TrackBar();
            this.stopbtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lastAlive = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.crolbl = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cmdslbl = new System.Windows.Forms.Label();
            this.cmdflbl = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cmdulbl = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.cslbl = new System.Windows.Forms.Label();
            this.crlbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.motorLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.motorRight)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(277, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Connect";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(358, 14);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(89, 20);
            this.textBox2.TabIndex = 3;
            this.textBox2.Text = "38400 ";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(12, 12);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(86, 23);
            this.button3.TabIndex = 4;
            this.button3.Text = "Refresh";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(104, 14);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(167, 21);
            this.comboBox1.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "MaxSpeed";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Fuel";
            // 
            // speedlb
            // 
            this.speedlb.AutoSize = true;
            this.speedlb.Location = new System.Drawing.Point(76, 104);
            this.speedlb.Name = "speedlb";
            this.speedlb.Size = new System.Drawing.Size(13, 13);
            this.speedlb.TabIndex = 8;
            this.speedlb.Text = "0";
            // 
            // fuellb
            // 
            this.fuellb.AutoSize = true;
            this.fuellb.Location = new System.Drawing.Point(76, 117);
            this.fuellb.Name = "fuellb";
            this.fuellb.Size = new System.Drawing.Size(13, 13);
            this.fuellb.TabIndex = 9;
            this.fuellb.Text = "0";
            // 
            // motorLeft
            // 
            this.motorLeft.LargeChange = 30;
            this.motorLeft.Location = new System.Drawing.Point(229, 104);
            this.motorLeft.Maximum = 255;
            this.motorLeft.Minimum = -255;
            this.motorLeft.Name = "motorLeft";
            this.motorLeft.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.motorLeft.Size = new System.Drawing.Size(45, 359);
            this.motorLeft.SmallChange = 15;
            this.motorLeft.TabIndex = 10;
            this.motorLeft.Scroll += new System.EventHandler(this.motorLeft_Scroll);
            // 
            // motorRight
            // 
            this.motorRight.LargeChange = 30;
            this.motorRight.Location = new System.Drawing.Point(402, 104);
            this.motorRight.Maximum = 255;
            this.motorRight.Minimum = -255;
            this.motorRight.Name = "motorRight";
            this.motorRight.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.motorRight.Size = new System.Drawing.Size(45, 359);
            this.motorRight.SmallChange = 15;
            this.motorRight.TabIndex = 11;
            this.motorRight.Scroll += new System.EventHandler(this.motorRight_Scroll);
            // 
            // stopbtn
            // 
            this.stopbtn.Location = new System.Drawing.Point(280, 271);
            this.stopbtn.Name = "stopbtn";
            this.stopbtn.Size = new System.Drawing.Size(99, 23);
            this.stopbtn.TabIndex = 12;
            this.stopbtn.Text = "STOP";
            this.stopbtn.UseVisualStyleBackColor = true;
            this.stopbtn.Click += new System.EventHandler(this.stopbtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(210, 259);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(13, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "L";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(434, 259);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(15, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "R";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 130);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Last alive";
            // 
            // lastAlive
            // 
            this.lastAlive.AutoSize = true;
            this.lastAlive.Location = new System.Drawing.Point(76, 130);
            this.lastAlive.Name = "lastAlive";
            this.lastAlive.Size = new System.Drawing.Size(13, 13);
            this.lastAlive.TabIndex = 16;
            this.lastAlive.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 143);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "CORRUPT";
            // 
            // crolbl
            // 
            this.crolbl.AutoSize = true;
            this.crolbl.Location = new System.Drawing.Point(76, 143);
            this.crolbl.Name = "crolbl";
            this.crolbl.Size = new System.Drawing.Size(13, 13);
            this.crolbl.TabIndex = 18;
            this.crolbl.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 156);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "CMD S";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 169);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "CMD F";
            // 
            // cmdslbl
            // 
            this.cmdslbl.AutoSize = true;
            this.cmdslbl.Location = new System.Drawing.Point(76, 156);
            this.cmdslbl.Name = "cmdslbl";
            this.cmdslbl.Size = new System.Drawing.Size(13, 13);
            this.cmdslbl.TabIndex = 21;
            this.cmdslbl.Text = "0";
            // 
            // cmdflbl
            // 
            this.cmdflbl.AutoSize = true;
            this.cmdflbl.Location = new System.Drawing.Point(76, 169);
            this.cmdflbl.Name = "cmdflbl";
            this.cmdflbl.Size = new System.Drawing.Size(13, 13);
            this.cmdflbl.TabIndex = 22;
            this.cmdflbl.Text = "0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 182);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(42, 13);
            this.label9.TabIndex = 23;
            this.label9.Text = "CMD U";
            // 
            // cmdulbl
            // 
            this.cmdulbl.AutoSize = true;
            this.cmdulbl.Location = new System.Drawing.Point(76, 182);
            this.cmdulbl.Name = "cmdulbl";
            this.cmdulbl.Size = new System.Drawing.Size(13, 13);
            this.cmdulbl.TabIndex = 24;
            this.cmdulbl.Text = "0";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(9, 208);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(22, 13);
            this.label10.TabIndex = 26;
            this.label10.Text = "CR";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(9, 195);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(21, 13);
            this.label11.TabIndex = 25;
            this.label11.Text = "CS";
            // 
            // cslbl
            // 
            this.cslbl.AutoSize = true;
            this.cslbl.Location = new System.Drawing.Point(76, 195);
            this.cslbl.Name = "cslbl";
            this.cslbl.Size = new System.Drawing.Size(13, 13);
            this.cslbl.TabIndex = 27;
            this.cslbl.Text = "0";
            // 
            // crlbl
            // 
            this.crlbl.AutoSize = true;
            this.crlbl.Location = new System.Drawing.Point(76, 208);
            this.crlbl.Name = "crlbl";
            this.crlbl.Size = new System.Drawing.Size(13, 13);
            this.crlbl.TabIndex = 28;
            this.crlbl.Text = "0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 475);
            this.Controls.Add(this.crlbl);
            this.Controls.Add(this.cslbl);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.cmdulbl);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cmdflbl);
            this.Controls.Add(this.cmdslbl);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.crolbl);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lastAlive);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.stopbtn);
            this.Controls.Add(this.motorRight);
            this.Controls.Add(this.motorLeft);
            this.Controls.Add(this.fuellb);
            this.Controls.Add(this.speedlb);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.motorLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.motorRight)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label speedlb;
        private System.Windows.Forms.Label fuellb;
        private System.Windows.Forms.TrackBar motorLeft;
        private System.Windows.Forms.TrackBar motorRight;
        private System.Windows.Forms.Button stopbtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lastAlive;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label crolbl;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label cmdslbl;
        private System.Windows.Forms.Label cmdflbl;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label cmdulbl;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label cslbl;
        private System.Windows.Forms.Label crlbl;
    }
}

