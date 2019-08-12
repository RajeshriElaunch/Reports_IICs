using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Odbc;
using System.Data;

namespace Core.DataAccess
{
    public class BaseODBC : IDAL
    {
        public string ConnectionString = "DSN=AS400PACHECO;SYSTEM=PACHECO;UID=SARTOW1;DBQ=QGPL BPCSDBF;DFTPKGLIB=QGPL;LANGUAGEID=ENU;PKG=QGPL/DEFAULT(IBM),2,0,1,0,512;DATABASE=BPCSDBF;CMT=1;XDYNAMIC=0;TRANSLATE=1;LAZYCLOSE=1;LIBVIEW=1;PREFETCH=1;SIGNON=1;COMPRESSION=0;MAXFIELDLEN=15360;TRACE=1;DEBUG=64;"; // "DSN=AS400PACHECO;SYSTEM=PACHECO;UID=SARTOW1;DBQ=QGPL BPCSDBF;DFTPKGLIB=QGPL;LANGUAGEID=ENU;PKG=QGPL/DEFAULT(IBM),2,0,1,0,512;DATABASE=BPCSDBF;DESC=Origen de datos de Client Access Express ODBC;CMT=1;XDYNAMIC=0;TRANSLATE=1;LAZYCLOSE=1;LIBVIEW=1;PREFETCH=1;SIGNON=1;COMPRESSION=0;MAXFIELDLEN=15360;TRACE=1;DEBUG=64;";
            
        public DataSet GetData(string strSql)
        {
            try
            {
                OdbcCommand cmd = new OdbcCommand();
                OdbcConnection con = new OdbcConnection(ConnectionString); 
                                                            
                OdbcDataAdapter da = new OdbcDataAdapter();
                DataSet ds = new DataSet();

                con.Open();

                if (con.State == ConnectionState.Open)
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = strSql;
                    cmd.Connection = con;
                    cmd.CommandTimeout = 0;
                    da.SelectCommand = cmd;
                    da.Fill(ds);
                }
                con.Close();
                return ds;
            }
            catch (OdbcException ex)
            {
                throw ex;
            }
        }

        public void Execute(string strSql)
        { 
            
        }

        public bool TryOpen()
        {
            OdbcConnection con = new OdbcConnection(ConnectionString);
            bool result;

            con.Open();

            result = (con.State == ConnectionState.Open);

            con.Close();
            con.Dispose();
            return result;
        }
    }
}
