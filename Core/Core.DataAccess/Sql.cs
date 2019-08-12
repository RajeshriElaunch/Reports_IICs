using System;
using System.Data;
using System.Data.SqlClient;

namespace Core.DataAccess
{
    public class Sql 
    {

        public ConnectionInfo Connection = new ConnectionInfo();

        public Sql()
        {
            Connection.DataSource = "";
            Connection.InitialCatalog = "";
            Connection.User = "";
            Connection.Password = "";

        }

        /// <summary>
        /// Ejecuta sentencias UPDATE, DELETE
        /// </summary>
        /// <param name="strSql"></param>
        public int Execute(string strSql)
        {
            try
            {
                SqlCommand SqlComand = new SqlCommand();
                SqlConnection SqlConnect = new SqlConnection(Connection.StrConnection);
                SqlDataAdapter SqlAdapter = new SqlDataAdapter();
                DataSet SqlDataSet = new DataSet();

                SqlConnect.Open();

                if (SqlConnect.State == ConnectionState.Open)
                {
                    SqlComand.CommandType = CommandType.Text;
                    SqlComand.CommandText = strSql;
                    SqlComand.Connection = SqlConnect;
                    SqlComand.CommandTimeout = 120;
                    SqlAdapter.SelectCommand = SqlComand;

                    return SqlComand.ExecuteNonQuery();
                }

                SqlConnect.Close();
                return -1;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Ejecuta sentencias SELECT
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        public DataSet GetData(string strSql)
        {
            try
            {
                SqlCommand SqlComand = new SqlCommand();
                SqlConnection SqlConnect = new SqlConnection(Connection.StrConnection);
                SqlDataAdapter SqlAdapter = new SqlDataAdapter();
                DataSet SqlDataSet = new DataSet();

                SqlConnect.Open();

                if (SqlConnect.State == ConnectionState.Open)
                {
                    SqlComand.CommandType = CommandType.Text;
                    SqlComand.CommandText = strSql;
                    SqlComand.Connection = SqlConnect;
                    SqlComand.CommandTimeout = 120;
                    SqlAdapter.SelectCommand = SqlComand;
                    SqlAdapter.Fill(SqlDataSet);
                }
                SqlConnect.Close();
                return SqlDataSet;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Ejecuta Stored Procedures
        /// </summary>
        /// <param name="nameSP"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public DataTable ExecuteSP(string nameSP, SqlParameter[] param)
        {
            SqlCommand SqlComand = new SqlCommand();
            SqlConnection SqlConnect = new SqlConnection(Connection.StrConnection);
            SqlDataAdapter SqlAdapter = new SqlDataAdapter();
            DataSet SqlDataSet = new DataSet();
                
            try
            {
                SqlConnect.Open();
                if (SqlConnect.State == ConnectionState.Open)
                {
                    SqlComand.CommandType = CommandType.StoredProcedure;
                    SqlComand.CommandText = nameSP;
                    SqlComand.Connection = SqlConnect;
                    SqlComand.CommandTimeout = 120;
                    SqlComand.Parameters.AddRange(param);
                            
                    SqlAdapter.SelectCommand = SqlComand;
                    SqlAdapter.Fill(SqlDataSet);
                }
                return SqlDataSet.Tables[0];
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                SqlConnect.Close();
            }
        }

        /// <summary>
        /// Ejecuta Stored Procedures
        /// </summary>
        /// <param name="nameSP"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public DataTable ExecuteSP(string nameSP, SqlParameter param)
        {
            SqlCommand SqlComand = new SqlCommand();
            SqlConnection SqlConnect = new SqlConnection(Connection.StrConnection);
            SqlDataAdapter SqlAdapter = new SqlDataAdapter();
            DataSet SqlDataSet = new DataSet();

            try
            {
                SqlConnect.Open();
                if (SqlConnect.State == ConnectionState.Open)
                {
                    SqlComand.CommandType = CommandType.StoredProcedure;
                    SqlComand.CommandText = nameSP;
                    SqlComand.Connection = SqlConnect;
                    SqlComand.CommandTimeout = 120;
                    SqlComand.Parameters.Add(param);

                    SqlAdapter.SelectCommand = SqlComand;
                    SqlAdapter.Fill(SqlDataSet);
                }
                return SqlDataSet.Tables[0];
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                SqlConnect.Close();
            }
        }

        /// <summary>
        /// Ejecuta Stored Procedures
        /// </summary>
        /// <param name="nameSP"></param>
        /// <returns></returns>
        public DataTable ExecuteSP(string nameSP)
        {
            SqlCommand SqlComand = new SqlCommand();
            SqlConnection SqlConnect = new SqlConnection(Connection.StrConnection);
            SqlDataAdapter SqlAdapter = new SqlDataAdapter();
            DataSet SqlDataSet = new DataSet();

            try
            {
                SqlConnect.Open();
                if (SqlConnect.State == ConnectionState.Open)
                {
                    SqlComand.CommandType = CommandType.StoredProcedure;
                    SqlComand.CommandText = nameSP;
                    SqlComand.Connection = SqlConnect;
                    SqlComand.CommandTimeout = 120;

                    SqlAdapter.SelectCommand = SqlComand;
                    SqlAdapter.Fill(SqlDataSet);
                }
                return SqlDataSet.Tables[0];
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                SqlConnect.Close();
            }
        }

        public class Transaction
        {
            SqlCommand SqlComand = new SqlCommand();
            SqlTransaction SqlTrans;
            SqlConnection SqlConnect;

            public Transaction(string Connection)
            {
                SqlConnect = new SqlConnection(Connection);
                SqlConnect.Open();

                if (SqlConnect.State == ConnectionState.Open)
                {
                    SqlTrans = SqlConnect.BeginTransaction();
                    SqlComand.Connection = SqlConnect;
                    SqlComand.Transaction = SqlTrans;
                    SqlComand.CommandType = CommandType.Text;
                }
                else
                    throw new Exception("Cannot open database connection.");
            }

            public void Execute(string query)
            {
                SqlComand.CommandText = query;
                SqlComand.ExecuteNonQuery();
            }

            public void Commit()
            {
                try
                {
                    SqlTrans.Commit();
                }
                catch (Exception ex)
                {
                    SqlTrans.Rollback();
                    throw ex;
                }
                finally
                {
                    SqlConnect.Close();
                }
            }
        }

        public class ConnectionInfo
        {
            private string m_StrConnecion = string.Empty;
            private string m_DataSource = string.Empty;
            private string m_Catalog = string.Empty;
            private string m_PersistSecurity = "False";
            private string m_User = string.Empty;
            private string m_Pass = string.Empty;

            public string StrConnection
            {
                get
                {
                    if (m_StrConnecion == string.Empty)
                        BuildConnection();

                    return m_StrConnecion;
                }
                set { m_StrConnecion = value; }
            }

            public string InitialCatalog
            {
                get { return m_Catalog; }
                set { m_Catalog = value; }
            }

            public string DataSource
            {
                get { return m_DataSource; }
                set { m_DataSource = value; }
            }

            public bool PersisteSecurity
            {
                get { return bool.Parse(m_PersistSecurity); }
                set { m_PersistSecurity = value.ToString(); }
            }

            public string User
            {
                get { return m_User; }
                set { m_User = value; }
            }

            public string Password
            {
                get { return m_Pass; }
                set { m_Pass = value; }
            }

            private void BuildConnection()
            {
                    
                m_StrConnecion = "Data Source=" + m_DataSource + ";";
                m_StrConnecion += "Initial Catalog=" + m_Catalog + ";";

                if (m_User != string.Empty)
                    m_StrConnecion += "User Id=" + m_User + ";";

                if (m_Pass != string.Empty)
                    m_StrConnecion += "Password=" + m_Pass + ";";

                if (string.IsNullOrWhiteSpace(m_User) && string.IsNullOrWhiteSpace(m_Pass))
                    m_StrConnecion += "integrated security=True;";

                //m_StrConnecion += "Persist Security Info=" + m_PersistSecurity + ";";
            }
        }
    }
}
