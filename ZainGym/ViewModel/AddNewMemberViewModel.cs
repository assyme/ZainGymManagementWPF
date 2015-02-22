using System;
using System.Windows.Input;
using ZainGym.Business;
using ZainGym.DataAccess;
using ZainGym.Model;

namespace ZainGym.ViewModel
{
	public class AddNewMemberViewModel : BaseViewModel
	{
		private readonly IRepository<Person> _repository;
		private Person _newMember;
		private ICommand _addNewMemberCommand;

		#region Events

		public delegate void MemberCreated(Object sender, Person newMember);

		public event MemberCreated OnMemberCreated; 
		#endregion

		public AddNewMemberViewModel(IRepository<Person> repository)
		{
			if (repository == null)
				throw new ArgumentNullException("repository");
			_repository = repository;

			NewMember = _repository.CreateInstance();
		}

		public Person NewMember
		{
			get { return _newMember;}
			set
			{
				_newMember = value;
				OnPropertyChanged("NewMember");
			}
		}

		public ICommand AddNewMemberCommand
		{
			get
			{
				if (_addNewMemberCommand == null)
				{
					_addNewMemberCommand = new RelayCommand(ExecuteAddNewMember,CanExecuteAddNewMember);
				}
				return _addNewMemberCommand;
			}
		}

		private bool CanExecuteAddNewMember(object obj)
		{
			return true;
		}

		private void ExecuteAddNewMember(object obj)
		{
			if (NewMember.IsValid())
			{
				_repository.SaveAll();
				if (OnMemberCreated != null)
					OnMemberCreated(this, NewMember);
			}
		}
	}
}
