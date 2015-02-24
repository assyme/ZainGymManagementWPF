using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using ZainGym.Business;
using ZainGym.DataAccess;
using ZainGym.Model;

namespace ZainGym.ViewModel
{
	public class MemberListViewModel : BaseViewModel
	{
		#region Private properties

		private readonly IRepository<Person> _repository;
		private ObservableCollection<Person> _allMembers;
		private string _searchText;

		#endregion

		#region Constructors

		public MemberListViewModel(IRepository<Person> personRepository)
		{
			_repository = personRepository;
			AllMembers = new ObservableCollection<Person>(_repository.GetAll()); 
		}
		#endregion

		#region Public properties

		public ObservableCollection<Person> AllMembers
		{
			get { return _allMembers;}
			set
			{
				_allMembers = value;
				OnPropertyChanged("AllMembers");
			}
		}

		//public ICommand SearchMember
		//{
		//	get
		//	{
		//		if (_searchMemberCommand == null)
		//		{
		//			_searchMemberCommand = new RelayCommand(SearchMemberExecute, CanExecuteSearchMember);
		//		}
		//		return _searchMemberCommand;
		//	}
		//}

		//private bool CanExecuteSearchMember(object obj)
		//{
		//	return true;
		//}

		//private void SearchMemberExecute(object obj)
		//{
		//	AllMembers = new ObservableCollection<Person> (_repository.GetAll().Where(x => x.FullName.Contains(SearchText)));
		//}

		public string SearchText
		{
			get { return _searchText; }
			set
			{
				_searchText = value;
				AllMembers = new ObservableCollection<Person>(_repository.GetAll().Where(x => x.FullName.Contains(_searchText)));
				OnPropertyChanged("SearchText");
			}
		}

		#endregion
	}
}
