using Reports_IICs.Pages.Informes.HelperClasses;

namespace Reports_IICs.Pages.Informes.Manager 
{
    class LoadingPanelManager : ViewModelBase
    {
        #region instance variables

        public static readonly LoadingPanelManager Instance = new LoadingPanelManager();

        private bool _isLoading;
        private string _mainMessage;
        private string _subMessage;

        #endregion

        #region constructors

        private LoadingPanelManager()
        {
        }

        #endregion

        #region properties

        public bool IsLoading
        {
            get { return _isLoading; }
            set { SetValue(ref _isLoading, value, "IsLoading"); }
        }

        public string MainMessage
        {
            get { return _mainMessage; }
            set { SetValue(ref _mainMessage, value, "MainMessage"); }
        }

        public string SubMessage
        {
            get { return _subMessage; }
            set { SetValue(ref _subMessage, value, "SubMessage"); }
        }

        #endregion

        #region public methods

        public void Show(string mainMessage, string subMessage)
        {
            MainMessage = mainMessage;
            SubMessage = subMessage;
            IsLoading = true;
        }

        #endregion
    }
}
