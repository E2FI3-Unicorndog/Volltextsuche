using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Threading;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using CommandHelper;
using Volltextsuche.Models;

namespace Volltextsuche.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        #region Variables

        private bool _isMenuOpen, _isWindowMaximized, _resultsReady, _isSearching;
        private List<string> _fileMatches;
        private WindowState _windowState;
        private string _searchKeyword;
        private readonly ObservableCollection<LogicalDriveViewModel> _drives;
        public LogicalDriveViewModel _searchPath;

        #endregion

        #region Main

        public MainViewModel()
        {
            _drives = DriveHandler.GetLogicalDrives();
            InitDrives();
        }

        private void InitDrives()
        {
            foreach (LogicalDriveViewModel drive in PDrives)
            {
                drive.SubdrivesLoaded += Register4DriveEvents;
                drive.PathSelectedChanged += SetSelectedPath;
            }
            DriveHandler.StartFileCount(PDrives);
        }

        private void Register4DriveEvents(LogicalDriveViewModel drive)
        {
            foreach (LogicalDriveViewModel subdrive in drive.PSubdrives)
            {
                subdrive.SubdrivesLoaded += Register4DriveEvents;
                subdrive.PathSelectedChanged += SetSelectedPath;
            }
        }

        private void SetSelectedPath(LogicalDriveViewModel drive)
        {
            if (drive.PIsSelected)
            {
                PSearchPath = drive;
                EnableDrivesRecursive(false, PDrives);
            }
            else
            {
                PSearchPath = null;
                EnableDrivesRecursive(true, PDrives);
            }
        }

        private void EnableDrivesRecursive(bool enable, ObservableCollection<LogicalDriveViewModel> driveCollection)
        {
            foreach (LogicalDriveViewModel drive in driveCollection)
            {
                drive.PIsOtherPathSelected = !enable;
                if (drive.PSubdrives != null) EnableDrivesRecursive(enable, drive.PSubdrives);
            }
        }

        private void CloseApp()
        {
            Application.Current.Shutdown();
        }

        private void MinimizeWindow()
        {
            PWindowState = WindowState.Minimized;
        }

        private void StartFulltextSearch()
        {
            PIsSearching = !PIsSearching;
        }

        #endregion

        #region Properties

        public ObservableCollection<LogicalDriveViewModel> PDrives
        {
            get => _drives;
        }

        public bool PIsMenuOpen
        {
            get { return _isMenuOpen; }
            set
            {
                _isMenuOpen = value;
                NotifyOnPropertyChanged("PIsMenuOpen");
            }
        }

        public WindowState PWindowState
        {
            get
            { return _windowState; }
            set
            {
                if (_windowState != value)
                {
                    _windowState = value;
                    NotifyOnPropertyChanged("PWindowState");
                }
            }
        }

        public bool PIsMaximized
        {
            get
            { return _isWindowMaximized; }
            set
            {
                if (_isWindowMaximized != value)
                {
                    _isWindowMaximized = value;
                    if (value) PWindowState = WindowState.Maximized;
                    else PWindowState = WindowState.Normal;
                    NotifyOnPropertyChanged("PIsMaximized");
                }
            }
        }

        public List<string> PFileMatches
        {
            get { return _fileMatches; }
            set
            {
                _fileMatches = value;
                NotifyOnPropertyChanged("PFileMatches");
            }
        }

        public string[] PDirectories
        {
            get { return Directory.GetLogicalDrives(); }
        }

        public LogicalDriveViewModel PSearchPath
        {
            get => _searchPath;
            set
            {
                _searchPath = value;
                NotifyOnPropertyChanged("PSearchPath");
            }
        }

        public string PSearchKeyword
        {
            get => _searchKeyword;
            set
            {
                _searchKeyword = value;
                NotifyOnPropertyChanged("PSearchKeyword");
            }
        }

        public bool PResultsReady
        {
            get => _resultsReady;
            set
            {
                _resultsReady = value;
                NotifyOnPropertyChanged("PResultsReady");
            }
        }

        public bool PIsSearching
        {
            get => _isSearching;
            set
            {
                _isSearching = value;
                NotifyOnPropertyChanged("PIsSearching");
            }
        }

        #endregion

        #region Commands

        public ICommand CmdClose
        {
            get => new RelayCommand(o => CloseApp());         
        }

        public ICommand CmdMinimize
        {
            get => new RelayCommand(o => MinimizeWindow());          
        }

        public ICommand CmdSearch
        {
            get => new RelayCommand(o => StartFulltextSearch());
        }

        #endregion
    }
}
