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
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.lblLastSeen = new System.Windows.Forms.Label();
            this.lblLastSeenVal = new System.Windows.Forms.Label();
            this.tmrForm = new System.Windows.Forms.Timer(this.components);
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
            this.lblLastSeen.Location = new System.Drawing.Point(9, 453);
            this.lblLastSeen.Name = "lblLastSeen";
            this.lblLastSeen.Size = new System.Drawing.Size(58, 13);
            this.lblLastSeen.TabIndex = 6;
            this.lblLastSeen.Text = "Last Seen:";
            // 
            // lblLastSeenVal
            // 
            this.lblLastSeenVal.AutoSize = true;
            this.lblLastSeenVal.Location = new System.Drawing.Point(73, 453);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 475);
            this.Controls.Add(this.lblLastSeenVal);
            this.Controls.Add(this.lblLastSeen);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Yop Spanjers - LPA";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
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
    }
}

