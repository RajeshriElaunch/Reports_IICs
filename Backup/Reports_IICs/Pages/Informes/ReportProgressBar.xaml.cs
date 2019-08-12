using System.Windows;

namespace Reports_IICs.Pages.Informes
{
    /// <summary>
    /// Lógica de interacción para ProgressBar.xaml
    /// </summary>
    public partial class ReportProgressBar 
    {

        #region dependency property

        public static readonly DependencyProperty IsLoadingProperty =
            DependencyProperty.Register("IsLoading", typeof(bool), typeof(ReportProgressBar), new UIPropertyMetadata(false));

        public static readonly DependencyProperty MessageProperty =
            DependencyProperty.Register("Message", typeof(string), typeof(ReportProgressBar), new UIPropertyMetadata("Loading..."));

        public static readonly DependencyProperty SubMessageProperty =
            DependencyProperty.Register("SubMessage", typeof(string), typeof(ReportProgressBar), new UIPropertyMetadata(string.Empty));

        #endregion

        #region constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="LoadingPanel"/> class.
        /// </summary>
        public ReportProgressBar()
        {
            InitializeComponent();
        }
        #endregion

        #region public properties

        /// <summary>
        /// Gets or sets a value indicating whether this instance is loading.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is loading; otherwise, <c>false</c>.
        /// </value>
        public bool IsLoading
        {
            get { return (bool)GetValue(IsLoadingProperty); }
            set { SetValue(IsLoadingProperty, value); }
        }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>The message.</value>
        public string Message
        {
            get { return (string)GetValue(MessageProperty); }
            set { SetValue(MessageProperty, value); }
        }

        /// <summary>
        /// Gets or sets the sub message.
        /// </summary>
        /// <value>The sub message.</value>
        public string SubMessage
        {
            get { return (string)GetValue(SubMessageProperty); }
            set { SetValue(SubMessageProperty, value); }
        }

        #endregion
    }
}
