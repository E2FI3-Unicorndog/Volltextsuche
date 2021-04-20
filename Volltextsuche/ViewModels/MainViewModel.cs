using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using CommandHelper;

namespace Volltextsuche.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        #region Variables

        #endregion

        #region Main

        public MainViewModel(){}

        #endregion

        #region Properties


        #endregion

        #region Events

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region EventHandler

        private void NotifyOnPropertyChanged(string propName)
        {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        #endregion

        #region Commands

        #endregion
    }
}
