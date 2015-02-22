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
		private IRepository<Person> _personRepository;
		private AddNewMemberViewModel _addMemberViewModel;

		/// <summary>
		/// public constructor to instantiate the view model. 
		/// </summary>
		public HomeWindowViewModel()
		{
			_personRepository = new Repository<Person>(GlobalEngine.TheGlobalEngine.DataContext);
			_memberListViewModel = new MemberListViewModel(_personRepository);

			_addMemberViewModel = new AddNewMemberViewModel(_personRepository);

			#region bind events and vm's
			
			#endregion
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
