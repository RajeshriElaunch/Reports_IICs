using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.IO;
using System.Data;

namespace Core.DataAccess
{
    class SqlBulk
    {
        public void TODO()
        {
            SqlConnection con = new SqlConnection(@"Data Source=SHAWHP\SQLEXPRESS;Initial Catalog=FOO;Persist Security Info=True;User ID=sa");
            string filepath = "C:\\params.csv";
            StreamReader sr = new StreamReader(filepath);
            string line = sr.ReadLine();
            string[] value = line.Split(',');
            DataTable dt = new DataTable();
            DataRow row;
            foreach (string dc in value)
            {
                dt.Columns.Add(new DataColumn(dc));
            }

            while (!sr.EndOfStream)
            {
                value = sr.ReadLine().Split(',');
                if (value.Length == dt.Columns.Count)
                {
                    row = dt.NewRow();
                    row.ItemArray = value;
                    dt.Rows.Add(row);
                }
            }
            SqlBulkCopy bc = new SqlBulkCopy(con.ConnectionString, SqlBulkCopyOptions.TableLock);
            bc.DestinationTableName = "tblparam_test";
            bc.BatchSize = dt.Rows.Count;
            con.Open();
            bc.WriteToServer(dt);
            bc.Close();
            con.Close();
        }
    }
}
