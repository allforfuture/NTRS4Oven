namespace NTRSbyDB
{
    partial class Port
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
            this.btnSave = new System.Windows.Forms.Button();
            this.GrpPort1 = new System.Windows.Forms.GroupBox();
            this.CmbStopBits1 = new System.Windows.Forms.ComboBox();
            this.CmbDataBits1 = new System.Windows.Forms.ComboBox();
            this.CmbParity1 = new System.Windows.Forms.ComboBox();
            this.CmbBaudRate1 = new System.Windows.Forms.ComboBox();
            this.CmbPortName1 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.GrpPort2 = new System.Windows.Forms.GroupBox();
            this.CmbStopBits2 = new System.Windows.Forms.ComboBox();
            this.CmbDataBits2 = new System.Windows.Forms.ComboBox();
            this.CmbParity2 = new System.Windows.Forms.ComboBox();
            this.CmbBaudRate2 = new System.Windows.Forms.ComboBox();
            this.CmbPortName2 = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.TxtIdentifier = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.生产模式ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.单串口ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.旧机器API2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.双串口ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.无串口ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.GrpPort1.SuspendLayout();
            this.GrpPort2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(317, 104);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 70);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "保存设置";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // GrpPort1
            // 
            this.GrpPort1.Controls.Add(this.CmbStopBits1);
            this.GrpPort1.Controls.Add(this.CmbDataBits1);
            this.GrpPort1.Controls.Add(this.CmbParity1);
            this.GrpPort1.Controls.Add(this.CmbBaudRate1);
            this.GrpPort1.Controls.Add(this.CmbPortName1);
            this.GrpPort1.Controls.Add(this.label5);
            this.GrpPort1.Controls.Add(this.label4);
            this.GrpPort1.Controls.Add(this.label3);
            this.GrpPort1.Controls.Add(this.label2);
            this.GrpPort1.Controls.Add(this.label1);
            this.GrpPort1.Enabled = false;
            this.GrpPort1.Location = new System.Drawing.Point(12, 36);
            this.GrpPort1.Name = "GrpPort1";
            this.GrpPort1.Size = new System.Drawing.Size(288, 185);
            this.GrpPort1.TabIndex = 2;
            this.GrpPort1.TabStop = false;
            this.GrpPort1.Text = "串口1";
            // 
            // CmbStopBits1
            // 
            this.CmbStopBits1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbStopBits1.FormattingEnabled = true;
            this.CmbStopBits1.Items.AddRange(new object[] {
            "1",
            "1.5",
            "2"});
            this.CmbStopBits1.Location = new System.Drawing.Point(140, 147);
            this.CmbStopBits1.Name = "CmbStopBits1";
            this.CmbStopBits1.Size = new System.Drawing.Size(121, 20);
            this.CmbStopBits1.TabIndex = 9;
            // 
            // CmbDataBits1
            // 
            this.CmbDataBits1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbDataBits1.FormattingEnabled = true;
            this.CmbDataBits1.Items.AddRange(new object[] {
            "5",
            "6",
            "7",
            "8"});
            this.CmbDataBits1.Location = new System.Drawing.Point(140, 112);
            this.CmbDataBits1.Name = "CmbDataBits1";
            this.CmbDataBits1.Size = new System.Drawing.Size(121, 20);
            this.CmbDataBits1.TabIndex = 9;
            // 
            // CmbParity1
            // 
            this.CmbParity1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbParity1.FormattingEnabled = true;
            this.CmbParity1.Items.AddRange(new object[] {
            "偶",
            "奇",
            "无",
            "标记",
            "空格"});
            this.CmbParity1.Location = new System.Drawing.Point(140, 86);
            this.CmbParity1.Name = "CmbParity1";
            this.CmbParity1.Size = new System.Drawing.Size(121, 20);
            this.CmbParity1.TabIndex = 9;
            // 
            // CmbBaudRate1
            // 
            this.CmbBaudRate1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbBaudRate1.FormattingEnabled = true;
            this.CmbBaudRate1.Items.AddRange(new object[] {
            "9600",
            "14400",
            "19200",
            "38400",
            "57600",
            "115200",
            "128000"});
            this.CmbBaudRate1.Location = new System.Drawing.Point(140, 60);
            this.CmbBaudRate1.Name = "CmbBaudRate1";
            this.CmbBaudRate1.Size = new System.Drawing.Size(121, 20);
            this.CmbBaudRate1.TabIndex = 8;
            // 
            // CmbPortName1
            // 
            this.CmbPortName1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbPortName1.FormattingEnabled = true;
            this.CmbPortName1.Location = new System.Drawing.Point(140, 34);
            this.CmbPortName1.Name = "CmbPortName1";
            this.CmbPortName1.Size = new System.Drawing.Size(121, 20);
            this.CmbPortName1.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 150);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "StopBits停止位：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "DataBits数据位：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "Parity奇偶校验位：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "BaudRate波特率：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "PortName端口名：";
            // 
            // GrpPort2
            // 
            this.GrpPort2.Controls.Add(this.CmbStopBits2);
            this.GrpPort2.Controls.Add(this.CmbDataBits2);
            this.GrpPort2.Controls.Add(this.CmbParity2);
            this.GrpPort2.Controls.Add(this.CmbBaudRate2);
            this.GrpPort2.Controls.Add(this.CmbPortName2);
            this.GrpPort2.Controls.Add(this.label6);
            this.GrpPort2.Controls.Add(this.label7);
            this.GrpPort2.Controls.Add(this.label8);
            this.GrpPort2.Controls.Add(this.label9);
            this.GrpPort2.Controls.Add(this.label10);
            this.GrpPort2.Enabled = false;
            this.GrpPort2.Location = new System.Drawing.Point(12, 254);
            this.GrpPort2.Name = "GrpPort2";
            this.GrpPort2.Size = new System.Drawing.Size(288, 185);
            this.GrpPort2.TabIndex = 10;
            this.GrpPort2.TabStop = false;
            this.GrpPort2.Text = "串口2";
            // 
            // CmbStopBits2
            // 
            this.CmbStopBits2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbStopBits2.FormattingEnabled = true;
            this.CmbStopBits2.Items.AddRange(new object[] {
            "1",
            "1.5",
            "2"});
            this.CmbStopBits2.Location = new System.Drawing.Point(140, 147);
            this.CmbStopBits2.Name = "CmbStopBits2";
            this.CmbStopBits2.Size = new System.Drawing.Size(121, 20);
            this.CmbStopBits2.TabIndex = 9;
            // 
            // CmbDataBits2
            // 
            this.CmbDataBits2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbDataBits2.FormattingEnabled = true;
            this.CmbDataBits2.Items.AddRange(new object[] {
            "5",
            "6",
            "7",
            "8"});
            this.CmbDataBits2.Location = new System.Drawing.Point(140, 112);
            this.CmbDataBits2.Name = "CmbDataBits2";
            this.CmbDataBits2.Size = new System.Drawing.Size(121, 20);
            this.CmbDataBits2.TabIndex = 9;
            // 
            // CmbParity2
            // 
            this.CmbParity2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbParity2.FormattingEnabled = true;
            this.CmbParity2.Items.AddRange(new object[] {
            "偶",
            "奇",
            "无",
            "标记",
            "空格"});
            this.CmbParity2.Location = new System.Drawing.Point(140, 86);
            this.CmbParity2.Name = "CmbParity2";
            this.CmbParity2.Size = new System.Drawing.Size(121, 20);
            this.CmbParity2.TabIndex = 9;
            // 
            // CmbBaudRate2
            // 
            this.CmbBaudRate2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbBaudRate2.FormattingEnabled = true;
            this.CmbBaudRate2.Items.AddRange(new object[] {
            "9600",
            "14400",
            "19200",
            "38400",
            "57600",
            "115200",
            "128000"});
            this.CmbBaudRate2.Location = new System.Drawing.Point(140, 60);
            this.CmbBaudRate2.Name = "CmbBaudRate2";
            this.CmbBaudRate2.Size = new System.Drawing.Size(121, 20);
            this.CmbBaudRate2.TabIndex = 8;
            // 
            // CmbPortName2
            // 
            this.CmbPortName2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbPortName2.FormattingEnabled = true;
            this.CmbPortName2.Location = new System.Drawing.Point(140, 34);
            this.CmbPortName2.Name = "CmbPortName2";
            this.CmbPortName2.Size = new System.Drawing.Size(121, 20);
            this.CmbPortName2.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(24, 150);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 12);
            this.label6.TabIndex = 4;
            this.label6.Text = "StopBits停止位：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(24, 120);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 12);
            this.label7.TabIndex = 3;
            this.label7.Text = "DataBits数据位：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(24, 94);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(113, 12);
            this.label8.TabIndex = 2;
            this.label8.Text = "Parity奇偶校验位：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(24, 68);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(101, 12);
            this.label9.TabIndex = 1;
            this.label9.Text = "BaudRate波特率：";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(24, 37);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(101, 12);
            this.label10.TabIndex = 0;
            this.label10.Text = "PortName端口名：";
            // 
            // TxtIdentifier
            // 
            this.TxtIdentifier.Location = new System.Drawing.Point(306, 51);
            this.TxtIdentifier.Multiline = true;
            this.TxtIdentifier.Name = "TxtIdentifier";
            this.TxtIdentifier.Size = new System.Drawing.Size(100, 42);
            this.TxtIdentifier.TabIndex = 32;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(315, 36);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 33;
            this.label11.Text = "分隔符：";
            // 
            // 生产模式ToolStripMenuItem
            // 
            this.生产模式ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.单串口ToolStripMenuItem,
            this.双串口ToolStripMenuItem,
            this.无串口ToolStripMenuItem});
            this.生产模式ToolStripMenuItem.Name = "生产模式ToolStripMenuItem";
            this.生产模式ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.生产模式ToolStripMenuItem.Text = "生产模式";
            // 
            // 单串口ToolStripMenuItem
            // 
            this.单串口ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.旧机器API2ToolStripMenuItem});
            this.单串口ToolStripMenuItem.Name = "单串口ToolStripMenuItem";
            this.单串口ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.单串口ToolStripMenuItem.Text = "单串口";
            // 
            // 旧机器API2ToolStripMenuItem
            // 
            this.旧机器API2ToolStripMenuItem.Name = "旧机器API2ToolStripMenuItem";
            this.旧机器API2ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.旧机器API2ToolStripMenuItem.Text = "旧机器API2";
            this.旧机器API2ToolStripMenuItem.Click += new System.EventHandler(this.旧机器API2ToolStripMenuItem_Click);
            // 
            // 双串口ToolStripMenuItem
            // 
            this.双串口ToolStripMenuItem.Name = "双串口ToolStripMenuItem";
            this.双串口ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.双串口ToolStripMenuItem.Text = "双串口";
            // 
            // 无串口ToolStripMenuItem
            // 
            this.无串口ToolStripMenuItem.Name = "无串口ToolStripMenuItem";
            this.无串口ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.无串口ToolStripMenuItem.Text = "无串口";
            this.无串口ToolStripMenuItem.Click += new System.EventHandler(this.无串口ToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.生产模式ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(416, 25);
            this.menuStrip1.TabIndex = 31;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // Port
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(416, 451);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.TxtIdentifier);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.GrpPort2);
            this.Controls.Add(this.GrpPort1);
            this.Controls.Add(this.btnSave);
            this.Name = "Port";
            this.Text = "SerialPort";
            this.GrpPort1.ResumeLayout(false);
            this.GrpPort1.PerformLayout();
            this.GrpPort2.ResumeLayout(false);
            this.GrpPort2.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox GrpPort1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CmbPortName1;
        private System.Windows.Forms.ComboBox CmbStopBits1;
        private System.Windows.Forms.ComboBox CmbDataBits1;
        private System.Windows.Forms.ComboBox CmbParity1;
        private System.Windows.Forms.ComboBox CmbBaudRate1;
        private System.Windows.Forms.GroupBox GrpPort2;
        private System.Windows.Forms.ComboBox CmbStopBits2;
        private System.Windows.Forms.ComboBox CmbDataBits2;
        private System.Windows.Forms.ComboBox CmbParity2;
        private System.Windows.Forms.ComboBox CmbBaudRate2;
        private System.Windows.Forms.ComboBox CmbPortName2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox TxtIdentifier;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ToolStripMenuItem 生产模式ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 单串口ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 双串口ToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 旧机器API2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 无串口ToolStripMenuItem;
    }
}