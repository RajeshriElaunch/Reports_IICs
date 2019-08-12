using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data.SqlClient;


namespace Core.DataAccess
{
    public class SqlExecScript
    {
        public void TODO()
        {
            string sqlConnectionString = "Data Source=(local);Initial Catalog=AdventureWorks;Integrated Security=True";
            FileInfo file = new FileInfo("C:\\myscript.sql");
            string script = file.OpenText().ReadToEnd();
            SqlConnection conn = new SqlConnection(sqlConnectionString);
            //Server server = new Server(new Microsoft.SqlServer.Management.Common.ServerConnection(conn));
            //server.ConnectionContext.ExecuteNonQuery(script);
        }

    }
}
