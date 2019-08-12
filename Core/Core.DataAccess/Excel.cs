using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data;

namespace Core.DataAccess
{
    public class Excel : BaseOLE
    {
        public Excel()
        {
            Connection.Provider = "Microsoft.ACE.OLEDB.12.0";
            Connection.PersisteSecurity = false;
            Connection.Extra = "Extended Properties=\"Excel 12.0 Xml;HDR=YES\"";
        }

        public void ExportToFile(System.Data.DataTable dt, string FilePath)
        {
            Connection.DataSource = FilePath;
                
            string TableName = "Data_Export";
            Execute("CREATE TABLE [" + TableName + "] (Numero INT)");

            QueryBuilder.Insert qbI = new QueryBuilder.Insert();
            QueryBuilder.Item item;
            qbI.Table = "[" + TableName + "$]";

            foreach(System.Data.DataRow dr in dt.Rows)
            {
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    item = new QueryBuilder.Item("[" + dt.Columns[i].ColumnName + "]", typeof(string), false, dr[i].ToString().Trim());
                    qbI.Items.Add(item);
                }

                Execute(qbI.GetQuery());
                qbI.ClearItems();
            }
        }

        public IList<string> GetSheets()
        {
            try
            {
                List<string> result = new List<string>();

                using (OleDbConnection olecon = new OleDbConnection(Connection.StrConnection))
                {
                    olecon.Open();
                    if (olecon.State == ConnectionState.Open)
                    {
                        DataTable dt = olecon.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
                        olecon.Close();

                        foreach (DataRow dr in dt.Rows)
                            result.Add(dr["TABLE_NAME"].ToString());
                    }
                }

                return result;
            }
            catch (OleDbException ex)
            {
                throw ex;
            }
        }
    }
}
