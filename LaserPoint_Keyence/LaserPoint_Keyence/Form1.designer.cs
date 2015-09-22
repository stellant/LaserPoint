namespace LaserPoint_Keyence
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox_Ports = new System.Windows.Forms.ComboBox();
            this.button_FileChoose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_FileName = new System.Windows.Forms.TextBox();
            this.textBox_BaudRate = new System.Windows.Forms.TextBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.checkBox_Monitor = new System.Windows.Forms.CheckBox();
            this.radioButton_Combined = new System.Windows.Forms.RadioButton();
            this.radioButton_Individual = new System.Windows.Forms.RadioButton();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.textBox_status = new System.Windows.Forms.TextBox();
            this.button_connect = new System.Windows.Forms.Button();
            this.button_close = new System.Windows.Forms.Button();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox8);
            this.groupBox1.Location = new System.Drawing.Point(9, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(628, 110);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.comboBox_Ports);
            this.groupBox3.Controls.Add(this.button_FileChoose);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.textBox_FileName);
            this.groupBox3.Controls.Add(this.textBox_BaudRate);
            this.groupBox3.Location = new System.Drawing.Point(6, 8);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(462, 95);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Serial Details";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Port";
            // 
            // comboBox_Ports
            // 
            this.comboBox_Ports.FormattingEnabled = true;
            this.comboBox_Ports.Location = new System.Drawing.Point(108, 25);
            this.comboBox_Ports.Name = "comboBox_Ports";
            this.comboBox_Ports.Size = new System.Drawing.Size(84, 21);
            this.comboBox_Ports.TabIndex = 13;
            // 
            // button_FileChoose
            // 
            this.button_FileChoose.Location = new System.Drawing.Point(354, 53);
            this.button_FileChoose.Name = "button_FileChoose";
            this.button_FileChoose.Size = new System.Drawing.Size(77, 23);
            this.button_FileChoose.TabIndex = 12;
            this.button_FileChoose.Text = "Browse...";
            this.button_FileChoose.UseVisualStyleBackColor = true;
            this.button_FileChoose.Click += new System.EventHandler(this.button_FileChoose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(207, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Baud Rate";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "File Path";
            // 
            // textBox_FileName
            // 
            this.textBox_FileName.Enabled = false;
            this.textBox_FileName.Location = new System.Drawing.Point(108, 55);
            this.textBox_FileName.Multiline = true;
            this.textBox_FileName.Name = "textBox_FileName";
            this.textBox_FileName.Size = new System.Drawing.Size(241, 20);
            this.textBox_FileName.TabIndex = 0;
            // 
            // textBox_BaudRate
            // 
            this.textBox_BaudRate.Location = new System.Drawing.Point(271, 27);
            this.textBox_BaudRate.Multiline = true;
            this.textBox_BaudRate.Name = "textBox_BaudRate";
            this.textBox_BaudRate.Size = new System.Drawing.Size(76, 20);
            this.textBox_BaudRate.TabIndex = 0;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.checkBox_Monitor);
            this.groupBox8.Controls.Add(this.radioButton_Combined);
            this.groupBox8.Controls.Add(this.radioButton_Individual);
            this.groupBox8.Location = new System.Drawing.Point(474, 8);
            this.groupBox8.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox8.Size = new System.Drawing.Size(148, 95);
            this.groupBox8.TabIndex = 0;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Storing Type";
            // 
            // checkBox_Monitor
            // 
            this.checkBox_Monitor.AutoSize = true;
            this.checkBox_Monitor.Location = new System.Drawing.Point(40, 68);
            this.checkBox_Monitor.Name = "checkBox_Monitor";
            this.checkBox_Monitor.Size = new System.Drawing.Size(61, 17);
            this.checkBox_Monitor.TabIndex = 2;
            this.checkBox_Monitor.Text = "Monitor";
            this.checkBox_Monitor.UseVisualStyleBackColor = true;
            // 
            // radioButton_Combined
            // 
            this.radioButton_Combined.AutoSize = true;
            this.radioButton_Combined.Location = new System.Drawing.Point(20, 46);
            this.radioButton_Combined.Name = "radioButton_Combined";
            this.radioButton_Combined.Size = new System.Drawing.Size(104, 17);
            this.radioButton_Combined.TabIndex = 1;
            this.radioButton_Combined.TabStop = true;
            this.radioButton_Combined.Text = "Append to Same";
            this.radioButton_Combined.UseVisualStyleBackColor = true;
            this.radioButton_Combined.CheckedChanged += new System.EventHandler(this.radioButton_Combined_CheckedChanged);
            // 
            // radioButton_Individual
            // 
            this.radioButton_Individual.AutoSize = true;
            this.radioButton_Individual.Location = new System.Drawing.Point(19, 21);
            this.radioButton_Individual.Name = "radioButton_Individual";
            this.radioButton_Individual.Size = new System.Drawing.Size(70, 17);
            this.radioButton_Individual.TabIndex = 0;
            this.radioButton_Individual.TabStop = true;
            this.radioButton_Individual.Text = "Individual";
            this.radioButton_Individual.UseVisualStyleBackColor = true;
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.textBox_status);
            this.groupBox10.Location = new System.Drawing.Point(9, 119);
            this.groupBox10.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox10.Size = new System.Drawing.Size(481, 131);
            this.groupBox10.TabIndex = 18;
            this.groupBox10.TabStop = false;
            // 
            // textBox_status
            // 
            this.textBox_status.Location = new System.Drawing.Point(9, 20);
            this.textBox_status.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox_status.Multiline = true;
            this.textBox_status.Name = "textBox_status";
            this.textBox_status.Size = new System.Drawing.Size(464, 99);
            this.textBox_status.TabIndex = 0;
            // 
            // button_connect
            // 
            this.button_connect.Location = new System.Drawing.Point(12, 17);
            this.button_connect.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_connect.Name = "button_connect";
            this.button_connect.Size = new System.Drawing.Size(112, 49);
            this.button_connect.TabIndex = 13;
            this.button_connect.Text = "Connect";
            this.button_connect.UseVisualStyleBackColor = true;
            this.button_connect.Click += new System.EventHandler(this.button_connect_Click);
            // 
            // button_close
            // 
            this.button_close.Location = new System.Drawing.Point(12, 71);
            this.button_close.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_close.Name = "button_close";
            this.button_close.Size = new System.Drawing.Size(112, 49);
            this.button_close.TabIndex = 14;
            this.button_close.Text = "Disconnect";
            this.button_close.UseVisualStyleBackColor = true;
            this.button_close.Click += new System.EventHandler(this.button_close_Click);
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.button_connect);
            this.groupBox9.Controls.Add(this.button_close);
            this.groupBox9.Location = new System.Drawing.Point(497, 119);
            this.groupBox9.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox9.Size = new System.Drawing.Size(135, 131);
            this.groupBox9.TabIndex = 19;
            this.groupBox9.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(647, 255);
            this.Controls.Add(this.groupBox9);
            this.Controls.Add(this.groupBox10);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_BaudRate;
        private System.Windows.Forms.Button button_FileChoose;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_FileName;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.CheckBox checkBox_Monitor;
        private System.Windows.Forms.RadioButton radioButton_Combined;
        private System.Windows.Forms.RadioButton radioButton_Individual;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.TextBox textBox_status;
        private System.Windows.Forms.Button button_connect;
        private System.Windows.Forms.Button button_close;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox_Ports;
        private System.Windows.Forms.Timer timer1;

    }
}

