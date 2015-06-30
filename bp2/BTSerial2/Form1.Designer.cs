namespace BTSerial2
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.lblLastSeen = new System.Windows.Forms.Label();
            this.lblLastSeenVal = new System.Windows.Forms.Label();
            this.tmrForm = new System.Windows.Forms.Timer(this.components);
            this.trbBar = new System.Windows.Forms.TrackBar();
            this.btnPumpOn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnPumpOff = new System.Windows.Forms.Button();
            this.lblBarName = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnValveClose = new System.Windows.Forms.Button();
            this.btnValveOpen = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lblPumpStatusText = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnBar6 = new System.Windows.Forms.Button();
            this.btnBar4 = new System.Windows.Forms.Button();
            this.btnBar0 = new System.Windows.Forms.Button();
            this.btnBar2 = new System.Windows.Forms.Button();
            this.Status = new System.Windows.Forms.GroupBox();
            this.lblOverride = new System.Windows.Forms.Label();
            this.lblOverrideText = new System.Windows.Forms.Label();
            this.lblValveStatus = new System.Windows.Forms.Label();
            this.lblValveStatusText = new System.Windows.Forms.Label();
            this.lblPumpStatus = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.trbBar)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.Status.SuspendLayout();
            this.groupBox5.SuspendLayout();
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
            // lblLastSeen
            // 
            this.lblLastSeen.AutoSize = true;
            this.lblLastSeen.Location = new System.Drawing.Point(6, 60);
            this.lblLastSeen.Name = "lblLastSeen";
            this.lblLastSeen.Size = new System.Drawing.Size(58, 13);
            this.lblLastSeen.TabIndex = 6;
            this.lblLastSeen.Text = "Last Seen:";
            // 
            // lblLastSeenVal
            // 
            this.lblLastSeenVal.AutoSize = true;
            this.lblLastSeenVal.Location = new System.Drawing.Point(82, 60);
            this.lblLastSeenVal.Name = "lblLastSeenVal";
            this.lblLastSeenVal.Size = new System.Drawing.Size(58, 13);
            this.lblLastSeenVal.TabIndex = 7;
            this.lblLastSeenVal.Text = "Last Seen:";
            // 
            // tmrForm
            // 
            this.tmrForm.Enabled = true;
            this.tmrForm.Tick += new System.EventHandler(this.tmrForm_Tick);
            // 
            // trbBar
            // 
            this.trbBar.Enabled = false;
            this.trbBar.Location = new System.Drawing.Point(101, 19);
            this.trbBar.Maximum = 6;
            this.trbBar.Name = "trbBar";
            this.trbBar.Size = new System.Drawing.Size(334, 45);
            this.trbBar.SmallChange = 2000;
            this.trbBar.TabIndex = 8;
            // 
            // btnPumpOn
            // 
            this.btnPumpOn.Location = new System.Drawing.Point(87, 19);
            this.btnPumpOn.Name = "btnPumpOn";
            this.btnPumpOn.Size = new System.Drawing.Size(75, 23);
            this.btnPumpOn.TabIndex = 9;
            this.btnPumpOn.Text = "On";
            this.btnPumpOn.UseVisualStyleBackColor = true;
            this.btnPumpOn.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(111, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(416, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "6";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(208, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(13, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "2";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(111, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "label4";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnPumpOff);
            this.groupBox1.Controls.Add(this.btnPumpOn);
            this.groupBox1.Location = new System.Drawing.Point(12, 146);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(168, 49);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Pump";
            // 
            // btnPumpOff
            // 
            this.btnPumpOff.Location = new System.Drawing.Point(6, 19);
            this.btnPumpOff.Name = "btnPumpOff";
            this.btnPumpOff.Size = new System.Drawing.Size(75, 23);
            this.btnPumpOff.TabIndex = 10;
            this.btnPumpOff.Text = "Off";
            this.btnPumpOff.UseVisualStyleBackColor = true;
            this.btnPumpOff.Click += new System.EventHandler(this.btnPumpOff_Click);
            // 
            // lblBarName
            // 
            this.lblBarName.AutoSize = true;
            this.lblBarName.Location = new System.Drawing.Point(19, 51);
            this.lblBarName.Name = "lblBarName";
            this.lblBarName.Size = new System.Drawing.Size(76, 13);
            this.lblBarName.TabIndex = 15;
            this.lblBarName.Text = "Pressure (Bar):";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Pressure (mBar):";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnValveClose);
            this.groupBox2.Controls.Add(this.btnValveOpen);
            this.groupBox2.Location = new System.Drawing.Point(12, 201);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(168, 49);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Valve";
            // 
            // btnValveClose
            // 
            this.btnValveClose.Location = new System.Drawing.Point(6, 19);
            this.btnValveClose.Name = "btnValveClose";
            this.btnValveClose.Size = new System.Drawing.Size(75, 23);
            this.btnValveClose.TabIndex = 10;
            this.btnValveClose.Text = "Close";
            this.btnValveClose.UseVisualStyleBackColor = true;
            this.btnValveClose.Click += new System.EventHandler(this.btnValveClose_Click);
            // 
            // btnValveOpen
            // 
            this.btnValveOpen.Location = new System.Drawing.Point(87, 19);
            this.btnValveOpen.Name = "btnValveOpen";
            this.btnValveOpen.Size = new System.Drawing.Size(75, 23);
            this.btnValveOpen.TabIndex = 9;
            this.btnValveOpen.Text = "Open";
            this.btnValveOpen.UseVisualStyleBackColor = true;
            this.btnValveOpen.Click += new System.EventHandler(this.btnValveOpen_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(147, 19);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(15, 14);
            this.checkBox1.TabIndex = 17;
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.checkBox1);
            this.groupBox3.Location = new System.Drawing.Point(12, 256);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(168, 49);
            this.groupBox3.TabIndex = 18;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Manual override";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 19);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Override:";
            // 
            // lblPumpStatusText
            // 
            this.lblPumpStatusText.AutoSize = true;
            this.lblPumpStatusText.Location = new System.Drawing.Point(6, 21);
            this.lblPumpStatusText.Name = "lblPumpStatusText";
            this.lblPumpStatusText.Size = new System.Drawing.Size(70, 13);
            this.lblPumpStatusText.TabIndex = 19;
            this.lblPumpStatusText.Text = "Pump Status:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnBar6);
            this.groupBox4.Controls.Add(this.btnBar4);
            this.groupBox4.Controls.Add(this.btnBar0);
            this.groupBox4.Controls.Add(this.btnBar2);
            this.groupBox4.Location = new System.Drawing.Point(12, 311);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(435, 49);
            this.groupBox4.TabIndex = 15;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Pump";
            // 
            // btnBar6
            // 
            this.btnBar6.Location = new System.Drawing.Point(354, 19);
            this.btnBar6.Name = "btnBar6";
            this.btnBar6.Size = new System.Drawing.Size(75, 23);
            this.btnBar6.TabIndex = 12;
            this.btnBar6.Text = "6 (Bar)";
            this.btnBar6.UseVisualStyleBackColor = true;
            this.btnBar6.Click += new System.EventHandler(this.btnBar6_Click);
            // 
            // btnBar4
            // 
            this.btnBar4.Location = new System.Drawing.Point(248, 19);
            this.btnBar4.Name = "btnBar4";
            this.btnBar4.Size = new System.Drawing.Size(75, 23);
            this.btnBar4.TabIndex = 11;
            this.btnBar4.Text = "4 (Bar)";
            this.btnBar4.UseVisualStyleBackColor = true;
            this.btnBar4.Click += new System.EventHandler(this.btnBar4_Click);
            // 
            // btnBar0
            // 
            this.btnBar0.Location = new System.Drawing.Point(6, 19);
            this.btnBar0.Name = "btnBar0";
            this.btnBar0.Size = new System.Drawing.Size(75, 23);
            this.btnBar0.TabIndex = 10;
            this.btnBar0.Text = "0 (Bar)";
            this.btnBar0.UseVisualStyleBackColor = true;
            this.btnBar0.Click += new System.EventHandler(this.btnBar0_Click);
            // 
            // btnBar2
            // 
            this.btnBar2.Location = new System.Drawing.Point(114, 19);
            this.btnBar2.Name = "btnBar2";
            this.btnBar2.Size = new System.Drawing.Size(75, 23);
            this.btnBar2.TabIndex = 9;
            this.btnBar2.Text = "2 (Bar)";
            this.btnBar2.UseVisualStyleBackColor = true;
            this.btnBar2.Click += new System.EventHandler(this.btnBar2_Click);
            // 
            // Status
            // 
            this.Status.Controls.Add(this.lblOverride);
            this.Status.Controls.Add(this.lblOverrideText);
            this.Status.Controls.Add(this.lblValveStatus);
            this.Status.Controls.Add(this.lblValveStatusText);
            this.Status.Controls.Add(this.lblPumpStatus);
            this.Status.Controls.Add(this.lblPumpStatusText);
            this.Status.Controls.Add(this.lblLastSeenVal);
            this.Status.Controls.Add(this.lblLastSeen);
            this.Status.Location = new System.Drawing.Point(188, 146);
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(259, 159);
            this.Status.TabIndex = 20;
            this.Status.TabStop = false;
            this.Status.Text = "Status";
            // 
            // lblOverride
            // 
            this.lblOverride.AutoSize = true;
            this.lblOverride.Location = new System.Drawing.Point(82, 47);
            this.lblOverride.Name = "lblOverride";
            this.lblOverride.Size = new System.Drawing.Size(27, 13);
            this.lblOverride.TabIndex = 24;
            this.lblOverride.Text = "OFF";
            // 
            // lblOverrideText
            // 
            this.lblOverrideText.AutoSize = true;
            this.lblOverrideText.Location = new System.Drawing.Point(6, 47);
            this.lblOverrideText.Name = "lblOverrideText";
            this.lblOverrideText.Size = new System.Drawing.Size(50, 13);
            this.lblOverrideText.TabIndex = 23;
            this.lblOverrideText.Text = "Override:";
            // 
            // lblValveStatus
            // 
            this.lblValveStatus.AutoSize = true;
            this.lblValveStatus.Location = new System.Drawing.Point(82, 34);
            this.lblValveStatus.Name = "lblValveStatus";
            this.lblValveStatus.Size = new System.Drawing.Size(27, 13);
            this.lblValveStatus.TabIndex = 22;
            this.lblValveStatus.Text = "OFF";
            // 
            // lblValveStatusText
            // 
            this.lblValveStatusText.AutoSize = true;
            this.lblValveStatusText.Location = new System.Drawing.Point(6, 34);
            this.lblValveStatusText.Name = "lblValveStatusText";
            this.lblValveStatusText.Size = new System.Drawing.Size(70, 13);
            this.lblValveStatusText.TabIndex = 21;
            this.lblValveStatusText.Text = "Valve Status:";
            // 
            // lblPumpStatus
            // 
            this.lblPumpStatus.AutoSize = true;
            this.lblPumpStatus.Location = new System.Drawing.Point(82, 21);
            this.lblPumpStatus.Name = "lblPumpStatus";
            this.lblPumpStatus.Size = new System.Drawing.Size(27, 13);
            this.lblPumpStatus.TabIndex = 20;
            this.lblPumpStatus.Text = "OFF";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(310, 51);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(13, 13);
            this.label6.TabIndex = 21;
            this.label6.Text = "4";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label3);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Controls.Add(this.label1);
            this.groupBox5.Controls.Add(this.lblBarName);
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Controls.Add(this.trbBar);
            this.groupBox5.Location = new System.Drawing.Point(12, 40);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(435, 100);
            this.groupBox5.TabIndex = 22;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "groupBox5";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 365);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.Status);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "MainForm";
            this.Text = "Yop Spanjers - LPA";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.trbBar)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.Status.ResumeLayout(false);
            this.Status.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label lblLastSeen;
        private System.Windows.Forms.Label lblLastSeenVal;
        private System.Windows.Forms.Timer tmrForm;
        private System.Windows.Forms.TrackBar trbBar;
        private System.Windows.Forms.Button btnPumpOn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnPumpOff;
        private System.Windows.Forms.Label lblBarName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnValveClose;
        private System.Windows.Forms.Button btnValveOpen;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblPumpStatusText;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnBar0;
        private System.Windows.Forms.Button btnBar2;
        private System.Windows.Forms.GroupBox Status;
        private System.Windows.Forms.Label lblValveStatus;
        private System.Windows.Forms.Label lblValveStatusText;
        private System.Windows.Forms.Label lblPumpStatus;
        private System.Windows.Forms.Button btnBar6;
        private System.Windows.Forms.Button btnBar4;
        private System.Windows.Forms.Label lblOverride;
        private System.Windows.Forms.Label lblOverrideText;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox5;
    }
}

