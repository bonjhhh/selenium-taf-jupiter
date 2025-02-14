using System;
using System.Text;

namespace SeleniumTestFramework.src.Utilities
{
    public static class TestDataGenerator
    {
        private static readonly Random random = new Random();

        public static (string forename, string surname, string email, string phone, string message) GenerateRandomContactData()
        {
            string timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
            
            string forename = $"Test{random.Next(1000)}";
            string surname = $"User{random.Next(1000)}";
            string email = $"test{random.Next(1000)}@test{timestamp}.com";
            string phone = $"{random.Next(100, 999)}-{random.Next(100, 999)}-{random.Next(1000, 9999)}";
            
            var messageBuilder = new StringBuilder()
                .Append("This is a test message generated at ")
                .Append(DateTime.Now.ToString())
                .Append(" with random number ")
                .Append(random.Next(10000));
            
            return (forename, surname, email, phone, messageBuilder.ToString());
        }
    }
}