using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Windows;
using System.Windows.Input;
using CommandHelper;

namespace Volltextsuche.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        #region Variables

        private bool _isMenuOpen, _isWindowMaximized;
        private List<string> _fileMatches;
        private WindowState _windowState;
        private string _basePath, _searchKeyword;
        private readonly ObservableCollection<LogicalDriveViewModel> _drives;

        #endregion

        #region Main

        public MainViewModel()
        {

            _drives = GetDrives();
        }

        private ObservableCollection<LogicalDriveViewModel> GetDrives()
        {
            string[] drives = Directory.GetLogicalDrives();
            ObservableCollection<LogicalDriveViewModel> collection = new ObservableCollection<LogicalDriveViewModel>();
            foreach (string path in drives)
            {
                try
                {
                    collection.Add(new LogicalDriveViewModel(path, Directory.GetFiles(path, "*.*", SearchOption.AllDirectories).Length));
                }
                catch (Exception) { }
            }
            return collection;
        }

        private void CloseApp()
        {
            Application.Current.Shutdown();
        }

        private void MinimizeWindow()
        {
            PWindowState = WindowState.Minimized;
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

        public string PBasePath
        {
            get { return _basePath; }
            set
            {
                _basePath = value;
                NotifyOnPropertyChanged("PBasePath");
            }
        }

        public string PSearchKeyword
        {
            get { return _searchKeyword; }
            set
            {
                _searchKeyword = value;
                NotifyOnPropertyChanged("PSearchKeyword");
            }
        }

        #endregion

        #region Commands

        public ICommand CmdClose
        {
            get
            {
                return new RelayCommand(o => CloseApp());
            }
        }

        public ICommand CmdMinimize
        {
            get
            {
                return new RelayCommand(o => MinimizeWindow());
            }
        }

        #endregion
    }
}
