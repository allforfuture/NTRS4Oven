using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTRSbyDB.Info
{
    class TrayList
    {
        public static List<Tray> trayList = new List<Tray>();
        public class Tray
        {
            internal string sn { get; set; }
            internal string process_at { get; set; }
            internal string datatype_id { get; set; }
            internal string partsserial_cd { get; set; }
            internal string result { get; set; }

            internal string value { get; set; }
            internal string bin { get; set; }
        }
    }
   

    class DB
    {
        static string sql0 = System.IO.File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory+ @"DB.sql");
        public static TrayList.Tray GetTrayInfo(string sn)
        {
            string sql = sql0.Replace("{0}", sn);
            System.Data.DataTable dt = new System.Data.DataTable();
            new DBFactory().ExecuteDataTable(sql, ref dt);
            TrayList.Tray tray = new TrayList.Tray() { sn = sn };
            if (dt.Rows.Count > 0)
            {
                //tray.process_at = dt.Rows[0]["process_at"].ToString();
                //tray.datatype_id = dt.Rows[0]["datatype_id"].ToString();
                //tray.partsserial_cd = dt.Rows[0]["partsserial_cd"].ToString();
                //if (Info.TrayList.trayList.Count == 0)
                //{ tray.result = "0"; }
                //else
                //{ tray.result = Info.TrayList.trayList[0].partsserial_cd == tray.partsserial_cd ? "0" : "1"; }
                tray.value= dt.Rows[0]["avg"].ToString();
                tray.bin= dt.Rows[0]["case"].ToString();
                return tray;
            }
            else
            {
                tray.result = "1";
                return tray;
            }
        }
    }
}