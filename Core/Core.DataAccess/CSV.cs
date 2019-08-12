using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using System.Reflection;

namespace Core.DataAccess
{
        public class CSV : BaseOLE
        {
            private static string SEPARATOR = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ListSeparator;

            public CSV()
            {
                Connection.Provider = "Microsoft.Jet.OLEDB.4.0";
                Connection.PersisteSecurity = false;
                Connection.Extra = "Extended Properties='text;HDR=Yes;FMT=Delimited(,)'";
            }

            public static void ExportToFile(System.Data.DataTable dt, string FilePath, string Separador)
            {
                SEPARATOR = Separador;
                ExportToFile(dt, FilePath);
            }

            public static void ExportToFile(System.Data.DataTable dt, string FilePath)
            { 
                // Create the CSV file to which grid data will be exported.
                StreamWriter sw = new StreamWriter(FilePath, false);

                // First we will write the headers.
                int iColCount = dt.Columns.Count;

                for (int i = 0; i < iColCount; i++)
                {
                    sw.Write(dt.Columns[i].ColumnName);
                    if (i < iColCount - 1)
                        sw.Write(SEPARATOR);
                }
                
                sw.Write(sw.NewLine);

                // Now write all the rows.
                foreach (DataRow dr in dt.Rows)
                {
                    for (int i = 0; i < iColCount; i++)
                    {
                        if (!Convert.IsDBNull(dr[i]))
                            sw.Write(dr[i].ToString().Trim().Replace(SEPARATOR,"").Replace(",","."));

                        if (i < iColCount - 1)
                            sw.Write(SEPARATOR);
                    }
                    sw.Write(sw.NewLine);
                }

                sw.Close();
            }

            public static void ExportToFile(object[] array, string FilePath, string Separador)
            {
                SEPARATOR = Separador;
                ExportToFile(array, FilePath);
            }

            public static void ExportToFile(object[] array, string FilePath)
            {
                // Create the CSV file to which grid data will be exported.
                StreamWriter sw = new StreamWriter(FilePath, false, Encoding.UTF8);
               
                bool IsFisrt = true;

                // First we will write the headers.
                foreach (object o in array)
                {
                    if (IsFisrt)
                    {
                        foreach (PropertyInfo pi in o.GetType().GetProperties())
                        {
                            if (pi.PropertyType.FullName.IndexOf("Linq") == -1 && pi.PropertyType.FullName.IndexOf("Enum_") == -1)
                                sw.Write(pi.Name + SEPARATOR);
                        }

                        IsFisrt = false;
                    }

                    sw.Write(sw.NewLine);

                    // Now write all the rows.
                    foreach (PropertyInfo pi in o.GetType().GetProperties())
                    {
                        if (pi.PropertyType.FullName.IndexOf("Linq") == -1 && pi.PropertyType.FullName.IndexOf("Enum_") == -1)
                        {
                            try
                            {
                                if (pi.GetValue(o, null) != null)
                                    sw.Write(pi.GetValue(o, null).ToString().Trim().Replace(SEPARATOR, ""));
                                else
                                    sw.Write(string.Empty);

                            }
                            catch (Exception ex)
                            {
                                string str = ex.Message;
                            }

                            sw.Write(SEPARATOR);
                        }
                    }
                }

                //Close file
                sw.Close();
            }
        }
}
