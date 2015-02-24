using System.Collections.ObjectModel;
using ZainGym.DataAccess;
using ZainGym.Model;

namespace ZainGym.ViewModel
{
	public class MemberDetailViewModel : BaseViewModel
	{
		private IRepository<Person> _repository;
		private Person _selectedMember;
		private ObservableCollection<Membership> _memberships; 

		#region Constructor
		public MemberDetailViewModel(IRepository<Person> repository )
		{
			_repository = repository;
			_memberships = new ObservableCollection<Membership>();
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


	}
}
