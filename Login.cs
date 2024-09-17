using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementConsole
{
    internal class Login
    {
        private string id, password;

        public void LoginMenu()
        {
            Console.WriteLine("┌──────────────────────────────────────┐");
            Console.WriteLine("│                                      │");
            Console.WriteLine("│   DOTNET Hospital Managment System   │");
            Console.WriteLine("│──────────────────────────────────────│");
            Console.WriteLine("│                LOGIN                 │");
            Console.WriteLine("│                                      │");
            Console.WriteLine("└──────────────────────────────────────┘");
            Console.WriteLine();

            Console.Write("ID: ");
            id = Console.ReadLine() ?? "";
            Console.Write("Password: ");
            password = EnterPassword();
            //Console.WriteLine("{0} {1}", id, password); //temp

            HandleLogin();

        }

        private static string EnterPassword()
        {
            string password = "";
            ConsoleKey key;
            do
            {
                var keyInfo = Console.ReadKey(intercept: true);
                key = keyInfo.Key;
                if (key == ConsoleKey.Backspace && password.Length > 0)
                {
                    Console.Write("\b \b");
                    password = password[0..^1];
                }
                else if (!char.IsControl(keyInfo.KeyChar))
                {
                    Console.Write("*");
                    password += keyInfo.KeyChar;
                }
            } while (key != ConsoleKey.Enter);
            return password;
        }

        private void HandleLogin()
        {
            // Login Try Catch
            try
            {
                //Use entered id to find the file as filename = id.txt
                string file = $"{id}.txt";

                // Check if the file will exist in any of the 3 directories, if file exists, then checks credentials
                if (File.Exists($"Administrators\\{file}"))
                {
                    CredCheck("Administrators", file);
                }
                else if (File.Exists($"Doctors\\{file}"))
                {
                    CredCheck("Doctors", file);
                }
                else if (File.Exists($"Patients\\{file}"))
                {
                    CredCheck("Patients", file);
                }
                else
                {
                    throw new Exception("Invalid ID or account user doesn't exist, press any key to try again");
                }
            }
            catch (Exception e)
            {
                switch (e.Message)
                {
                    case "Invalid password, press any key to try again":
                        Console.WriteLine(e.Message);
                        Console.ReadKey();
                        Console.Clear();
                        LoginMenu();
                        break;
                    case "Invalid ID or account user doesn't exist, press any key to try again":
                        Console.WriteLine(e.Message);
                        Console.ReadKey();
                        Console.Clear();
                        LoginMenu();
                        break;
                    default:
                        Console.WriteLine(e.Message);
                        Console.ReadKey();
                        Console.Clear();
                        LoginMenu();
                        break;
                }
            }
        }

        private void CredCheck(string role, string file)
        {
            // Read the file
            string[] lines = File.ReadAllLines($"{role}\\{file}");
            string[] details = lines[0].Split(';');

            // Check if the id and password is correct
            if (id == details[0] && password == details[1])
            {
                Console.WriteLine("Valid Credentials");
                Console.ReadKey();

                switch (role)
                {
                    case "Patients":
                        Patient patient = new Patient(details[0], details[1], details[2], details[3], details[4], details[5], "Patient");
                        patient.Menu();
                        break;
                    case "Doctors":
                        Doctor doctor = new Doctor(details[0], details[1], details[2], details[3], details[4], details[5], "Doctor");
                        doctor.Menu();
                        break;
                    case "Administrators":
                        Administrator administrator = new Administrator(details[0], details[1], details[2], "Administrator");
                        administrator.Menu();
                        break;
                    default:
                        break;
                }
            }
            else
            {
                throw new Exception("\nInvalid password, press any key to try again");
            }
        }


    }
}
