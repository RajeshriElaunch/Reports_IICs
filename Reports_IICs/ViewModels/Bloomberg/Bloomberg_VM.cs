using Reports_IICs.DataAccess.Bloomberg;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Reports_IICs.ViewModels.Bloomberg
{
    public class Bloomberg_VM
    {
        public static void GuardarBloomberg(DataTable dt, int año, int columnaEstimacion)
        {
            try
            {
                ImportarBloomberg_DA.GuardarBloomberg(dt, año, columnaEstimacion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public static void ComprobarDatosValidos(ref bool tieneDatos, DataTable dt, ref List<Tuple<string, string>> errores, int? columnaEstimacion, int? año)
        {
            //Registro de errores de validación. Guardamos todos los valores erróneos para mostrar de una sóla vez al usuario
            //En el primer string almacenamos el nombre de la columna y en el segundo el valor a corregir

            validarIsins(ref tieneDatos, dt, ref errores);
            if (tieneDatos)
            {
                validarAño(año, ref errores);
                validarColumnaEstimacion(columnaEstimacion, ref errores);
                validarRestoCampos(dt, ref errores);
            }
        }

        private static void validarIsins(ref bool tieneDatos, DataTable dt, ref List<Tuple<string, string>> errores)
        {
            //Recuperamos los distintos valores de la columna "Isin"
            DataView view = new DataView(dt);
            string nombreCol = "Isin";
            DataTable dtDistinct = view.ToTable(true, nombreCol);
            DataRow[] filasBlanco = dtDistinct.Select("Isin IS NULL OR Isin =''");
            //Si tiene algún ISIN en blanco lo guardamos en el registro de avisos
            if (filasBlanco.Count() > 0)
            {
                errores.Add(Tuple.Create(nombreCol, "Este campo es obligatorio."));
            }

            DataRow[] filasRellenas = dtDistinct.Select("Isin IS NOT NULL AND Isin <> ''");
            //Si tiene alguna fila con ISIN lo marcamos como que tiene datos
            if (filasRellenas.Count() > 0)
            {
                tieneDatos = true;
            }
           
            var duplicates = filasRellenas.GroupBy(r => r.ItemArray[0].ToString().ToLower()).Where(gr => gr.Count() > 1); //dtDistinct.AsEnumerable().GroupBy(r => r[0]).Where(gr => gr.Count() > 1);
            if (duplicates.Any())
            {
                string isinsDuplicados = String.Join(", ", duplicates.Select(dupl => dupl.Key));
                errores.Add(Tuple.Create(nombreCol, "Se han encontrado Isins repetidos en el documento: " + isinsDuplicados));
            }
        }

        private static void validarAño(int? año, ref List<Tuple<string, string>> errores)
        {
            if(año == null)
            {
                errores.Add(Tuple.Create("Año", "El año introducido no es válido."));
            }
        }

        private static void validarColumnaEstimacion(int? columnaEstimacion, ref List<Tuple<string, string>> errores)
        {
            if (columnaEstimacion == null)
            {
                errores.Add(Tuple.Create("Columna estimación", "El valor 'Columna estimación' no es válido."));
            }
        }

        private static void validarRestoCampos(DataTable dt, ref List<Tuple<string, string>> errores)
        {
            foreach (DataRow dr in dt.Rows)
            {
                //decimal valor;

                string cellValue = string.Empty;
                /*
                cellValue = dr["Capitalización"].ToString();
                if (!Decimal.TryParse(cellValue, out valor) && !string.IsNullOrEmpty(cellValue))
                {
                    errores.Add(Tuple.Create("Capitalización", cellValue));
                }

                cellValue = dr["Bpa"].ToString();
                if (!Decimal.TryParse(cellValue, out valor) && !string.IsNullOrEmpty(cellValue))
                {
                    errores.Add(Tuple.Create("Bpa", cellValue));
                }

                cellValue = dr["Bpa previsión"].ToString();
                if (!Decimal.TryParse(cellValue, out valor) && !string.IsNullOrEmpty(cellValue))
                {
                    errores.Add(Tuple.Create("Bpa previsión", cellValue));
                }

                cellValue = dr["Rentabilidad"].ToString();
                if (!Decimal.TryParse(cellValue, out valor) && !string.IsNullOrEmpty(cellValue))
                {
                    errores.Add(Tuple.Create("Rentabilidad", cellValue));
                }

                cellValue = dr["Rentabilidad previsión"].ToString();
                if (!Decimal.TryParse(cellValue, out valor) && !string.IsNullOrEmpty(cellValue))
                {
                    errores.Add(Tuple.Create("Rentabilidad previsión", cellValue));
                }

                cellValue = dr["Per"].ToString();
                if (!Decimal.TryParse(cellValue, out valor) && !string.IsNullOrEmpty(cellValue))
                {
                    errores.Add(Tuple.Create("Per", cellValue));
                }

                cellValue = dr["Per previsión"].ToString();
                if (!Decimal.TryParse(cellValue, out valor) && !string.IsNullOrEmpty(cellValue))
                {
                    errores.Add(Tuple.Create("Per previsión", cellValue));
                }

                cellValue = dr["Deuda neta / capitalización"].ToString();
                if (!Decimal.TryParse(cellValue, out valor) && !string.IsNullOrEmpty(cellValue))
                {
                    errores.Add(Tuple.Create("Deuda neta / capitalización", cellValue));
                }

                cellValue = dr["Precio / VC"].ToString();
                if (!Decimal.TryParse(cellValue, out valor) && !string.IsNullOrEmpty(cellValue))
                {
                    errores.Add(Tuple.Create("Precio / VC", cellValue));
                }

                cellValue = dr["Valor fundamental"].ToString();
                if (!Decimal.TryParse(cellValue, out valor) && !string.IsNullOrEmpty(cellValue))
                {
                    errores.Add(Tuple.Create("Valor fundamental", cellValue));
                }

                cellValue = dr["GVC o Bloomberg"].ToString();
                if (!cellValue.Equals("G") && !cellValue.Equals("B"))
                {
                    errores.Add(Tuple.Create("GVC o Bloomberg", cellValue));
                }

                cellValue = dr["Descuento fundamental"].ToString();
                if (!Decimal.TryParse(cellValue, out valor) && !string.IsNullOrEmpty(cellValue))
                {
                    errores.Add(Tuple.Create("Descuento fundamental", cellValue));
                }*/
            }
        }
    }
}
