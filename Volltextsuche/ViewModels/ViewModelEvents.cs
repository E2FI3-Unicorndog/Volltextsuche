using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Volltextsuche.ViewModels
{
    public delegate void PathSelectedChangedEventHandler(LogicalDriveViewModel selected);
    public delegate void SubdrivesLoadedEventHandler(LogicalDriveViewModel drive);
}
