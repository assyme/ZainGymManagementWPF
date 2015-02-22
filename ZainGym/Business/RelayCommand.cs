using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ZainGym.Business
{
	public class RelayCommand : ICommand
	{
		private readonly Predicate<object> _canExecute;
		private readonly Action<Object> _execute; 

		public RelayCommand(Action<Object> execute,Predicate<Object> canExecute)
		{
			if (execute == null)
			{
				throw new ArgumentNullException("canExecute");
			}
			_execute = execute;
			_canExecute = canExecute;
		}

		public bool CanExecute(object parameter)
		{
			return _canExecute == null || _canExecute(parameter);
		}

		public void Execute(object parameter)
		{
			_execute(parameter);
		}

		public event EventHandler CanExecuteChanged
		{
			add { CommandManager.RequerySuggested += value; }
			remove { CommandManager.RequerySuggested -= value; }
		}
	}
}
