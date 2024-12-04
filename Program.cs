using System;

namespace HospitalManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Hospital Management System!");

            while (true)
            {
                Console.WriteLine("\nPlease select your role:");
                Console.WriteLine("1. Admin");
                Console.WriteLine("2. Staff");
                Console.WriteLine("3. Patient");
                Console.WriteLine("4. Visitor");
                Console.WriteLine("5. Exit");

                int choice;
                bool isValid = int.TryParse(Console.ReadLine(), out choice);
                if (!isValid || choice < 1 || choice > 5)
                {
                    Console.WriteLine("Invalid choice. Please try again.");
                    continue;
                }

                switch (choice)
                {
                    case 1: // Admin
                        Login("Admin");
                        break;
                    case 2: // Staff
                        Login("Staff");
                        break;
                    case 3: // Patient
                        PatientOrVisitorSignUpOrLogin("Patient");
                        break;
                    case 4: // Visitor
                        PatientOrVisitorSignUpOrLogin("Visitor");
                        break;
                    case 5: // Exit
                        Console.WriteLine("Exiting program...");
                        return;
                }
            }
        }

        static void Login(string role)
        {
            int loginAttempts = 0;
            bool isAuthenticated = false;

            while (loginAttempts < 3 && !isAuthenticated)
            {
                Console.WriteLine($"\n{role} Login:");
                Console.Write("Enter Username: ");
                string username = Console.ReadLine();
                Console.Write("Enter Password: ");
                string password = Console.ReadLine();

                var user = UserManagement.Authenticate(username, password);
                if (user != null && user.Role == role)
                {
                    Console.WriteLine($"\nLogin Successful! Welcome, {user.Role}");
                    isAuthenticated = true;

                    if (role == "Admin")
                        AdminDashboard();
                    else if (role == "Staff")
                        StaffDashboard();
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

        static void PatientOrVisitorSignUpOrLogin(string role)
        {
            Console.WriteLine($"\n{role} Section:");
            Console.WriteLine("1. Login");
            Console.WriteLine("2. Sign Up");

            int choice;
            bool isValid = int.TryParse(Console.ReadLine(), out choice);
            if (!isValid || (choice != 1 && choice != 2))
            {
                Console.WriteLine("Invalid choice. Returning to main menu...");
                return;
            }

            if (choice == 1) // Login
            {
                Login(role);
            }
            else if (choice == 2) // Sign-Up
            {
                Console.Write("Enter Username: ");
                string username = Console.ReadLine();
                Console.Write("Enter Password: ");
                string password = Console.ReadLine();

                UserManagement.SignUp(username, password, role);
                Console.WriteLine("Sign-up successful! You can now log in.");
            }
        }

        static void AdminDashboard()
        {
            Console.WriteLine("\nAdmin Dashboard");
            // Implement admin-specific functionalities here
        }

        static void StaffDashboard()
        {
            Console.WriteLine("\nStaff Dashboard");
            // Implement staff-specific functionalities here
        }

        static void PatientDashboard(User user)
        {
            Console.WriteLine($"\nPatient Dashboard: Welcome, {user.Username}");
            // Implement patient-specific functionalities here
        }

        static void VisitorDashboard()
        {
            Console.WriteLine("\nVisitor Dashboard");
            MiniGame.Play();
        }
    }
}



// using System;

// namespace HospitalManagementSystem
// {
//     class Program
//     {
//         static void Main(string[] args)
//         {
//             Console.WriteLine("Welcome to the Hospital Management System!");

//             int loginAttempts = 0;
//             bool isAuthenticated = false;

//             while (loginAttempts < 3 && !isAuthenticated)
//             {
//                 Console.WriteLine("\nLogin:");
//                 Console.Write("Enter Username: ");
//                 string username = Console.ReadLine();
//                 Console.Write("Enter Password: ");
//                 string password = Console.ReadLine();

//                 var user = UserManagement.Authenticate(username, password);
//                 if (user != null)
//                 {
//                     Console.WriteLine($"\nLogin Successful! Welcome, {user.Role}");
//                     isAuthenticated = true;

//                     if (user.Role == "Admin")
//                         AdminDashboard();
//                     else if (user.Role == "Staff")
//                         StaffDashboard();
//                     else if (user.Role == "Patient")
//                         PatientDashboard(user);
//                     else if (user.Role == "Visitor")
//                         VisitorDashboard();
//                 }
//                 else
//                 {
//                     loginAttempts++;
//                     int remaining = 3 - loginAttempts;
//                     if (remaining > 0)
//                         Console.WriteLine($"Invalid credentials. You have {remaining} attempt(s) left.");
//                     else
//                         Console.WriteLine("Maximum attempts reached. Program terminating.");
//                 }
//             }
//         }

//         static void AdminDashboard() { /* Admin-specific functionality */ }
//         static void StaffDashboard() { /* Staff-specific functionality */ }
//         static void PatientDashboard(User user) { /* Patient-specific functionality */ }
//         static void VisitorDashboard() { MiniGame.Play(); }
//     }
// }
