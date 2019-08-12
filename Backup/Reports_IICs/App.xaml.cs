using MahApps.Metro;
using Reports_IICs.Helpers;
using System.Globalization;
using System.Threading;
using System.Windows;
using System.Diagnostics;
using Reports_IICs.Resources;
using System.Windows.Threading;
using System;
using System.Data.Entity.Validation;
using Reports_IICs.DataAccess.Instrumentos;

namespace Reports_IICs
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            //Thread.CurrentThread.CurrentCulture = new CultureInfo("es");
            //Thread.CurrentThread.CurrentUICulture = new CultureInfo("es");

            Thread.CurrentThread.CurrentCulture = new CultureInfo("es-ES");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("es-ES");

            //Variables globales
            // Set an application-scope resource
            Application.Current.Resources["Instrumentos"] = Instrumentos_DA.GetAll();
            Application.Current.Resources["Instrumentos_Tipos"] = InstrumentosTipos_DA.GetAll();
            Application.Current.Resources["Instrumentos_Categorias"] = InstrumentosCategorias_DA.GetAll();
            Application.Current.Resources["Instrumentos_Empresas"] = InstrumentosEmpresas_DA.GetAll();
            Application.Current.Resources["Instrumentos_Importados"] = InstrumentosImportados_DA.GetAll();

            // Get an application-scope resource
            //var instrumentos = (System.Data.Entity.DbSet<Instrumento>)Application.Current.Resources["Instrumentos"];
            //foreach(var instrum in instrumentos)
            //{

            //}

        }

        protected override void OnStartup(StartupEventArgs e)
        {
            #region UnhandledErrors
            Application.Current.DispatcherUnhandledException += CurrentOnDispatcherUnhandledException;
            #endregion UnhandledErrors

            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            string runningVersion = fvi.FileVersion;
            string latestVersion = Utils.GetLatestVersion();

            //Si tiene la última versión arrancamos la aplicación
            if (runningVersion.Equals(latestVersion))
            {

                // get the theme from the current application
                var theme = ThemeManager.DetectAppStyle(Application.Current);

                // now set the Olive accent and BaseLight theme
                ThemeManager.ChangeAppStyle(Application.Current,
                                            ThemeManager.GetAccent("Teal"),
                                            ThemeManager.GetAppTheme("BaseLight"));

                //Iniciar la aplicación en otro idioma cuando sea necesario
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("es-ES");
                //Thread.CurrentThread.CurrentUICulture = new CultureInfo("ca-ES");

                base.OnStartup(e);

                //Cargamos las variables globales
                VariablesGlobales.SetVariablesGlobales();
            }
            else
            {
                Utils.ShowDialog(Resource.UltimaVersion_Message);
                //Telerik.Windows.Controls.RadWindow.Alert(new Telerik.Windows.Controls.DialogParameters { Content = Resource.UltimaVersion_Message, Header = Resource.HeaderGVC_MessageBox });
                //System.Diagnostics.Process.Start("http://www.google.com");
                this.Shutdown();
            }
        }

        private void CurrentOnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs args)
        {
            Exception e = (Exception)args.Exception;

            string mensajeError = Resource.Error_Message + Environment.NewLine;

            try
            {
                throw e;
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string error = validationError.ErrorMessage + " " + validationError.PropertyName;
                        mensajeError += error + Environment.NewLine;
                    }
                }

            }
            catch (Exception ex)
            {
                mensajeError += ex.Message + Environment.NewLine;
                //throw ex;
            }

            //Telerik.Windows.Controls.RadWindow.Alert(new Telerik.Windows.Controls.DialogParameters { Content = new TextBlock { Text = mensajeError, TextWrapping = TextWrapping.Wrap, Width = 400 }, Header = Resource.HeaderGVC_MessageBox });
            Utils.ShowDialog(mensajeError);
            //RadWindow.Alert(new TextBlock { Text = mensajeError, TextWrapping = TextWrapping.Wrap, Width = 400 });

            args.Handled = true;
        }
    }

}
