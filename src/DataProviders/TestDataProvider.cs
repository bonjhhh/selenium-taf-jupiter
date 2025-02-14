using System.Collections.Generic;
using SeleniumTestFramework.src.Data;

namespace SeleniumTestFramework.src.DataProviders
{
    public class TestData
    {
        public static IEnumerable<object[]> GetContactPageTestData()
        {
            var contactData = new ContactData();

            yield return new object[] { contactData.ValidForm.Forename, contactData.ValidForm.Surname, contactData.ValidForm.Email, contactData.ValidForm.Message, true }; // Valid data
            yield return new object[] { contactData.EmptyForm.Forename, contactData.EmptyForm.Surname, contactData.EmptyForm.Email, contactData.EmptyForm.Message, false }; // Empty fields
            yield return new object[] { contactData.InvalidForm.Forename, contactData.InvalidForm.Surname, contactData.InvalidForm.Email, contactData.InvalidForm.Message, false }; // Invalid data
        }

        public static IEnumerable<object[]> GetShopPageTestData()
        {
            yield return new object[] { "Stuffed Frog", 1 }; // Valid case
            yield return new object[] { "Fluffy Bunny", 2 }; // Valid case
            yield return new object[] { "Valentine Bear", 3 }; // Valid case
        }
    }
}