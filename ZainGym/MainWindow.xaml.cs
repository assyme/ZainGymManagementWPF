using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ZainGym.DataAccess;
using ZainGym.Model;

namespace ZainGym
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			string connectionString = ConfigurationManager.ConnectionStrings["ZainDBContext"].ConnectionString;
			System.Data.Linq.DataContext dataContext = new DataContext(connectionString);
			IRepository<Person> repository = new Repository<Person>(dataContext);
			List<Person> persons = repository.GetAll().ToList();
		}
	}
}
