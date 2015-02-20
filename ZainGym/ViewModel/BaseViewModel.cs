using System.ComponentModel;
using ZainGym.Annotations;

namespace ZainGym.ViewModel
{
	internal class BaseViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		[NotifyPropertyChangedInvocator]
		protected void OnPropertyChanged(string propertyName)
		{
			var handler = PropertyChanged;
			if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}