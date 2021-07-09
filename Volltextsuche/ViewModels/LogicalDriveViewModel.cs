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

        private bool _isSelected, _isExpanded;
        private readonly string _path;
        private int _count = -1;
        private ObservableCollection<LogicalDriveViewModel> _drives;

        #endregion

        public LogicalDriveViewModel(string name)
        {
            _path = name;
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
                //if (PSubdrives == null)
                //{
                //    PSubdrives = DriveHandler.GetDrives(PPath);
                //    DriveHandler.StartFileCount(PSubdrives);
                //}
                //foreach (LogicalDriveViewModel drive in PSubdrives)
                //{
                //    drive.PIsSelected = PIsSelected;
                //}
                NotifyOnPropertyChanged("PIsSelected");
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
                    PSubdrives = DriveHandler.GetDrives(PPath);
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
                }));
            }
        }

        #endregion

    }
}
