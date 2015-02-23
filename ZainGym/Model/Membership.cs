using System;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Runtime.InteropServices;

namespace ZainGym.Model
{
	[Table(Name = "Memberships")]
	public class Membership : BaseModel
	{
		private int _id;
		private int _personId;
		private EntityRef<Person> _person;
		private DateTime _memberFrom;
		private DateTime _memberExpiry;

		[Column(Name = "Id",IsPrimaryKey = true,IsDbGenerated = true)]
		public int Id 
		{
			get { return _id; }
			set { _id = value; }
		}

		[Column(Name="PersonId")]
		public int PersonId
		{
			get { return _personId; }
			set { _personId = value; }
		}

		[Column(Name="From")]
		public DateTime MemberFrom
		{
			get { return _memberFrom; }
			set { _memberFrom = value; }
		}

		[Column(Name="To")]
		public DateTime MemberExpiry
		{
			get { return _memberExpiry; }
			set { _memberExpiry = value; }
		}

		[Association(Storage = "_person", ThisKey = "PersonId",OtherKey = "Id",IsForeignKey = true)]
		public Person Person
		{
			get { return _person.Entity; }
			set { this._person.Entity = value; }
		}


		public Membership()
		{
					
		}

		public override bool IsValid()
		{
			return true;
		}
	}
}
