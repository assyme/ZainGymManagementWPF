using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using System.Windows.Navigation;
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
		private Person _selectedMember;

		#endregion

		#region Events and Delegates

		public delegate void MemberSelected(Object sender, Person selectedPerson);

		public event MemberSelected OnMemberSelected;
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
			get { return _allMembers; }
			set
			{
				_allMembers = value;
				OnPropertyChanged("AllMembers");
			}
		}

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

		public Person SelectedMember
		{
			get { return _selectedMember; }
			set
			{
				_selectedMember = value;
				if (OnMemberSelected != null)
				{
					OnMemberSelected(this, _selectedMember);
				}
				OnPropertyChanged("SelectedMember");
			}
		}

		#endregion

		#region Events

		#endregion
	}
}
