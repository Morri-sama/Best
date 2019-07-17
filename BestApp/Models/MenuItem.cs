using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BestApp.Models
{
    public class MenuItem
    {
        public MenuItem(string name, PackIconKind icon, ICommand command)
        {
            Name = name;
            Icon = icon;
            Command = command;
        }

        public string Name { get; private set; }
        public PackIconKind Icon { get; private set; }
        public ICommand Command { get; private set; }
    }
}
