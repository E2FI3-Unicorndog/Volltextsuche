using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Volltextsuche.Models;

namespace Volltextsuche.ViewModels
{
    public class LogicalDriveViewModel : BaseViewModel
    {
        #region Variables

        private bool _isSelected, _isExpanded, _isEnabled;
        private bool _isParentSelected = false;
        private readonly string _path;
        private int _count = -1;
        private ObservableCollection<LogicalDriveViewModel> _drives;

        #endregion

        public LogicalDriveViewModel(string name)
        {
            _path = name;
        }

        public LogicalDriveViewModel(string name, bool isParentSelected) : this(name)
        {
            _isParentSelected = isParentSelected;
        }

        #region Properties

        public ObservableCollection<LogicalDriveViewModel> PSubdrives
        {
            get => _drives;
            set
            {
                _drives = value;
                NotifyOnPropertyChanged("PSubdrives");
            }
        }

        public bool PIsSelected
        {
            get => _isSelected;
            set
            {
                _isSelected = value;
                if (PSubdrives != null)
                {
                    foreach (LogicalDriveViewModel subdrive in PSubdrives)
                    {
                        subdrive.PIsParentSelected = value;
                    }
                }
                NotifyOnPropertyChanged("PIsSelected");
            }
        }

        public bool PIsEnabled
        {
            get {
                if (_isParentSelected) return false;
                else if (_count > 0) return _isEnabled;
                else return false;
            }
            set
            {
                _isEnabled = value;
                NotifyOnPropertyChanged("PIsEnabled");
            }
        }

        public bool PIsParentSelected
        {
            get => _isParentSelected;
            set
            {
                _isParentSelected = value;
                NotifyOnPropertyChanged("PIsEnabled");
            }
        }

        public bool PIsExpanded
        {
            get => _isExpanded;
            set
            {
                _isExpanded = value;
                if (PSubdrives == null)
                {
                    PSubdrives = DriveHandler.GetDrives(PPath, true, PIsSelected);
                    DriveHandler.StartFileCount(PSubdrives);
                }
                NotifyOnPropertyChanged("PIsExpanded");
            }
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
                    PIsEnabled = _count > 0;
                }));
            }
        }

        #endregion

    }
}
