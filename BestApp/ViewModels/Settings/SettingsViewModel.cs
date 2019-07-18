using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestApp.ViewModels.Settings
{
    public class SettingsViewModel : ViewModelBase
    {
        public ObservableCollection<string> PrinterNames { get; set; }
        public string PrinterName { get; set; }

        public SettingsViewModel()
        {

        }
    }
}
