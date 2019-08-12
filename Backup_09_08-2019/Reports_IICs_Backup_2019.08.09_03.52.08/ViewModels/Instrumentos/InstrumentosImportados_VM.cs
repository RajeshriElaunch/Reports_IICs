using Reports_IICs.DataAccess.Instrumentos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Reports_IICs.ViewModels.Instrumentos
{
    public class InstrumentosImportados_VM
    {
        public static bool GuardarInstrumentosImportados(DataTable dt)
        {
            bool guardado = InstrumentosImportados_DA.GuardarInstrumentoImportado(dt);
            return guardado;
        }

        public static void ComprobarInstrumentosValidos(ref bool tieneDatos, DataTable dt, ref List<Tuple<string, string>> errores)
        {
            //Registro de errores de validación. Guardamos todos los valores erróneos para mostrar de una sóla vez al usuario
            //En el primer string almacenamos el nombre de la columna y en el segundo el valor a corregir

            validarIsins(ref tieneDatos, dt, ref errores);
            if (tieneDatos)
            {
                validarTipos(dt, "Tipo", ref errores);
                validarTipos(dt, "Tipo2", ref errores);
                validarTipos(dt, "Tipo3", ref errores);
                validarSectores(dt, ref errores);
                validarEmergentes(dt, ref errores);
                validarCategorias(dt, ref errores);
                validarEmpresas(dt, ref errores);
                validarInstrumentos(dt, ref errores);
                validarZonas(dt, ref errores);
                validarPaises(dt, ref errores);
            }
        }

        private static void validarIsins(ref bool tieneDatos, DataTable dt, ref List<Tuple<string, string>> errores)
        {
            string nombreCol = "Isin";
            //Comprobamos si hay Isins repetidos
            var duplicates = dt.AsEnumerable().GroupBy(r => r[0]).Where(gr => gr.Count() > 1);
            if (duplicates.Any())
            {
                string isinsDuplicados = String.Join(", ", duplicates.Select(dupl => dupl.Key));
                errores.Add(Tuple.Create(nombreCol, "Se han encontrado Isins repetidos en el documento: " + isinsDuplicados));
            }
                
            //Recuperamos los distintos valores de la columna "Isin"
            DataView view = new DataView(dt);
            
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
        }

        public static void validarTipos(DataTable dt, string nombreCol, ref List<Tuple<string, string>> errores)
        {
            //Recuperamos los distintos valores de la columna "Tipo"
            DataView view = new DataView(dt);
            //string nombreCol = "Tipo";
            DataTable dtDistinct = view.ToTable(true, nombreCol);

            var instrumentosTipos = InstrumentosTipos_DA.GetAll();

            foreach (DataRow dr in dtDistinct.Rows)
            {
                string valor = dr[0].ToString();
                if (!string.IsNullOrEmpty(valor) && !instrumentosTipos.Any(i => i.Codigo == valor))
                {
                    errores.Add(Tuple.Create(nombreCol, valor));
                }
                else
                {
                    dr[0] = null;
                }
            }
        }

        public static void validarSectores(DataTable dt, ref List<Tuple<string, string>> errores)
        {
            //Recuperamos los distintos valores de la columna "Sector"
            DataView view = new DataView(dt);
            string nombreCol = "Sector";
            DataTable dtDistinct = view.ToTable(true, nombreCol);

            var instrumentosSectores = InstrumentosSectores_DA.GetAll();

            foreach (DataRow dr in dtDistinct.Rows)
            {
                string valor = dr[0].ToString();
                if (!string.IsNullOrEmpty(valor) && !instrumentosSectores.Any(i => i.Descripcion == valor))
                {
                    errores.Add(Tuple.Create(nombreCol, valor));
                }
            }
        }

        public static void validarEmergentes(DataTable dt, ref List<Tuple<string, string>> errores)
        {
            //Recuperamos los distintos valores de la columna "Emergente"
            DataView view = new DataView(dt);
            string nombreCol = "Emergente";
            DataTable dtDistinct = view.ToTable(true, nombreCol);

            foreach (DataRow dr in dtDistinct.Rows)
            {
                string valor = dr[0].ToString();
                if (!string.IsNullOrEmpty(valor) && !valor.Equals("Sí") && !valor.Equals("No"))
                {
                    errores.Add(Tuple.Create(nombreCol, valor));
                }
            }
        }

        public static void validarCategorias(DataTable dt, ref List<Tuple<string, string>> errores)
        {
            //Recuperamos los distintos valores de la columna "Categoría"
            DataView view = new DataView(dt);
            string nombreCol = "Categoría";
            DataTable dtDistinct = view.ToTable(true, nombreCol);

            var instrumentosCategorias = InstrumentosCategorias_DA.GetAll();

            foreach (DataRow dr in dtDistinct.Rows)
            {
                string valor = dr[0].ToString();
                if (!string.IsNullOrEmpty(valor) && !instrumentosCategorias.Any(i => i.Codigo == valor))
                {
                    errores.Add(Tuple.Create(nombreCol, valor));
                }
            }
        }

        public static void validarEmpresas(DataTable dt, ref List<Tuple<string, string>> errores)
        {
            //Recuperamos los distintos valores de la columna "Empresa"
            DataView view = new DataView(dt);
            string nombreCol = "Empresa";
            DataTable dtDistinct = view.ToTable(true, nombreCol);

            var instrumentosEmpresas = InstrumentosEmpresas_DA.GetAll();

            foreach (DataRow dr in dtDistinct.Rows)
            {
                string valor = dr[0].ToString();
                if (!string.IsNullOrEmpty(valor) && !instrumentosEmpresas.Any(i => i.Codigo == valor))
                {
                    errores.Add(Tuple.Create(nombreCol, valor));
                }
            }
        }

        public static void validarInstrumentos(DataTable dt, ref List<Tuple<string, string>> errores)
        {
            //Recuperamos los distintos valores de la columna "Instrumento"
            DataView view = new DataView(dt);
            string nombreCol = "Instrumento";
            DataTable dtDistinct = view.ToTable(true, nombreCol);

            var instrumentos = Instrumentos_DA.GetAll();

            foreach (DataRow dr in dtDistinct.Rows)
            {
                string valor = dr[0].ToString();
                if (!string.IsNullOrEmpty(valor) && !instrumentos.Any(i => i.Codigo == valor))
                {
                    errores.Add(Tuple.Create(nombreCol, valor));
                }
            }
        }

        public static void validarZonas(DataTable dt, ref List<Tuple<string, string>> errores)
        {
            //Recuperamos los distintos valores de la columna "Zona"
            DataView view = new DataView(dt);
            string nombreCol = "Zona";
            DataTable dtDistinct = view.ToTable(true, nombreCol);

            var zonas = InstrumentosZonas_DA.GetAll();

            foreach (DataRow dr in dtDistinct.Rows)
            {
                string valor = dr[0].ToString();
                if (!string.IsNullOrEmpty(valor) && !zonas.Any(i => i.Codigo == valor))
                {
                    errores.Add(Tuple.Create(nombreCol, valor));
                }
            }
        }

        public static void validarPaises(DataTable dt, ref List<Tuple<string, string>> errores)
        {
            //Recuperamos los distintos valores de la columna "País"
            DataView view = new DataView(dt);
            string nombreCol = "País";
            DataTable dtDistinct = view.ToTable(true, nombreCol);

            var paises = InstrumentosPaises_DA.GetAll();

            foreach (DataRow dr in dtDistinct.Rows)
            {
                string valor = dr[0].ToString();
                if (!string.IsNullOrEmpty(valor) && !paises.Any(i => i.Codigo == valor))
                {
                    errores.Add(Tuple.Create(nombreCol, valor));
                }
            }
        }
    }
}
