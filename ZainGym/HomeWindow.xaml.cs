namespace ZainGym
{
	using System.Windows;
	using ViewModel;

	/// <summary>
	/// Interaction logic for HomeWindow.xaml
	/// </summary>
	public partial class HomeWindow : Window
	{
		public HomeWindow()
		{
			InitializeComponent();
			DataContext = new HomeWindowViewModel();
		}
	}
}
