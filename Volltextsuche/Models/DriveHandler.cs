using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Volltextsuche.ViewModels;

namespace Volltextsuche.Models
{
    public static class DriveHandler
    {
        public static void StartFileCount(ObservableCollection<LogicalDriveViewModel> subdrives)
        {
            BackgroundWorker workerCountDriveFiles = new BackgroundWorker();
            workerCountDriveFiles.DoWork += new DoWorkEventHandler(CountDriveFiles);
            workerCountDriveFiles.RunWorkerAsync(subdrives);
        }

        public static ObservableCollection<LogicalDriveViewModel> GetDrives(string mainPath, bool hasParent = false, bool isParentSelected = false)
        {
            string[] drives;
            ObservableCollection<LogicalDriveViewModel> collection = new ObservableCollection<LogicalDriveViewModel>(); ;
            try
            {
                drives = Directory.GetDirectories(mainPath);
                if (drives.Length > 0)
                {
                    foreach (string path in drives)
                    {
                        if (!hasParent) collection.Add(new LogicalDriveViewModel(path));
                        else collection.Add(new LogicalDriveViewModel(path, isParentSelected));
                    }
                }
            }
            catch { }

            return collection;
        }

        public static ObservableCollection<LogicalDriveViewModel> GetLogicalDrives()
        {
            string[] drives = Directory.GetLogicalDrives();
            ObservableCollection<LogicalDriveViewModel> collection = new ObservableCollection<LogicalDriveViewModel>();
            foreach (string path in drives)
            {
                collection.Add(new LogicalDriveViewModel(path));
            }

            return collection;
        }

        public static void CountDriveFiles(object o, DoWorkEventArgs e)
        {
            ObservableCollection<LogicalDriveViewModel> subdrives = (ObservableCollection<LogicalDriveViewModel>)e.Argument;
            foreach (LogicalDriveViewModel drive in subdrives)
            {
                string filecount = "";
                try { filecount = Directory.GetFiles(drive.PPath, "*.*", SearchOption.AllDirectories).Length.ToString(); }
                catch { }

                Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                {
                    if (filecount != "") drive.PCount = filecount;
                    else drive.OnAccessFailed();
                }));
            }
        }

    }
}
