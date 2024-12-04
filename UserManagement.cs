using System;
using System.IO;

namespace HospitalManagementSystem
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }

    public static class UserManagement
    {
        private static string filePath = "Users.txt";

        public static User Authenticate(string username, string password)
        {
            if (!File.Exists(filePath)) return null;

            var lines = File.ReadAllLines(filePath);
            foreach (var line in lines)
            {
                var parts = line.Split(',');
                if (parts[0] == username && parts[1] == password)
                {
                    return new User { Username = parts[0], Password = parts[1], Role = parts[2] };
                }
            }
            return null;
        }

        public static void SignUp(string username, string password, string role)
        {
            using (StreamWriter sw = File.AppendText(filePath))
            {
                sw.WriteLine($"{username},{password},{role}");
            }
            Console.WriteLine("Sign-up successful!");
        }
    }
}
