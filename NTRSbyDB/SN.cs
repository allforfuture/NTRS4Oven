//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//using System.Configuration;
//using System.Windows.Forms;

//namespace NTRS4Oven
//{
//    /// <summary>
//    /// 全部SN清单
//    /// </summary>
//    class AllInfo
//    {
//        internal static List<SNinfo> SNlist = new List<SNinfo>();
//        public class SNinfo
//        {
//            internal string SN { get; set; }
//            internal string result { get; set; }
//            internal string detail { get; set; }
//            internal string tips { get; set; }


//            internal string ovenResult { get; set; }
//            internal string roastTime { get; set; }
//            internal string trayResult { get; set; }
//            internal string partsserial { get; set; }
            




//            //internal DateTime checkTime { get; set; }
//            //internal DateTime firstTime { get; set; }

//        }
//    }

//    /// <summary>
//    /// PPP和EEEE的检查(配置文件)
//    /// </summary>
//    class CheckStr
//    {
//        static List<string> PPP = new List<string>(ConfigurationManager.AppSettings["checkPPP"].Split(','));
//        static List<string> EEEE = new List<string>(ConfigurationManager.AppSettings["checkEEEE"].Split(','));

//        public static bool checkPPP(string SN)
//        {
//            SN = SN.Substring(0, 3);
//            foreach (string PPPstr in PPP)
//            {
//                if (SN == PPPstr)
//                {
//                    return true;
//                }
//            }
//            return false;
//        }

//        public static bool checkEEEE(string SN)
//        {
//            SN = SN.Substring(11, 4);
//            foreach (string EEEEstr in EEEE)
//            {
//                if (SN == EEEEstr)
//                {
//                    return true;
//                }
//            }
//            return false;
//        }
//    }

//    class DB
//    {
//        public static string GetPartsserial(string sn,ref string detail)
//        {
//            StringBuilder sql = new StringBuilder();
//            sql.AppendFormat(
//@"SELECT process_at,datatype_id,partsserial_cd
//FROM t_faci_{0}
//WHERE datatype_id = 'OVEN_TRAY_ID'
//AND serial_cd='{1}'
//ORDER BY faci_seq DESC"
//, Pqm.type.ToLower(), sn);

//            System.Data.DataTable dt = new System.Data.DataTable();
//            new DBFactory().ExecuteDataTable(sql.ToString(), ref dt);
//            if (dt.Rows.Count > 0)
//            {
//                detail = string.Format("{0}\r\n{1}\r\n{2}",
//                    dt.Rows[0]["process_at"].ToString(),
//                    dt.Rows[0]["datatype_id"].ToString(),
//                    dt.Rows[0]["partsserial_cd"].ToString());
//                return dt.Rows[0]["partsserial_cd"].ToString();
//            }
//            return null;
//        }
//    }
    
//    /// <summary>
//    /// 单个SN判断过程
//    /// </summary>
//    class Judge
//    {
//        public static void judge(string SN)
//        {
//            AllInfo.SNinfo info = new AllInfo.SNinfo();
//            info.SN = SN=SN.ToUpper();

//            #region SN是否重复
//            foreach (AllInfo.SNinfo var in AllInfo.SNlist)
//            {
//                if (SN == var.SN&&SN!="ERROR")
//                {
//                    info.result = "MISS";
//                    info.detail = "Duplicate SN";
//                    info.tips = "Duplicate";
//                    AllInfo.SNlist.Add(info);
//                    return;
//                }
//            }
//            #endregion

//            if (SN == "ERROR")
//            {
//                info.result = "MISS";
//                info.detail = "ERROR";
//                info.tips = "Error";
//            }
//            else if (SN.Length < 17)
//            {
//                info.result = "MISS";
//                info.detail = "SN format false";
//                info.tips = "Format false";
//            }
//            //else if (!CheckStr.checkPPP(SN))
//            //{
//            //    info.result = "MISS";
//            //    info.detail = "Miss PPP";
//            //    info.tips = "Miss PPP";
//            //}
//            //else if (!CheckStr.checkEEEE(SN))
//            //{
//            //    info.result = "MISS";
//            //    info.detail += "\r\nMiss EEEE";
//            //    info.tips = "Miss EEEE";
//            //}
//            else
//            {
//                //string temp = string.Empty;
//                //info.result = API.SN_Judge_OK2SHIP(SN, ref temp);
//                //info.detail = temp;
//                ////API2的结果不是"PASS",是"OK"
//                //info.checkTotal = info.checkItem = info.result == "PASS"|| info.result == "OK" ? "0" : "1";

//                #region Oven信息
//                //第一个马达要oven检查：是否存在于log（最近2个月），而且烤的时间在上下限内
//                string startTime="";
//                string endTime="";
//                double spendSecond = Oven.GetSpendSec(SN,ref startTime,ref endTime);
//                info.roastTime = spendSecond.ToString();

//                bool inLimit = double.Parse(Pqm.lowerLimit) <= spendSecond
//                    && spendSecond <= double.Parse(Pqm.upperLimit);
//                if (!inLimit)
//                {
//                    info.result = "FAIL";
//                    info.detail = "Oven Info:\r\nBaking time is out of range";
//                    info.tips = "Out of range";
//                    info.ovenResult = "1";
//                    info.trayResult = "1";
//                    AllInfo.SNlist.Add(info);
//                    return;
//                }
//                info.ovenResult = "0";
//                info.detail = string.Format("Oven Info:\r\n{0}sec\r\n{1}\r\n{2}\r\n\r\n"
//                    , spendSecond, startTime, endTime);
//                #endregion

//                #region 数据库Tray信息
//                string detail = null;
//                info.partsserial = DB.GetPartsserial(SN, ref detail);

//                if (info.partsserial == null)
//                {
//                    info.result = "FAIL";
//                    info.detail += "Tray Info:\r\nNo Tray Data";
//                    info.tips = "No tray data";
//                    info.trayResult = "1";
//                }
//                else
//                {
//                    if (AllInfo.SNlist.Count == 0)
//                    {
//                        info.result = "PASS";
//                        info.trayResult = "0";
//                        //info.tips = "Tray OK";//正常不显示，只有在异常的时候显示
//                    }
//                    else
//                    {
//                        if (info.partsserial == AllInfo.SNlist[0].partsserial)
//                        {
//                            info.result = "PASS";
//                            info.trayResult = "0";
//                            //info.tips = "Tray OK";
//                        }
//                        else
//                        {
//                            info.result = "FAIL";
//                            info.trayResult = "1";
//                            info.tips = "Tray difference";
//                        }
//                    }
//                    info.detail += "Tray Info:\r\n" + detail;
//                }
//                #endregion
//            }
//            AllInfo.SNlist.Add(info);
//        }
//    }
//}