using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Linq;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using ZainGym.ViewModel;

namespace ZainGym
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		protected override void OnStartup(StartupEventArgs e)
		{
			base.OnStartup(e);
			Window mainWindow = new HomeWindow();
			mainWindow.Show();
		}
	}
}
