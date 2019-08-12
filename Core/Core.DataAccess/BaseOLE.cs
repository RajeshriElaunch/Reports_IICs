using System;
using System.Data;
using System.Data.OleDb;

namespace Core.DataAccess
{
    public class BaseOLE : IDAL
    {
        public ConnectionInfo Connection = new ConnectionInfo();

        /// <summary>
        /// Permite ejecutar sentencias SELECT
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        public DataSet GetData(string strSql)
        {
            try
            {
                OleDbCommand olecmd = new OleDbCommand();
                OleDbConnection olecon = new OleDbConnection(Connection.StrConnection);
                OleDbDataAdapter oleda = new OleDbDataAdapter();
                DataSet oleds = new DataSet();

                olecon.Open();

                if (olecon.State == ConnectionState.Open)
                {
                    olecmd.CommandType = CommandType.Text;
                    olecmd.CommandText = strSql;
                    olecmd.Connection = olecon;
                    olecmd.CommandTimeout = 120;
                    oleda.SelectCommand = olecmd;
                    oleda.Fill(oleds);
                }
                olecon.Close();
                return oleds;
            }
            catch (OleDbException ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Permite ejecutar sentencias SELECT
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        public DataTable GetData2(string strSql)
        {
            return GetData(strSql).Tables[0];
        }

        /// <summary>
        /// Permite ejecutar sentencias UPDATE, DELETE, INSERT
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        public void Execute(string strSql)
        {
            try
            {
                OleDbCommand olecmd = new OleDbCommand();
                OleDbConnection olecon = new OleDbConnection(Connection.StrConnection);
                OleDbDataAdapter oleda = new OleDbDataAdapter();
                DataSet oleds = new DataSet();

                olecon.Open();

                if (olecon.State == ConnectionState.Open)
                {
                    olecmd.CommandType = CommandType.Text;
                        olecmd.CommandText = strSql;
                    olecmd.Connection = olecon;
                    olecmd.CommandTimeout = 120;
                    oleda.SelectCommand = olecmd;

                    olecmd.ExecuteNonQuery();
                }
                olecon.Close();
            }
            catch (OleDbException ex)
            {
                throw ex;
            }
        }

        public bool TryOpen()
        {
            OleDbConnection olecon = new OleDbConnection(Connection.StrConnection);
            bool result;

            olecon.Open();
            result = (olecon.State == ConnectionState.Open);

            olecon.Close();
            olecon.Dispose();

            return result;
        }
    }
        
    

    interface IDAL
    {
        void Execute(string a);

        DataSet GetData(string a);
    }

    public class DBF : BaseOLE
    {
        public DBF(string Path)
        {
            // Para que esto funcione es necesario tener instalado Microsoft Visual FoxPro OLE DB Provider
            Connection.DataSource = Path;
            Connection.Provider = "vfpoledb.1";
        }
    }
}
