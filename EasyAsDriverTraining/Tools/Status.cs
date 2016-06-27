using System;
using System.Data;

namespace EasyAsDriverTraining.Tools
{
    public class RecordStatus
    {
        public const string Active = "ACTIVE";
        public const string Cancel = "CANCEL";
        public const string Locked = "LOCKED";

        public const string Status = "STATUS";
        public const string Online = "[Web On-Line]";
        public const string Lan = "[Office-LAN]";
        public const string Offline = "[Off-Line]";


        public static DataTable LoadAll()
        {

            DataTable dt = null;
            try
            {
                dt = new DataTable();

                var dc = new DataColumn
                    {
                        DataType = System.Type.GetType("System.String"),
                        ColumnName = Status,
                        ReadOnly = true,
                        Unique = true
                    };
                dt.Columns.Add(dc);
                DataRow dr = dt.NewRow();
                dr[0] = Active;
                dt.Rows.Add(dr);
                dr = dt.NewRow();
                dr[0] = Cancel;
                dt.Rows.Add(dr);


            }
            catch (Exception ex)
            {
                MessageClass.ShowError(ex.Message, System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.Name);
            }
            return dt;
        }
    }
}
