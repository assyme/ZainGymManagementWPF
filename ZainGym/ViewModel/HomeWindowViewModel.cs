using ZainGym.Business;
using ZainGym.DataAccess;
using ZainGym.Model;

namespace ZainGym.ViewModel
{
	class HomeWindowViewModel : BaseViewModel
	{
		private MemberListViewModel _memberListViewModel;
		private AddNewMemberViewModel _addMemberViewModel;
		private MemberDetailViewModel _memberDetailViewModel;

		/// <summary>
		/// public constructor to instantiate the view model. 
		/// </summary>
		public HomeWindowViewModel()
		{
			IRepository<Person> personRepository = new PersonRepository(GlobalEngine.TheGlobalEngine.DataContext);
			_memberListViewModel = new MemberListViewModel(personRepository);
			_memberDetailViewModel = new MemberDetailViewModel(personRepository);
			_addMemberViewModel = new AddNewMemberViewModel(personRepository);

			#region bind events and vm's
			_addMemberViewModel.OnMemberCreated += AddMemberViewModelOnOnMemberCreated;
			_memberListViewModel.OnMemberSelected += SelectMemberForDetailView;

			#endregion
		}

		private void SelectMemberForDetailView(object sender, Person selectedperson)
		{
			_memberDetailViewModel.SelectedMember = selectedperson;
		}

		private void AddMemberViewModelOnOnMemberCreated(object sender, Person newMember)
		{
			_memberListViewModel.AllMembers.Add(newMember);
		}

		public MemberListViewModel MemberListViewModel
		{
			get { return _memberListViewModel; }
			set
			{
				_memberListViewModel = value;
				OnPropertyChanged("MemberListViewModel");
			}
		}

		public AddNewMemberViewModel AddMemberViewModel
		{
			get { return _addMemberViewModel; }
			set
			{
				_addMemberViewModel = value;
				OnPropertyChanged("AddMemberViewModel");
			}
		}

		public MemberDetailViewModel MemberDetailViewModel
		{
			get
			{
				return _memberDetailViewModel;
			}
			set
			{
				_memberDetailViewModel = value;
				OnPropertyChanged("MemberDetailViewModel");
			}
		}
	}
}
