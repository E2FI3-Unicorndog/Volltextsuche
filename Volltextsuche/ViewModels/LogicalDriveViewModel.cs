using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Volltextsuche.ViewModels
{
    public class LogicalDriveViewModel : BaseViewModel
    {
        #region Variables

        private bool _isSelected;
        private readonly string _path;
        private int _count = -1;

        #endregion

        public LogicalDriveViewModel(string name)
        {
            _path = name;
        }

        #region Properties

        public bool PIsSelected
        {
            get => _isSelected;
            set => _isSelected = value;
        }

        public void OnAccessFailed()
        {
            PCount = "-2";
        }

        public string PPath
        {
            get => _path;
        }

        public string PCount
        {
            get
            {
                if (_count == -1) return $"Berechne Dateianzahl...";
                else if (_count == -2) return "Fehlende Leserechte";
                else return $"Enthält {_count} Dateien";
            }
            set
            {
                _count = Convert.ToInt32(value);
                Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                {
                    NotifyOnPropertyChanged("PCount");
                }));
            }
        }

        #endregion

    }
}
