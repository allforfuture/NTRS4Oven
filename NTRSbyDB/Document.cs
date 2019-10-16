using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Configuration;

namespace NTRSbyDB
{
    class Document
    {

        public static List<string> pathList = new List<string>()
        {
            AppDomain.CurrentDomain.BaseDirectory + "log\\",
            AppDomain.CurrentDomain.BaseDirectory + "pqm\\",
            AppDomain.CurrentDomain.BaseDirectory + "sum\\"
        };

        public static void CreateDocument()
        {
            foreach (string path in pathList)
            {
                Directory.CreateDirectory(path);
            }
        }
    }

    class Log : Document
    {
        public static void WriteLog(string SN,string detail,string judge)
        {
            string path = Document.pathList[0] + "log" + DateTime.Now.ToString("yyyyMMdd") + ".txt";
            using (StreamWriter file = new StreamWriter(path, true))//(@"C:\Users\YEYINXU\Desktop\log" + DateTime.Now.ToString("yyyyMMdd") + ".txt", true))
            {
                string str = DateTime.Now.ToString("yyyy/MM/dd,HH:mm:ss,")
                    + SN + ","
                    + detail.Replace("\r\n", "$")+ ","
                    + judge;
                file.WriteLine(str);// 直接追加文件末尾，换行
            }
        }

        public static void WriteError(string SN)
        {
            //string path = Document.pathList[0] +  DateTime.Now.ToString("yyyyMMdd") + "ErrorLog.txt";
            string path = Document.pathList[0] + "log" + DateTime.Now.ToString("yyyyMMdd") + ".txt";
            using (StreamWriter file = new StreamWriter(path, true))
            {
                file.WriteLine(DateTime.Now.ToString("yyyy/MM/dd,HH:mm:ss,@") + SN);// 直接追加文件末尾，换行 
            }
        }
    }

    class Pqm : Document
    {
        public static string type = ConfigurationManager.AppSettings["type"];
        static string factory = ConfigurationManager.AppSettings["factory"];
        static string building = ConfigurationManager.AppSettings["building"];
        static string line = ConfigurationManager.AppSettings["line"];
        static string process = ConfigurationManager.AppSettings["process"];
        static string inspect = ConfigurationManager.AppSettings["inspect"];
        public static string upperLimit = ConfigurationManager.AppSettings["upperLimit"];
        public static string lowerLimit = ConfigurationManager.AppSettings["lowerLimit"];

        public static void WriteCSV(Info.TrayList.Tray trayInfo)//(string SN,DateTime checkTime)
        {
            DateTime dt = DateTime.Now;
            string fileName = type + factory + building + line + process + dt.ToString("_yyyyMMddHHmmss_") + trayInfo.sn;
            string path = Document.pathList[1] + fileName + ".csv";
            using (StreamWriter file = new StreamWriter(path, true))
            {
                string[] csvStr = new string[]
                {
                    type, factory, building, line, process, trayInfo.sn, "", "", "", dt.ToString("yy,MM,dd,HH,mm,ss"), "1", inspect,
                    upperLimit,lowerLimit,Info.Oven.roastTime.ToString(),Info.Oven.result,trayInfo.result ,"0"
                };
                string str = String.Join(",", csvStr);

                file.WriteLine(str);// 直接追加文件末尾，换行 
            }
        }
    }

    class Sum:Document
    {
        public static int passQty;
        public static int failQty;
        public static int skipQty;
        public static string ReadTotal()
        {
            string path =Document.pathList[2] +"total_yield.txt";
            string totalStr = string.Empty;
            if (File.Exists(path))
            {
                int row = 0;
                string fileStr;
                using (StreamReader sr = new StreamReader(path, Encoding.UTF8))
                {
                    while ((fileStr = sr.ReadLine()) != null)
                    {
                        if (row == 0)
                        { totalStr = fileStr + "\r\n"; }
                        else { totalStr += fileStr + "\r\n"; }
                        switch (++row)
                        {
                            case 1:
                                passQty = int.Parse(fileStr);
                                break;
                            case 2:
                                failQty = int.Parse(fileStr);
                                break;
                            case 3:
                                skipQty = int.Parse(fileStr);
                                break;
                        }
                    }
                }
            }
            else
            {
                totalStr += "0\r\n";
                totalStr += "0\r\n";
                totalStr += "0\r\n";
                totalStr += "--\r\n";
                totalStr += "--";
                passQty = failQty = skipQty = 0;
            }
            return  totalStr;
        }

        public static void WriteTotal()
        {
            string path = Document.pathList[2] + "total_yield.txt";
            //覆盖旧文件
            FileStream writeFile = new FileStream(path, FileMode.Create);
            using (StreamWriter sw = new StreamWriter(writeFile))
            {
                string str = null;
                str = passQty.ToString() + "\r\n";
                str += failQty.ToString() + "\r\n";
                str += skipQty.ToString() + "\r\n";
                double sum = passQty + failQty + skipQty;
                str += Math.Round(Convert.ToDouble(sum - failQty) / sum, 4) * 100 + "%\r\n";
                str += Math.Round(Convert.ToDouble(sum - skipQty) / sum, 4) * 100 + "%";
                sw.Write(str);
            }
        }
    }
}
