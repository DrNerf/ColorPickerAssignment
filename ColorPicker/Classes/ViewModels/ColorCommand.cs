using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ColorPicker.Classes.ViewModels
{
    public class ColorCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        public ColorViewModel ViewModel;

        public ColorCommand(ColorViewModel viewmodel)
        {
            ViewModel = viewmodel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            ViewModel.SetHexColor(parameter.ToString());
        }
    }
}
