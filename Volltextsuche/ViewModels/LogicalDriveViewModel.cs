using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Volltextsuche.ViewModels
{
    public class LogicalDriveViewModel : BaseViewModel
    {
        #region Variables

        private bool _isSelected;
        private readonly string _path;
        private readonly int _count;

        #endregion

        public LogicalDriveViewModel(string name, int count) {
            _path = name;
            _count = count;
        }

        #region Properties

        public bool PIsSelected
        {
            get => _isSelected;
            set => _isSelected = value;
        }

        public string PPath
        {
            get => _path;
        }

        public string PCount
        {
            get => $"Enthält {_count} Dateien";
        }

        #endregion
    }
}
