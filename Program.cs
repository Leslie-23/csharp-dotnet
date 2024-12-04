using System;

namespace HospitalManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Hospital Management System!");

            int loginAttempts = 0;
            bool isAuthenticated = false;

            while (loginAttempts < 3 && !isAuthenticated)
            {
                Console.WriteLine("\nLogin:");
                Console.Write("Enter Username: ");
                string username = Console.ReadLine();
                Console.Write("Enter Password: ");
                string password = Console.ReadLine();

                var user = UserManagement.Authenticate(username, password);
                if (user != null)
                {
                    Console.WriteLine($"\nLogin Successful! Welcome, {user.Role}");
                    isAuthenticated = true;

                    if (user.Role == "Admin")
                        AdminDashboard();
                    else if (user.Role == "Staff")
                        StaffDashboard();
                    else if (user.Role == "Patient")
                        PatientDashboard(user);
                    else if (user.Role == "Visitor")
                        VisitorDashboard();
                }
                else
                {
                    loginAttempts++;
                    int remaining = 3 - loginAttempts;
                    if (remaining > 0)
                        Console.WriteLine($"Invalid credentials. You have {remaining} attempt(s) left.");
                    else
                        Console.WriteLine("Maximum attempts reached. Program terminating.");
                }
            }
        }

        static void AdminDashboard() { /* Admin-specific functionality */ }
        static void StaffDashboard() { /* Staff-specific functionality */ }
        static void PatientDashboard(User user) { /* Patient-specific functionality */ }
        static void VisitorDashboard() { MiniGame.Play(); }
    }
}
