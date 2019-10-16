using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Win32;
using System.IO.Ports;


namespace NTRSbyDB
{
    class Regedit
    {
        public static string[] Trajectory;

        /// <summary>
        ///  LocalMachine\software\NTRS下，是否存在keyStr
        /// </summary>
        /// <param name="keyStr">键名</param>
        /// <returns></returns>
        public static bool isRegeditKeyExit(string keyStr)
        {
            RegistryKey software = Registry.LocalMachine.OpenSubKey(@"software\NTRS");
            string[] subkeyNames = software.GetValueNames();
            foreach (string keyName in subkeyNames)
            {
                if (keyName == keyStr)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 验证:
        /// 1.存在键
        /// 2.元素相等且相同
        /// </summary>
        /// <returns></returns>
        public static bool verifyTrajectory()
        {
            try
            {
                RegistryKey myreg = Registry.LocalMachine.OpenSubKey(@"software\NTRS");
                String[] sequenceList = (String[])(myreg.GetValue("Trajectory"));

                List<string> list = new List<string>();
                for (int i = 0; i < Layout.row; i++)
                {
                    for (int j = 0; j < Layout.col; j++)
                    {
                        list.Add((j + 1).ToString() + "," + (i + 1).ToString());
                    }
                }
                //A中有B中没有的       //B中有A中没有的
                if (sequenceList.Except(list.ToArray()).Count() == 0
                    && list.ToArray().Except(sequenceList).Count() == 0)
                {
                    Trajectory = sequenceList;
                    return true;
                }
                else { return false; }
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 验证:
        /// 1.存在键
        /// 2.与生产模式所需的串口个数相符
        /// 3.所需的串口（单或双）能打开
        /// </summary>
        /// <returns></returns>
        public static bool verifyPort()
        {
            try
            {
                RegistryKey myreg = Registry.LocalMachine.OpenSubKey(@"software\NTRS");
                String[] portValues = (String[])(myreg.GetValue("Port"));
                string modeValue = (string)(myreg.GetValue("Mode"));
                //Main.mode唯一一处赋值代码
                Main.mode = (Main.Mode)Enum.Parse(typeof(Main.Mode), modeValue);
                if (Convert.ToInt16(Main.mode) == 0)
                    return true;
                string identifier = (string)(myreg.GetValue("Identifier"));
                if (identifier == null) { return false; }
                else { Port.identifier = identifier; }

                //if (Main.mode==0) { return false; }
                /*else */
                if (Convert.ToInt16(Main.mode) < 10)//单串口个位数，双串口两位数
                {
                    //单串口
                    if (portValues.Length != 5)
                        return false;
                }
                else
                {
                    //双串口
                    if (portValues.Length != 10)
                        return false;
                }
                #region 打开串口
                Parity parity = Parity.None;
                StopBits stopBits = StopBits.One;
                switch (portValues[2])
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
                switch (portValues[4])
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
                Main.main.SptReceiveOrSend.Close();
                //new的时候会把事件的委托清空
                //Main.main.SptReceiveOrSend = new System.IO.Ports.SerialPort
                //    (portValues[0], int.Parse(portValues[1]), parity, int.Parse(portValues[3]), stopBits);
                Main.main.SptReceiveOrSend.PortName = portValues[0];
                Main.main.SptReceiveOrSend.BaudRate = int.Parse(portValues[1]);
                Main.main.SptReceiveOrSend.Parity = parity;
                Main.main.SptReceiveOrSend.DataBits = int.Parse(portValues[3]);
                Main.main.SptReceiveOrSend.StopBits = stopBits;

                Main.main.SptReceiveOrSend.Open();
                if (portValues.Length ==10)
                {
                    switch (portValues[7])
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
                    switch (portValues[9])
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
                    Main.main.SptSend.Close();
                    //Main.main.SptSend = new System.IO.Ports.SerialPort
                    //    (portValues[5], int.Parse(portValues[6]), parity, int.Parse(portValues[8]), stopBits);
                    Main.main.SptSend.PortName = portValues[5];
                    Main.main.SptSend.BaudRate = int.Parse(portValues[6]);
                    Main.main.SptSend.Parity = parity;
                    Main.main.SptSend.DataBits = int.Parse(portValues[8]);
                    Main.main.SptSend.StopBits = stopBits;

                    Main.main.SptSend.Open();
                }
                #endregion
                return true;
            }
            catch (Exception ex)
            {
                Main.main.SptReceiveOrSend.Close();
                Main.main.SptSend.Close();
                System.Windows.Forms.MessageBox.Show(ex.Message);
                return false;
            }
        }
    }
}
