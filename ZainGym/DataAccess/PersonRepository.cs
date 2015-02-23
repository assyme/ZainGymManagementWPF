using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using ZainGym.Model;

namespace ZainGym.DataAccess
{
	public class PersonRepository : Repository<Person>
	{
		public PersonRepository(DataContext dataContext) : base(dataContext)
		{

		}

		public override Person CreateInstance()
		{
			Person newPersonInstance = base.CreateInstance();
			Membership newMembership = new Membership();
			newMembership.Person = newPersonInstance;
			newMembership.MemberFrom = DateTime.UtcNow;
			newMembership.MemberExpiry = DateTime.UtcNow.AddMonths(1); // Default membership of 1 month. 
			newPersonInstance.DateOfBirth = DateTime.UtcNow;
			newPersonInstance.Memberships.Add(newMembership);
			return newPersonInstance;
		}
	}
}
