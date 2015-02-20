using Microsoft.VisualStudio.TestTools.UnitTesting;
using ZainGym.Model;

namespace ZainTests.ModelTests
{
	[TestClass]
	public class PersonTests
	{

		[TestMethod]
		public void PersonFirstNameShouldNotBeEmpty()
		{
			//Arrange:
			Person person = new Person();

			//Asserts:
			Assert.IsFalse(person.IsValid(),"person.IsValid()");
		}
		 
	}
}