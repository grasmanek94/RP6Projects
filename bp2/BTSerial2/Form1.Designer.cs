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
            this.label1.Location = new System.Drawing.Point(12, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "MaxSpeed";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Fuel";
            // 
            // speedlb
            // 
            this.speedlb.AutoSize = true;
            this.speedlb.Location = new System.Drawing.Point(76, 38);
            this.speedlb.Name = "speedlb";
            this.speedlb.Size = new System.Drawing.Size(13, 13);
            this.speedlb.TabIndex = 8;
            this.speedlb.Text = "0";
            // 
            // fuellb
            // 
            this.fuellb.AutoSize = true;
            this.fuellb.Location = new System.Drawing.Point(76, 51);
            this.fuellb.Name = "fuellb";
            this.fuellb.Size = new System.Drawing.Size(13, 13);
            this.fuellb.TabIndex = 9;
            this.fuellb.Text = "0";
            // 
            // motorLeft
            // 
            this.motorLeft.LargeChange = 30;
            this.motorLeft.Location = new System.Drawing.Point(104, 67);
            this.motorLeft.Maximum = 255;
            this.motorLeft.Minimum = -255;
            this.motorLeft.Name = "motorLeft";
            this.motorLeft.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.motorLeft.Size = new System.Drawing.Size(45, 396);
            this.motorLeft.SmallChange = 15;
            this.motorLeft.TabIndex = 10;
            this.motorLeft.Scroll += new System.EventHandler(this.motorLeft_Scroll);
            // 
            // motorRight
            // 
            this.motorRight.LargeChange = 30;
            this.motorRight.Location = new System.Drawing.Point(277, 67);
            this.motorRight.Maximum = 255;
            this.motorRight.Minimum = -255;
            this.motorRight.Name = "motorRight";
            this.motorRight.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.motorRight.Size = new System.Drawing.Size(45, 396);
            this.motorRight.SmallChange = 15;
            this.motorRight.TabIndex = 11;
            this.motorRight.Scroll += new System.EventHandler(this.motorRight_Scroll);
            // 
            // stopbtn
            // 
            this.stopbtn.Location = new System.Drawing.Point(155, 254);
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
            this.label3.Location = new System.Drawing.Point(85, 259);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(13, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "L";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(309, 259);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(15, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "R";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(101, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Last alive";
            // 
            // lastAlive
            // 
            this.lastAlive.AutoSize = true;
            this.lastAlive.Location = new System.Drawing.Point(159, 38);
            this.lastAlive.Name = "lastAlive";
            this.lastAlive.Size = new System.Drawing.Size(13, 13);
            this.lastAlive.TabIndex = 16;
            this.lastAlive.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(101, 51);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "CRO";
            // 
            // crolbl
            // 
            this.crolbl.AutoSize = true;
            this.crolbl.Location = new System.Drawing.Point(159, 51);
            this.crolbl.Name = "crolbl";
            this.crolbl.Size = new System.Drawing.Size(13, 13);
            this.crolbl.TabIndex = 18;
            this.crolbl.Text = "0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 475);
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
    }
}

