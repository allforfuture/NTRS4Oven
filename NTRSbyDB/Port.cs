using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Microsoft.Win32;
using System.IO.Ports;

namespace NTRSbyDB
{
    public partial class Port : Form
    {
        public static string identifier;
        public Port()
        {
            InitializeComponent();
            CmbPortName1.Items.AddRange(System.IO.Ports.SerialPort.GetPortNames());
            CmbPortName2.Items.AddRange(System.IO.Ports.SerialPort.GetPortNames());
            //载入生产模式
            switch (Main.mode)
            {
                case Main.Mode.旧机器API2:
                    旧机器API2ToolStripMenuItem.Checked = true;
                    GrpPort1.Enabled = true;
                    break;
                case Main.Mode.无串口:
                    无串口ToolStripMenuItem.Checked = true;
                    GrpPort1.Enabled = false;
                    GrpPort2.Enabled = false;
                    break;
            }
            #region load注册表
            if (Regedit.isRegeditKeyExit("Port"))
            {
                RegistryKey myreg = Registry.LocalMachine.OpenSubKey(@"software\NTRS");
                String[] valueList = (String[])(myreg.GetValue("Port"));
                if (valueList.Length == 5|| valueList.Length == 10)
                {
                    CmbPortName1.Text = valueList[0];
                    CmbBaudRate1.Text = valueList[1];
                    CmbParity1.Text = valueList[2];
                    CmbDataBits1.Text = valueList[3];
                    CmbStopBits1.Text = valueList[4];
                    if (valueList.Length == 10)
                    {
                        CmbPortName2.Text = valueList[5];
                        CmbBaudRate2.Text = valueList[6];
                        CmbParity2.Text = valueList[7];
                        CmbDataBits2.Text = valueList[8];
                        CmbStopBits2.Text = valueList[9];
                    }
                }
            }


            if (Regedit.isRegeditKeyExit("Identifier"))
            {
                RegistryKey myreg = Registry.LocalMachine.OpenSubKey(@"software\NTRS");
                identifier = (String)(myreg.GetValue("Identifier"));

                switch (identifier)
                {
                    case "\r":
                        TxtIdentifier.Text = "[CR]";
                        break;
                    case "\n":
                        TxtIdentifier.Text = "[LF]";
                        break;
                    default:
                        TxtIdentifier.Text = identifier;
                        break;
                }
            }
            #endregion
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (TxtIdentifier.Text=="") { MessageBox.Show("分隔符不能为空"); return; }
            if (!无串口ToolStripMenuItem.Checked && !GrpPort1.Enabled && !GrpPort2.Enabled)
            { MessageBox.Show("请勾选生产模式");return; }
            #region 检查是否有空值和2个串口是否用同一端口名
            if (GrpPort1.Enabled)
            {
                foreach (Control control in GrpPort1.Controls)
                {
                    if (control.Text == "")
                    {
                        MessageBox.Show("串口1参数有空值，不能保存");
                        return;
                    }
                }
            }
            if (GrpPort2.Enabled)
            {
                if (CmbPortName1.Text == CmbPortName2.Text && CmbPortName2.Text != "")
                {
                    MessageBox.Show("串口2的端口名已被串口1占用");
                    return;
                }
                foreach (Control control in GrpPort2.Controls)
                {
                    if (control.Text == "")
                    {
                        MessageBox.Show("串口2参数有空值，不能保存");
                        return;
                    }
                }
            }
            #endregion

            Parity parity = Parity.None;
            StopBits stopBits = StopBits.One;
            switch (CmbParity1.Text)
            {
                case "偶":
                    parity = Parity.Even;
                    break;
                case "奇":
                    parity = Parity.Odd;
                    break;
                case "无":
                    parity = Parity.None;
                    break;
                case "标记":
                    parity = Parity.Mark;
                    break;
                case "空格":
                    parity = Parity.Space;
                    break;
            }
            switch (CmbStopBits1.Text)
            {
                case "1":
                    stopBits = StopBits.One;
                    break;
                case "1.5":
                    stopBits = StopBits.OnePointFive;
                    break;
                case "2":
                    stopBits = StopBits.Two;
                    break;
            }
            //非"无串口"下，测试串口能否打开
            if (!无串口ToolStripMenuItem.Checked)
            {
                try
                {
                    //打开串口
                    Main.main.SptReceiveOrSend.Close();
                    Main.main.SptSend.Close();
                    //Main.main.SptReceiveOrSend = new SerialPort
                    //    (CmbPortName1.Text, int.Parse(CmbBaudRate1.Text), parity, int.Parse(CmbDataBits1.Text), stopBits);
                    Main.main.SptReceiveOrSend.PortName = CmbPortName1.Text;
                    Main.main.SptReceiveOrSend.BaudRate = int.Parse(CmbBaudRate1.Text);
                    Main.main.SptReceiveOrSend.Parity = parity;
                    Main.main.SptReceiveOrSend.DataBits = int.Parse(CmbDataBits1.Text);
                    Main.main.SptReceiveOrSend.StopBits = stopBits;
                    Main.main.SptReceiveOrSend.Open();
                }
                catch (Exception ex)
                {
                    Main.main.SptReceiveOrSend.Close();
                    //Main.main.SptSend.Close();
                    MessageBox.Show(ex.Message, "串口1通讯：", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (GrpPort2.Enabled)
                {
                    switch (CmbParity2.Text)
                    {
                        case "偶":
                            parity = Parity.Even;
                            break;
                        case "奇":
                            parity = Parity.Odd;
                            break;
                        case "无":
                            parity = Parity.None;
                            break;
                        case "标记":
                            parity = Parity.Mark;
                            break;
                        case "空格":
                            parity = Parity.Space;
                            break;
                    }
                    switch (CmbStopBits2.Text)
                    {
                        case "1":
                            stopBits = StopBits.One;
                            break;
                        case "1.5":
                            stopBits = StopBits.OnePointFive;
                            break;
                        case "2":
                            stopBits = StopBits.Two;
                            break;
                    }
                    try
                    {
                        //Main.main.SptSend.Close();
                        Main.main.SptSend.PortName = CmbPortName2.Text;
                        Main.main.SptSend.BaudRate = int.Parse(CmbBaudRate2.Text);
                        Main.main.SptSend.Parity = parity;
                        Main.main.SptSend.DataBits = int.Parse(CmbDataBits2.Text);
                        Main.main.SptSend.StopBits = stopBits;
                        Main.main.SptSend.Open();
                    }
                    catch (Exception ex)
                    {
                        //Main.main.SptReceiveOrSend.Close();
                        Main.main.SptSend.Close();
                        MessageBox.Show(ex.Message, "串口2通讯：", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            #region 能成功打开串口后，保存到注册表以及更改属性
            RegistryKey key = Registry.LocalMachine;
            RegistryKey software = key.OpenSubKey(@"software\NTRS", true);
            //串口
            if (!无串口ToolStripMenuItem.Checked)
            {
                string[] port = { CmbPortName1.Text, CmbBaudRate1.Text, CmbParity1.Text, CmbDataBits1.Text, CmbStopBits1.Text };
                if (GrpPort2.Enabled)
                {
                    string[] port2 = { CmbPortName2.Text, CmbBaudRate2.Text, CmbParity2.Text, CmbDataBits2.Text, CmbStopBits2.Text };
                    List<string> temp = port.ToList();
                    temp.AddRange(port2);
                    port = new string[] { };
                    port = temp.ToArray();
                }
                software.SetValue("Port", port, RegistryValueKind.MultiString);
            }
            else { software.SetValue("Port", new string[] { }, RegistryValueKind.MultiString); }
            //生产模式
            string mode="";
            if (旧机器API2ToolStripMenuItem.Checked)
            { Main.mode = Main.Mode.旧机器API2; mode = "旧机器API2"; }
            else if (无串口ToolStripMenuItem.Checked)
            { Main.mode = Main.Mode.无串口; mode = "无串口"; }

            software.SetValue("Mode", mode, RegistryValueKind.String);
            //分隔符
            if (TxtIdentifier.Text == "[CR]")
            { identifier = "\r"; }
            else if (TxtIdentifier.Text == "[LF]")
            { identifier = "\n"; }
            else if (TxtIdentifier.Text.Length != 1)
            { identifier = TxtIdentifier.Text.Substring(TxtIdentifier.Text.Length - 1, 1); }
            else { identifier = TxtIdentifier.Text; }

            software.SetValue("Identifier", identifier, RegistryValueKind.String);
            #endregion
            MessageBox.Show("保存成功");
            this.Close();
        }

        #region 模式选择
        private void 光子云ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SingleCheck(sender);
        }

        private void 大研ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SingleCheck(sender);
        }
        private void 旧机器ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SingleCheck(sender);
        }

        private void 单片机ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SingleCheck(sender);
        }

        private void ONSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SingleCheck(sender);
        }

        void SingleCheck(object sender)
        {
            #region 全关闭，在打开所需的
            //单串口
            //光子云ToolStripMenuItem.Checked = false;
            //大研ToolStripMenuItem.Checked = false;
            //旧机器ToolStripMenuItem.Checked = false;
            旧机器API2ToolStripMenuItem.Checked = false;
            //双串口
            //单片机ToolStripMenuItem.Checked = false;
            //ONSToolStripMenuItem.Checked = false;
            //无串口
            无串口ToolStripMenuItem.Checked = false;
            ((ToolStripMenuItem)sender).Checked = true;
            #endregion
            switch (((ToolStripMenuItem)sender).OwnerItem.Name)
            {
                case "单串口ToolStripMenuItem":
                    GrpPort1.Enabled = true;
                    GrpPort2.Enabled = false;
                    break;
                case "双串口ToolStripMenuItem":
                    GrpPort1.Enabled = GrpPort2.Enabled = true;
                    break;
                default:
                    GrpPort1.Enabled = GrpPort2.Enabled = false;
                    break;
            }
        }
        #endregion

        private void 旧机器API2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SingleCheck(sender);
        }
        private void 无串口ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SingleCheck(sender);
        }
    }
}