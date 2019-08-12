using System;
using System.Windows;
using System.ComponentModel;
using System.Threading;
using System.Windows.Threading;
using MahApps.Metro.Controls;
using System.Data.Entity.Validation;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using Reports_IICs.DataAccess;
using Reports_IICs.Resources;

namespace Reports_IICs.Pages.Informes.ProgressDialog
{
    /// <summary>
    /// Lógica de interacción para ProgressDialog.xaml
    /// </summary>
    public partial class ProgressDialog : MetroWindow
    {
        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static ProgressDialogContext Current { get; set; }

        volatile bool _isBusy;
        BackgroundWorker _worker;

        public string Label
        {
            get { return TextLabel.Text; }
            set { TextLabel.Text = value; }
        }

        public string SubLabel
        {
            get { return SubTextLabel.Text; }
            set { SubTextLabel.Text = value; }
        }

        internal ProgressDialogResult Result { get; private set; }

        public ProgressDialog(ProgressDialogSettings settings)
        {
            InitializeComponent();

            if (settings == null)
                settings = ProgressDialogSettings.WithLabelOnly;

            if (settings.ShowSubLabel)
            {
                Height = 140;
                MinHeight = 140;
                SubTextLabel.Visibility = Visibility.Visible;
            }
            else
            {
                Height = 110;
                MinHeight = 110;
                SubTextLabel.Visibility = Visibility.Collapsed;
            }

            CancelButton.Visibility = settings.ShowCancelButton ? Visibility.Visible : Visibility.Collapsed;

            ProgressBar.IsIndeterminate = settings.ShowProgressBarIndeterminate;
        }

        internal ProgressDialogResult Execute(object operation, string codigoIC = null, DateTime? fechaInforme = null)
        {
            try
            {
                string msgError = null;
                Exception exc = null;
                if (operation == null)
                    throw new ArgumentNullException("operation");

                ProgressDialogResult result = null;

                _isBusy = true;

                _worker = new BackgroundWorker();
                _worker.WorkerReportsProgress = true;
                _worker.WorkerSupportsCancellation = true;

                _worker.DoWork +=
                    (s, e) =>
                    {

                        try
                        {
                            ProgressDialog.Current = new ProgressDialogContext(s as BackgroundWorker, e as DoWorkEventArgs);

                            if (operation is Action)
                            {

                                ((Action)operation)();

                            }

                            else if (operation is Func<object>)
                                e.Result = ((Func<object>)operation)();
                            else
                                throw new InvalidOperationException("Operation type is not supoorted");

                        // NOTE: Always do this check in order to avoid default processing after the Cancel button has been pressed.
                        // This call will set the Cancelled flag on the result structure.
                        ProgressDialog.Current.CheckCancellationPending();
                        }
                        catch (ProgressDialogCancellationExcpetion ex)
                        {
                            msgError = ex.Message;
                            exc = ex;
                            //Siempre que se captura una excepción se debe realizar un rethrow de la excepción para no perder la 
                            //trazabilidad del error y no se debe realizar un throw de la excepción capturada
                            Log.Error("Error ProgressDialog/Execute", ex);
                            // Compliance                                           
                            throw;
                            //throw ex;
                        }
                        catch (DbEntityValidationException ex)
                        {
                            msgError = ex.Message;
                            exc = ex;
                            //Siempre que se captura una excepción se debe realizar un rethrow de la excepción para no perder la 
                            //trazabilidad del error y no se debe realizar un throw de la excepción capturada
                            Log.Error("Error ProgressDialog/Execute", ex);
                            // Compliance                                           
                            throw;
                            //throw ex;
                        }
                        catch (DbUpdateException ex)
                        {
                            msgError = ex.Message;
                            exc = ex;
                        //comprobamos en qué tabla/s se está produciendo el error
                        var entidades = ex.Entries;
                            throw ex;
                        }
                        catch (SqlException ex)
                        {
                            exc = ex;
                            if (ex.HResult == -2146232060)
                            {
                                msgError = Resource.ErrorConexion;
                                throw new Exception(Resource.ErrorConexion, ex);
                            }
                            else
                            {
                                msgError = ex.Message;
                            }

                            //Siempre que se captura una excepción se debe realizar un rethrow de la excepción para no perder la 
                            //trazabilidad del error y no se debe realizar un throw de la excepción capturada
                            Log.Error("Error ProgressDialog/Execute", ex);
                            // Compliance                                           
                            throw;
                            //throw ex;
                        }
                        catch (Exception ex)
                        {
                            exc = ex;
                            if (!ProgressDialog.Current.CheckCancellationPending())
                            {
                                if (exc.InnerException != null && !string.IsNullOrEmpty(exc.InnerException.Message))
                                {
                                    msgError = string.Format("{0}{1}{2}", exc.Message, Environment.NewLine, exc.InnerException.Message);
                                    //Siempre que se captura una excepción se debe realizar un rethrow de la excepción para no perder la 
                                    //trazabilidad del error y no se debe realizar un throw de la excepción capturada
                                    Log.Error("Error ProgressDialog/Execute", exc);
                                    // Compliance                                           
                                    throw;
                                }
                                else
                                {
                                    if (ex.HResult == -2146232060 || ex.HResult == -2146233088)
                                    {
                                        msgError = Resource.ErrorConexion;
                                        //Siempre que se captura una excepción se debe realizar un rethrow de la excepción para no perder la 
                                        //trazabilidad del error y no se debe realizar un throw de la excepción capturada
                                        Log.Error("Error ProgressDialog/Execute", ex);
                                        // Compliance                                           
                                        throw;
                                        //throw new Exception(Resource.ErrorConexion, ex);
                                        //Telerik.Windows.Controls.RadWindow.Alert(new Telerik.Windows.Controls.DialogParameters { Content = "Se ha producido un error de conexión con la base de datos", Header = "Error:" });
                                    }
                                    else if (ex.HResult == -2146232004)
                                    {
                                        msgError = ex.InnerException.Message;
                                        //Siempre que se captura una excepción se debe realizar un rethrow de la excepción para no perder la 
                                        //trazabilidad del error y no se debe realizar un throw de la excepción capturada
                                        Log.Error("Error ProgressDialog/Execute", ex);
                                        // Compliance                                           
                                        throw;
                                        //throw new Exception(ex.InnerException.Message, ex);
                                    }
                                    else
                                    {
                                        //Telerik.Windows.Controls.RadWindow.Alert(new Telerik.Windows.Controls.DialogParameters { Content = ex.Message, Header = "Error:" });                                
                                        msgError = ex.Message;
                                        //Siempre que se captura una excepción se debe realizar un rethrow de la excepción para no perder la 
                                        //trazabilidad del error y no se debe realizar un throw de la excepción capturada
                                        Log.Error("Error ProgressDialog/Execute", ex);
                                        // Compliance                                           
                                        throw;
                                        //throw ex;
                                        //result.OperationFailed = true;
                                    }
                                }
                            }

                            if (string.IsNullOrEmpty(msgError))
                                msgError = ex.Message;
                        }
                        finally
                        {
                            //if (!string.IsNullOrEmpty(msgError))
                            //{
                            //    //Guardamos el error en la BD
                            //    Errores_DA.InsertError(exc, msgError, codigoIC, fechaInforme);
                            //    //no continuamos
                            //    throw new InvalidOperationException(msgError);
                            //}
                            ProgressDialog.Current = null;
                        }

                    };

                _worker.RunWorkerCompleted +=
                    (s, e) =>
                    {


                        result = new ProgressDialogResult(e);

                        Dispatcher.BeginInvoke(DispatcherPriority.Send, (SendOrPostCallback)delegate
                        {
                            _isBusy = false;
                            Close();
                        }, null);

                    };

                _worker.ProgressChanged +=
                    (s, e) =>
                    {

                        if (!_worker.CancellationPending)
                        {
                            SubLabel = (e.UserState as string) ?? string.Empty;
                            ProgressBar.Value = e.ProgressPercentage;
                        }

                    };

                _worker.RunWorkerAsync();

                ShowDialog();                

                return result;
            }
            catch(Exception ex)
            {
                //return null;
                //Siempre que se captura una excepción se debe realizar un rethrow de la excepción para no perder la 
                //trazabilidad del error y no se debe realizar un throw de la excepción capturada
                Log.Error("Error ProgressDialog/Execute", ex);
                // Compliance                                           
                throw;
            }
        }

        void OnCancelButtonClick(object sender, RoutedEventArgs e)
        {
            if (_worker != null && _worker.WorkerSupportsCancellation)
            {
                SubLabel = "Please wait while process will be cancelled...";
                CancelButton.IsEnabled = false;
                _worker.CancelAsync();
            }
        }

        void OnClosing(object sender, CancelEventArgs e)
        {
            e.Cancel = _isBusy;
        }

        internal static ProgressDialogResult Execute(Window owner, string label, Action operation, string codigoIC = null, DateTime? fechaInforme = null)
        {
            return ExecuteInternal(owner, label, (object)operation, null, codigoIC, fechaInforme);
        }

        internal static ProgressDialogResult Execute(Window owner, string label, Action operation, ProgressDialogSettings settings, string codigoIC = null, DateTime? fechaInforme = null)
        {
            return ExecuteInternal(owner, label, (object)operation, settings, codigoIC, fechaInforme);
        }

        internal static ProgressDialogResult Execute(Window owner, string label, Func<object> operationWithResult, string codigoIC = null, DateTime? fechaInforme = null)
        {
            return ExecuteInternal(owner, label, (object)operationWithResult, null, codigoIC, fechaInforme);
        }

        internal static ProgressDialogResult Execute(Window owner, string label, Func<object> operationWithResult, ProgressDialogSettings settings, string codigoIC = null, DateTime? fechaInforme = null)
        {
            return ExecuteInternal(owner, label, (object)operationWithResult, settings, codigoIC, fechaInforme);
        }

        internal static void Execute(Window owner, string label, Action operation, Action<ProgressDialogResult> successOperation, string codigoIC = null, DateTime? fechaInforme = null, Action<ProgressDialogResult> failureOperation = null, Action<ProgressDialogResult> cancelledOperation = null)
        {
            ProgressDialogResult result = ExecuteInternal(owner, label, operation, null, codigoIC, fechaInforme);

            if (result.Cancelled && cancelledOperation != null)
                cancelledOperation(result);
            else if (result.OperationFailed && failureOperation != null)
                failureOperation(result);
            else if (successOperation != null)
                successOperation(result);
        }

        internal static ProgressDialogResult ExecuteInternal(Window owner, string label, object operation, ProgressDialogSettings settings, string codigoIC = null, DateTime? fechaInforme = null)
        {
            ProgressDialog dialog = new ProgressDialog(settings);
            dialog.Owner = owner;

            if (!string.IsNullOrEmpty(label))
                dialog.Label = label;

            return dialog.Execute(operation, codigoIC, fechaInforme);
        }
    }
}
