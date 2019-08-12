using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;

namespace Reports_IICs.Pages.Informes.HelperClasses
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        #region private fields

        private bool _enableChangeNotification = true;

        #endregion

        #region events

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region properties

        public bool EnableChangeNotification
        {
            get { return _enableChangeNotification; }
            set { _enableChangeNotification = value; }
        }

        #endregion

        #region protected methods

        protected void SetValue<T>(ref T field, T value, params string[] propertyNames)
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
            {
                return;
            }

            field = value;

            if (propertyNames.Length <= 0)
            {
                return;
            }

            if (!EnableChangeNotification)
            {
                return;
            }

            foreach (var propertyName in propertyNames)
            {
                OnPropertyChanged(propertyName);
            }
        }

        protected void OnPropertyChanged(string propertyName)
        {
            ValidatePropertyName(propertyName);

            if (EnableChangeNotification)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
            }
        }

        #endregion

        #region private methods

        [Conditional("DEBUG")]
        private void ValidatePropertyName(string propertyName)
        {
            if (TypeDescriptor.GetProperties(this)[propertyName] == null)
            {
                throw new ArgumentException(string.Format("{0} property name doesn't exist.", propertyName));
            }
        }

        #endregion
    }
}
