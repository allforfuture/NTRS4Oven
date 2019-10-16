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

namespace NTRSbyDB
{
    public partial class Trajectory : Form
    {
        //单击之后，次序显示
        int sequence = 0;
        //次序列表（单击之后添加）
        List<string> sequenceList = new List<string>();
        //解决tableLayoutPanel闪烁
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000; // Turn on WS_EX_COMPOSITED 
                return cp;
            }
        }
        public Trajectory()
        {
            InitializeComponent();

            #region 布局
            TlpLayout.RowCount = NTRSbyDB.Layout.row;
            TlpLayout.ColumnCount = NTRSbyDB.Layout.col;

            for (int i = 0; i < NTRSbyDB.Layout.row; i++)
            {
                TlpLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            }
            for (int i = 0; i < NTRSbyDB.Layout.col; i++)
            {
                TlpLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            }

            for (int i = 0; i < NTRSbyDB.Layout.row; i++)
            {
                for (int j = 0; j < NTRSbyDB.Layout.col; j++)
                {
                    Label label = new Label();
                    label.Dock = DockStyle.Fill;
                    label.BackColor = Color.Red;
                    label.Text = "\r\n\r\n\r\n(" + (j + 1).ToString() + "," + (i + 1).ToString() + ")";
                    label.Click += new EventHandler(clickMark);
                    TlpLayout.Controls.Add(label, j, i);
                    //下面这句要是在行和列不够的情况下，会建到100行1000列
                    //tableLayoutPanel1.Controls.Add(label1, 100, 1000);
                }
            }

            void clickMark(object sender, EventArgs e)
            {
                Label label = (Label)sender;
                label.Text = label.Text.Insert(0, (++sequence).ToString());
                label.BackColor = Color.Lime;
                label.Enabled = false;
                sequenceList.Add((TlpLayout.GetColumn(label) + 1).ToString()
                    + ","
                    + (TlpLayout.GetRow(label) + 1).ToString());
            }
            #endregion
            //存在key且通过验证就显示次序顺序
            #region load注册表
            if (Regedit.isRegeditKeyExit("Trajectory"))
            {
                if (!Regedit.verifyTrajectory())
                {
                    return;
                }

                RegistryKey myreg = Registry.LocalMachine.OpenSubKey(@"software\NTRS");
                String[] sequenceList = (String[])(myreg.GetValue("Trajectory"));
                //验证:读取的字符串能匹配上布局的定义坐标（1,1\1,2等）
                foreach (string str in sequenceList)
                {
                    //遍历控件对比
                    for (int i=0;i< TlpLayout.Controls.Count;i++ )
                    {
                        if (TlpLayout.Controls[i].Text.Contains(str))
                        {
                            TlpLayout.Controls[i].BackColor = Color.Lime;
                            TlpLayout.Controls[i].Enabled = false;
                            TlpLayout.Controls[i].Text = TlpLayout.Controls[i].Text.Insert(0, (++sequence).ToString());
                            break;
                        }
                        #region Regedit.verifyTrajectory()覆盖该过程
                        ////全部验证成功才显示次序(只要有一个验证不了，全部取消）
                        ////Regedit.verifyTrajectory()一定要元素相等且相同才可进这里，所以不需要下面这
                        //if (i == tableLayoutPanel1.Controls.Count-1)
                        //{
                        //    cancel_btn_Click(new object (), new EventArgs ());
                        //    return;
                        //}
                        #endregion
                    }
                    #region 索引(比较复杂，用遍历方法实现)
                    ////tableLayoutPanel1.Controls.Add(label, j, i);
                    ////string test=tableLayoutPanel1.Controls[1].Text;
                    ////string a=tableLayoutPanel1.Controls[0,1].Text;
                    //int row=int.Parse(str.Split(',')[0]);
                    //int col = int.Parse(str.Split(',')[1]);
                    ////2,2
                    //int r=row % NTRSjudge.Layout.row;
                    //int c = col % NTRSjudge.Layout.col;
                    #endregion
                }
            }
            #endregion
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            foreach (Label label in TlpLayout.Controls)
            {
                sequence = 0;
                sequenceList = new List<string>();
                label.BackColor = Color.Red;
                label.Enabled = true;
                label.Text = label.Text.Remove(0, label.Text.IndexOf("\r\n"));
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (sequence/*sequenceList.Count*/ == NTRSbyDB.Layout.sum)//NTRSjudge.Layout.row * NTRSjudge.Layout.col)
            {
                if (sequenceList.Count == NTRSbyDB.Layout.sum)
                {
                    RegistryKey key = Registry.LocalMachine;
                    RegistryKey software = key.OpenSubKey(@"software\NTRS", true);
                    software.SetValue("Trajectory", sequenceList.ToArray(), RegistryValueKind.MultiString);
                }
                MessageBox.Show("保存成功");
                this.Close();

                if (!Regedit.verifyTrajectory())
                {
                    #region 重启
                    bool isOpen = false;
                    foreach (Form f in Application.OpenForms)
                    {
                        if (f.Name == "Main")
                        {
                            isOpen = true;
                        }
                    }
                    if (isOpen)//主串口打开了,重启
                    {
                        Application.Exit();
                        System.Diagnostics.Process.Start(System.Reflection.Assembly.GetExecutingAssembly().Location);
                    }
                    #endregion
                }
            }
            else
            {
                MessageBox.Show("保存失败，运动轨迹存在空设定");
            }
        }
    }
}