using System;
using System.Collections.Generic;
using System.Data.Metadata.Edm;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZainGym.Business;
using ZainGym.DataAccess;
using ZainGym.Model;

namespace ZainGym.ViewModel
{
	class HomeWindowViewModel : BaseViewModel
	{
		private MemberListViewModel _memberListViewModel;
		private AddNewMemberViewModel _addMemberViewModel;

		/// <summary>
		/// public constructor to instantiate the view model. 
		/// </summary>
		public HomeWindowViewModel()
		{
			IRepository<Person> personRepository = new PersonRepository(GlobalEngine.TheGlobalEngine.DataContext);
			_memberListViewModel = new MemberListViewModel(personRepository);
			_addMemberViewModel = new AddNewMemberViewModel(personRepository);
			_addMemberViewModel.OnMemberCreated += AddMemberViewModelOnOnMemberCreated;
			#region bind events and vm's
			
			#endregion
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
	}
}
