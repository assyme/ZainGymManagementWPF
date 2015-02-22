using System;
using System.Collections.ObjectModel;
using ZainGym.Business;
using ZainGym.DataAccess;
using ZainGym.Model;

namespace ZainGym.ViewModel
{
	public class MemberListViewModel : BaseViewModel
	{
		#region Private properties

		private IRepository<Person> _repository;
		private ObservableCollection<Person> _allMembers;

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

		

		#endregion
	}
}
