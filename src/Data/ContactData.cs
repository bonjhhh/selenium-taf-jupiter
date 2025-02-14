namespace SeleniumTestFramework.src.Data
{
    public class ContactData
    {
        public FormData ValidForm { get; set; }
        public FormData InvalidForm { get; set; }
        public FormData EmptyForm { get; set; }

        public ContactData()
        {
            ValidForm = new FormData
            {
                Forename = "John",
                Surname = "Jones",
                Email = "john.doe@example.com",
                Telephone = "1234567890",
                Message = "This is a test message."
            };

            InvalidForm = new FormData
            {
                Forename = "",
                Surname = "Doe",
                Email = "invalidEmail",
                Telephone = "1234567890",
                Message = ""
            };

            EmptyForm = new FormData
            {
                Forename = "",
                Surname = "",
                Email = "",
                Telephone = "",
                Message = ""
            };
        }
    }

    public class FormData
    {
        public string? Forename { get; set; }
        public string? Surname { get; set; }
        public string? Email { get; set; }
        public string? Telephone { get; set; }
        public string? Message { get; set; }
    }
}