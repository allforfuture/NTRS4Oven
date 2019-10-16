using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Configuration;

namespace NTRSbyDB
{
    class Oven
    {
        public static double GetSpendSec(string sn, ref string startTime,ref string endTime)
        {
            int forTime = 2;//循环最近月份次数：2个月
            for (int month = 0; month < forTime; month++)
            {
                string ovenLog = ConfigurationManager.AppSettings["ovenLog"];
                string fileName = "log" + DateTime.Now.AddMonths(-month).ToString("yyyyMM") + ".txt";
                string path = System.IO.Path.Combine(ovenLog, fileName);
                string[] strArr = System.IO.File.ReadAllLines(path);
                //颠倒循环，找离现在最近的时间记录
                for (int i = strArr.Length; i > 0; i--)
                {
                    if (strArr[i - 1].Contains(sn))
                    {
                        string[] strLine = strArr[i - 1].Split(',');//20190904,08:49:34,[GH9935710M1NY1413,09,08,30,09,49,53]

                        string startTimeStr = string.Format("{0} {1}:{2}:{3}",
                            strLine[0], strLine[3], strLine[4], strLine[5]);
                        string endTimeStr = string.Format("{0} {1}:{2}:{3}",
                            strLine[0], strLine[6], strLine[7], strLine[8].Substring(0, 2));

                        DateTime start = DateTime.ParseExact(startTimeStr, "yyyyMMdd HH:mm:ss",
                            System.Globalization.CultureInfo.CurrentCulture);
                        DateTime end = DateTime.ParseExact(endTimeStr, "yyyyMMdd HH:mm:ss",
                            System.Globalization.CultureInfo.CurrentCulture);

                        start = start > end ? start.AddDays(-1) : start;
                        startTime = start.ToString("HH:mm:ss");
                        endTime = end.ToString("HH:mm:ss");
                        return (end - start).TotalSeconds;
                    }
                }
            }
            return 0;
        }
    }
}
