using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Project_P4.ViewModels;

namespace Project_P4.Commands
{
    internal class UpdateViewCommand : ICommand
    {
        private MainViewModel viewModel;
        public UpdateViewCommand(MainViewModel viewModel)
        {
            this.viewModel = viewModel;
        }
        public event EventHandler CanExecuteChanged;
        public bool CanExecute(object parameter)
        {
            return true;
        }
        public void Execute(object parameter)
        {
            if(parameter.ToString() == "Member")
            {
                viewModel.SelectedViewModel = new MemberViewModel();
            }
            else if(parameter.ToString() == "Income")
            {
                viewModel.SelectedViewModel = new IncomeViewModel();
            }
            else if(parameter.ToString() == "Expence")
            {
                viewModel.SelectedViewModel = new ExpenceViewModel();
            }
            else if(parameter.ToString() == "ExpGroup")
            {
                viewModel.SelectedViewModel = new ExpGroupViewModel();
            }
            else if(parameter.ToString() == "Home")
            {
                viewModel.SelectedViewModel = new HomeViewModel();
            }
        }
    }
}
