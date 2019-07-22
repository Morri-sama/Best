using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BestApp.ViewModels.Settings
{
    public class SettingsViewModel : ViewModelBase
    {
        private string _selectedPrinter;

        public List<string> PrinterNames { get; private set; }
        public string SelectedPrinter
        {
            get
            {
                return _selectedPrinter;
            }
            set
            {
                _selectedPrinter = value;
                RaisePropertyChanged("SelectedPrinter");
            }
        }

        public ICommand SaveCommand { get; private set; }

        public SettingsViewModel()
        {
            PrinterNames = System.Drawing.Printing.PrinterSettings.InstalledPrinters.Cast<string>().ToList();
            if (PrinterNames.Contains(Properties.Settings.Default.PrinterName))
            {
                SelectedPrinter = Properties.Settings.Default.PrinterName;
            }
            else
            {

            }

            SaveCommand = new RelayCommand(Save);
        }

        private void Save()
        {
            Properties.Settings.Default.PrinterName = SelectedPrinter;
            Properties.Settings.Default.Save();
        }
    }
}
