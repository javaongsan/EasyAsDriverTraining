using System;
using System.Linq;
using System.Data;
using MySql.Data.MySqlClient;

namespace EasyAsDriverTraining.Tools
{
    public class Mysql
    {
        private bool _isConnected;
        private MySqlConnection _conn;
        private readonly String _mConnString = String.Empty;

        public Mysql(String connString)
        {
            _mConnString = connString;
        }

        public MySqlConnection Conn
        {
            get
            {
                return _conn;
            }
            set
            {
                _conn = value;
            }
        }

        public bool ConnStatus
        {
            get
            {
                return _isConnected;
            }
            set
            {
                _isConnected = value;
            }
        }

        public MySqlConnection ConnectDb()
        {
            try
            {
                if (_isConnected == false)
                {
                    try
                    {
                        if (_mConnString.Length <= 0)
                        {
                            _isConnected = false;
                            return null;
                        }

                        _conn = new MySqlConnection(_mConnString);
                        _conn.Open();
                    }
                    catch (MySqlException ex)
                    {
                        _isConnected = false;
                        MessageClass.HideError(ex.Message + "MySqlException", System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.Name);
                        return null;
                    }
                    _isConnected = true;
                }
                return _conn;
            }
            catch (Exception ex)
            {
                MessageClass.HideError(ex.Message, System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.Name);
                return null;
            }
        }

        public bool TestDb()
        {
            bool success = true;
            try
            {
                if (_isConnected == false)
                {
                    try
                    {
                        _conn = new MySqlConnection(_mConnString);
                        _conn.Open();
                        _conn.Close();
                        _conn.Dispose();
                    }
                    catch (MySqlException)
                    {
                        success = false;
                        _isConnected = false;
                    }
                }
            }
            catch
            {
                success = false;
            }
            return success;
        }

        public void DisconnectDb()
        {
            if (!_isConnected) return;
            _conn.Close();
            _conn.Dispose();
            _isConnected = false;
        }

        public MySqlDataReader Query(string strSQL)
        {
            MySqlDataReader sqlRead = null;
            try
            {
                ConnectDb();
                if (!_isConnected)
                    return null;

                var sqlCom = new MySqlCommand(strSQL, _conn);
                sqlRead = sqlCom.ExecuteReader();
                sqlCom.Dispose();
                DisconnectDb();
            }
            catch (Exception ex)
            {
                MessageClass.HideError(ex.Message, System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.Name);
            }

            return sqlRead;
        }

        public String SingleResult(string strSQL)
        {
            String result = String.Empty;
            try
            {
                ConnectDb();
                if (!_isConnected)
                    return result;

                var sqlCom = new MySqlCommand(strSQL, _conn);
                MySqlDataReader sqlRead = sqlCom.ExecuteReader();
                if (sqlRead.Read())
                    result = sqlRead[0].ToString();
                sqlCom.Dispose();
                DisconnectDb();
            }
            catch (Exception ex)
            {
                MessageClass.HideError(ex.Message, System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.Name);
            }

            return result;
        }

        public Boolean Update(string strSQL)
        {
            Boolean result = true;
            try
            {
                ConnectDb();
                if (!_isConnected)
                    return false;

                var sqlCom = new MySqlCommand(strSQL, _conn);
                sqlCom.ExecuteNonQuery();
                sqlCom.Dispose();
                DisconnectDb();
            }
            catch (MySqlException ex)
            {
                if (ex.ErrorCode != -2147467259)
                    MessageClass.HideError(ex.Message, System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.Name);
                result = false;
            }
            return result;
        }

        public String Execute(string strSQL)
        {
            return Execute(strSQL, true);
        }

        public String ExecuteNoLog(string strSQL)
        {
            return Execute(strSQL, false);
        }

        public String Execute(string strSQL, bool logit)
        {
            String result = "OK";
            try
            {
                ConnectDb();
                if (!_isConnected)
                    return String.Empty;

                var sqlCom = new MySqlCommand(strSQL, _conn) { CommandTimeout = 0 };
                sqlCom.ExecuteNonQuery();
                sqlCom.Dispose();
                DisconnectDb();
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            return result;
        }

        public DataTable RetDataTable(string strSQL)
        {
            return RetDataTable(strSQL, CommandType.Text, null);
        }

        public DataTable RetDataTable(string strSQL, CommandType oCommandType, MySqlParameter[] oSqlParameter)
        {
            DataTable dt = null;
            try
            {
                ConnectDb();
                if (!_isConnected)
                    return null;

                var da = new MySqlDataAdapter
                    {
                        SelectCommand = new MySqlCommand(strSQL, _conn) { CommandTimeout = 0, CommandType = oCommandType }
                    };
                if (oSqlParameter != null)
                    foreach (MySqlParameter prm in oSqlParameter)
                        da.SelectCommand.Parameters.Add(prm);
                var dsResult = new DataTable();
                da.Fill(dsResult);
                dt = dsResult;
                da.Dispose();
                DisconnectDb();
            }
            catch (Exception ex)
            {
                MessageClass.HideError(ex.Message, System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.Name);
            }
            return dt;
        }

        public Boolean ExecuteNonQuery(string strSQL, MySqlParameter[] oSqlParameter)
        {
            const bool isSusscess = false;

            try
            {
                ConnectDb();
                if (!_isConnected)
                    return isSusscess;

                var sqlCom = new MySqlCommand();
                MySqlTransaction trans = _conn.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
                sqlCom.Connection = _conn;
                sqlCom.CommandTimeout = 0;
                sqlCom.Transaction = trans;
                try
                {
                    sqlCom.CommandText = strSQL;

                    if (oSqlParameter != null)
                    {
                        sqlCom.Prepare();
                        foreach (MySqlParameter prm in oSqlParameter)
                            sqlCom.Parameters.Add(prm);
                    }
                    sqlCom.ExecuteNonQuery();
                    trans.Commit();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    MessageClass.HideError(ex.Message, System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.Name);
                }
            }
            catch (Exception ex)
            {
                MessageClass.HideError(ex.Message, System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.Name);
            }
            finally
            {
                DisconnectDb();
            }

            if (oSqlParameter != null)
                strSQL = oSqlParameter.Aggregate(strSQL, (current, prm) => current + (":" + prm.Value.ToString()));
            return isSusscess;
        }


      
        public int Count(string strSQL)
        {
            var result = 0;

            try
            {
                ConnectDb();
                if (!_isConnected)
                    return result;

                var sqlCom = new MySqlCommand(strSQL, _conn);
                MySqlDataReader reader = sqlCom.ExecuteReader();
                if (reader.Read())
                    result = reader.GetInt32(0);
                DisconnectDb();
            }
            catch (Exception ex)
            {
                MessageClass.HideError(ex.Message, System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.Name);
            }
            return result;
        }

        public bool TransactionUpdate(String[] strSqLs, MySqlParameter[] oSqlParameter)
        {
            var isSuccess = true;
            var paraCooked = false;
            try
            {
                ConnectDb();
                if (_isConnected)
                {
                    var sqlCom = _conn.CreateCommand();
                    var trans = _conn.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
                    sqlCom.Connection = _conn;
                    sqlCom.Transaction = trans;
                    try
                    {
                        foreach (var strSQL in strSqLs)
                        {
                            if (strSQL == null)
                                continue;

                            sqlCom.CommandText = strSQL;
                            if (oSqlParameter != null && !paraCooked)
                            {
                                string newSQL = string.Empty;
                                sqlCom.Prepare();
                                foreach (MySqlParameter prm in oSqlParameter)
                                {
                                    sqlCom.Parameters.Add(prm);
                                    newSQL += "," + prm.Value.ToString();
                                }
                                paraCooked = true;
                            }
                            
                            sqlCom.ExecuteNonQuery();
                        }
                        trans.Commit();
                    }
                    catch (MySqlException ex)
                    {
                        MessageClass.HideError(ex.Message,
                                                   System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.Name);

                        try
                        {
                            trans.Rollback();
                        }
                        catch (MySqlException mse)
                        {
                            MessageClass.HideError(mse.Message,
                                                   System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.Name);
                            return false;
                        }
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageClass.HideError(ex.Message, System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.Name);
                isSuccess = false;
            }

            return isSuccess;
        }
    }
}

