using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using ZainGym.Business;
using ZainGym.DataAccess;
using ZainGym.Model;

namespace ZainGym.ViewModel
{
	public class MemberDetailViewModel : BaseViewModel
	{
		private IRepository<Person> _repository;
		private Person _selectedMember;
		private ObservableCollection<Membership> _memberships;
		private DateTime _startOn;
		private DateTime _endOn;
		private ICommand _renewMembershipCommand;

		#region Constructor
		public MemberDetailViewModel(IRepository<Person> repository)
		{
			_repository = repository;
			_memberships = new ObservableCollection<Membership>();
			_startOn = DateTime.UtcNow;
			_endOn = DateTime.UtcNow.AddMonths(1);
		}
		#endregion

		public Person SelectedMember
		{
			get { return _selectedMember; }
			set
			{
				_selectedMember = value;
				Memberships = new ObservableCollection<Membership>(_selectedMember.Memberships);
				OnPropertyChanged("SelectedMember");
			}
		}

		public DateTime StartOn
		{
			get { return _startOn; }
			set
			{
				_startOn = value;
				OnPropertyChanged("StartOn");
			}
		}

		public DateTime EndOn
		{
			get { return _endOn; }
			set
			{
				_endOn = value;
				OnPropertyChanged("EndOn");
			}
		}

		public ObservableCollection<Membership> Memberships
		{
			get
			{
				return _memberships;
			}
			set
			{
				_memberships = value;
				OnPropertyChanged("Memberships");
			}
		}

		#region Events

		public ICommand RenewMembershipCommand
		{
			get
			{
				if (_renewMembershipCommand == null)
				{
					_renewMembershipCommand = new RelayCommand(RenewMembershipExecution, (x) => true);
				}
				return _renewMembershipCommand;
			}
		}

		private void RenewMembershipExecution(object obj)
		{
			Membership membershipToAdd = new Membership()
			{
				MemberExpiry = EndOn,
				MemberFrom = StartOn,
				Person = SelectedMember
			};
			SelectedMember.Memberships.Add(membershipToAdd);
			if (SelectedMember.IsValid())
			{
				_repository.SaveAll();
			}
			Memberships.Add(membershipToAdd);
		}

		#endregion


	}
}
