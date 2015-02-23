using System.Collections.ObjectModel;
using ZainGym.Business;
using ZainGym.DataAccess;
using ZainGym.Model;

namespace ZainGym.ViewModel
{
	public class MainWindowViewModel : BaseViewModel
	{
		private readonly IRepository<Person> _personRepository; 
		private readonly ObservableCollection<BaseViewModel> _viewModels;
		private MemberListViewModel _memberLisingViewModel;

		public MainWindowViewModel()
		{
			_personRepository = new Repository<Person>(GlobalEngine.TheGlobalEngine.DataContext);
			_viewModels = new ObservableCollection<BaseViewModel>();

			//Add additional view models here that may be used by the main window.
			MemberListingViewModel = new MemberListViewModel(_personRepository);
			

			AddNewMemberViewModel addNewMemberViewModel = new AddNewMemberViewModel(_personRepository);
			this.ViewModels.Add(addNewMemberViewModel);

		}

		public ObservableCollection<BaseViewModel> ViewModels
		{
			get { return _viewModels;}
		}

		public MemberListViewModel MemberListingViewModel
		{
			get { return _memberLisingViewModel; }
			set
			{
				_memberLisingViewModel = value;
				OnPropertyChanged("MemberListingViewModel");
			}
		}
	}
}
