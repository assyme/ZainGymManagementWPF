using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using ZainGym.Model;

namespace ZainGym.Tests
{
	[TestFixture]
    public class PersonTests
    {
		[Test]
		public void PersonFirstNameShouldNotBeEmpty()
		{
			//Arrange:
			Person person = new Person();

			//Asserts:
			Assert.IsFalse(person.IsValid(), "person.IsValid()");
		}

		[Test]
		public void PersonFirstNameShouldBeGreaterThenOneCharacter()
		{
			Person person = new Person()
			{
				FirstName = "A",
				LastName = "Palekar"
			};

			Assert.IsFalse(person.IsValid());
		}
    }
}
