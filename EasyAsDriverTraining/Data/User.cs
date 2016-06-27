using System;
using System.Data;
using EasyAsDriverTraining.Tools;
using MySql.Data.MySqlClient;

namespace EasyAsDriverTraining.Data
{
    class User
    {
        public const string Id = "ID";
        public const string Login = "LOGIN_NAME"; 

        public bool CheckUsernamePassword(string sUsr, string sPass)
        {
            try
            {
                string strSQL = "select ID, ROLE from userfile where LOGIN_NAME= '" + sUsr + "' and  PW = '" + sPass + "' ";
                var db=new Mysql(Gobal.ConnString);
                DataTable dt = db.RetDataTable(strSQL);

                if (dt.Rows.Count > 0)
                {
                    Gobal.GUserId = dt.Rows[0]["ID"].ToString();
                    Gobal.GRoleId = dt.Rows[0]["ROLE"].ToString();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageClass.ShowError(ex.Message, System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.Name);
                return false;
            }
            return false;
        }

        
   
        public static DataTable LoadBySearchOption(String sUsername)
        {
            var dt = new DataTable();
            try
            {
                string strSQL = "select ID, LOGIN_NAME 'LOGIN' , NAME, ROLE, STATUS, PW from userfile where NAME LIKE '%" + sUsername + "%'";
                var db = new Mysql(Gobal.ConnString);
                dt = db.RetDataTable(strSQL);
            }
            catch (Exception ex)
            {
                MessageClass.ShowError(ex.Message, System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.Name);
            }

            return dt;
        }


        public static Boolean Update(String sId, String sName, String sPw, String sStatus, String sLoginName)
        {
            Boolean isSusscess = true;
            try
            {
                var db=new Mysql(Gobal.ConnString);
                db.Update("update userfile set NAME= '" + sName + ", PW='" + sPw +  "', STATUS='" + sStatus + "', LOGIN_NAME='" + sLoginName +  "' where ID =" + sId );
            }
            catch (Exception ex)
            {
                MessageClass.ShowError(ex.Message, System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.Name);
                isSusscess = false;
            }

            return isSusscess;
        }

        public static Boolean Insert(String sName,  String sCreatedate, String sPw,String sStatus, String sRemark, String sEmail, String sLoginName, int iRole)
        {
            Boolean isSusscess = true;
            try
            {
                var db=new Mysql(Gobal.ConnString);
                db.ConnectDb();
                if (!db.ConnStatus)
                    return false;

                const string strSQL = @"INSERT INTO  userfile
                                ( `NAME`,  `CREATEDATE`, `PW`, `STATUS`, `REMARK`, `EMAIL`, `LOGIN_NAME`, ROLE) 
                                VALUES
                                ( @NAME, @CREATEDATE, @PW, @STATUS, @REMARK, @EMAIL, @LOGIN_NAME, @ROLE);";

                var da = new MySqlCommand(strSQL, db.Conn);

                da.Parameters.AddWithValue("@NAME", sName);
               da.Parameters.AddWithValue("@CREATEDATE", sCreatedate);
                da.Parameters.AddWithValue("@PW", sPw);
                da.Parameters.AddWithValue("@STATUS", sStatus);
                da.Parameters.AddWithValue("@REMARK", sRemark);
                da.Parameters.AddWithValue("@EMAIL", sEmail);
                da.Parameters.AddWithValue("@LOGIN_NAME", sLoginName);
                da.Parameters.AddWithValue("@ROLE", iRole);

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
                db.Update("delete from userfile where ID =" + sId);
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
