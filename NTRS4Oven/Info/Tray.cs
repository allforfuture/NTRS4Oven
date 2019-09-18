using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTRS4Oven.Info
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
            //internal string detail { get; set; }
            //internal string tips { get; set; }
        }
    }
   

    class DB
    {
        public static TrayList.Tray GetTrayInfo(string sn)
        {
//with temp_table as
//(select ROW_NUMBER() OVER(PARTITION BY serial_cd ORDER BY faci_seq desc),*
//--faci_seq,updated_at,process_at,proc_uuid,work_cd,machine_cd,serial_cd,lot_cd,mo_cd,tag_id,datatype_id,partsserial_cd,partslot_cd,cavity_no
//from t_faci_kk13
//where datatype_id = 'OVEN_TRAY_ID')

//select* from temp_table
// where row_number = 1
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat(
@"SELECT process_at,datatype_id,partsserial_cd
FROM t_faci_{0}
WHERE datatype_id = 'OVEN_TRAY_ID'
AND serial_cd='{1}'
ORDER BY faci_seq DESC"
, Pqm.type.ToLower(),  sn);
            System.Data.DataTable dt = new System.Data.DataTable();
            new DBFactory().ExecuteDataTable(sql.ToString(), ref dt);
            TrayList.Tray tray = new TrayList.Tray() { sn = sn };
            if (dt.Rows.Count > 0)
            {
                tray.process_at = dt.Rows[0]["process_at"].ToString();
                tray.datatype_id = dt.Rows[0]["datatype_id"].ToString();
                tray.partsserial_cd = dt.Rows[0]["partsserial_cd"].ToString();
                if (Info.TrayList.trayList.Count == 0)
                { tray.result = "0"; }
                else
                { tray.result = Info.TrayList.trayList[0].partsserial_cd == tray.partsserial_cd ? "0" : "1"; }
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