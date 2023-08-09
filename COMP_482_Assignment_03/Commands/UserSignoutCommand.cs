using COMP_482_Assignment_03.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP_482_Assignment_03.Commands
{
	public class UserSignoutCommand : BaseCommand
	{
		private readonly MainWindowViewModel mainWindowVM;

		public UserSignoutCommand(MainWindowViewModel _mainWindowVM)
		{
			mainWindowVM = _mainWindowVM;
		}

		public override void Execute(object parameter)
		{
			mainWindowVM.LoggedInEmployee = null;
		}
	}
}
