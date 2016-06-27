using System;
using System.Data;
using EasyAsDriverTraining.Tools;
using MySql.Data.MySqlClient;


namespace EasyAsDriverTraining.Data
{
    class Listing
    {
       

    public static DataTable LoadBySearchOption(String sSuburb, String sTrainer)
        {
            var dt = new DataTable();
            try
            {
                string strSQL =
                    "select ID, Suburb, Trainer, Qualification, Transmission, Model, RegNo, Area from Listing ";
                
                if (sSuburb.Length > 0)
                    strSQL += "where Suburb LIKE '%" + sSuburb + "%'";

                if (sSuburb.Length > 0 && sTrainer.Length > 0)
                    strSQL += "and Trainer LIKE '%" + sTrainer + "%'";

                if (sSuburb.Length <= 0 && sTrainer.Length > 0)
                    strSQL += "where Trainer LIKE '%" + sTrainer + "%'";

                var db = new Mysql(Gobal.ConnString);
                dt = db.RetDataTable(strSQL);
            }
            catch (Exception ex)
            {
                MessageClass.ShowError(ex.Message, System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.Name);
            }

            return dt;
        }


    public static Boolean Update(String sId, String sSuburb, String sTrainer, String sQualification, String sTransmission, String sModel, String sRegNo, String sArea)
        {
            Boolean isSusscess = true;
            try
            {
                var db=new Mysql(Gobal.ConnString);
                db.Update("update Listing set Suburb= '" + sSuburb + ", Trainer= '" + sTrainer + ", Qualification= '" + sQualification + ", Transmission= '" + sTransmission + ", Model= '" + sModel + ", RegNo= '" + sRegNo + ", Area= '" + sArea + "' where ID =" + sId);
            }
            catch (Exception ex)
            {
                MessageClass.ShowError(ex.Message, System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.Name);
                isSusscess = false;
            }

            return isSusscess;
        }

    public static Boolean Insert(String sSuburb, String sTrainer, String sQualification, String sTransmission, String sModel, String sRegNo, String sArea)
        {
            Boolean isSusscess = true;
            try
            {
                var db=new Mysql(Gobal.ConnString);
                db.ConnectDb();
                if (!db.ConnStatus)
                    return false;

                const string strSQL = @"INSERT INTO Listing
                                ( Suburb, Trainer, Qualification, Transmission, Model, RegNo, Area) 
                                VALUES
                                ( @Suburb, @Trainer, @Qualification, @Transmission, @Model, @RegNo, @Area);";

                var da = new MySqlCommand(strSQL, db.Conn);

                da.Parameters.AddWithValue("@Suburb", sSuburb);
                da.Parameters.AddWithValue("@Trainer", sTrainer);
                da.Parameters.AddWithValue("@Qualification", sQualification);
                da.Parameters.AddWithValue("@Transmission", sTransmission);
                da.Parameters.AddWithValue("@Model", sModel);
                da.Parameters.AddWithValue("@RegNo", sRegNo);
                da.Parameters.AddWithValue("@Area", sArea);

                da.ExecuteNonQuery();
                da.Dispose();
            }
            catch (Exception ex)
            {
                MessageClass.ShowError(ex.Message, System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.Name);
                isSusscess = false;
            }

            return isSusscess;
        }


        public static Boolean Delete(String sId)
        {
            Boolean isSusscess = true;
            try
            {
                var db=new Mysql(Gobal.ConnString);
                db.Update("delete from Listing where ID =" + sId);
            }
            catch (Exception ex)
            {
                MessageClass.ShowError(ex.Message, System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.Name);
                isSusscess = false;
            }

            return isSusscess;
        }
    }
}