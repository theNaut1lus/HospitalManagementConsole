using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementConsole
{
    internal class Patient : User
    {
        private string address, email, phone;

        public Patient(string address, string email, string phone, string id, string password, string fullname, string role) : base(id, password, fullname, role)
        {
            this.address = address;
            this.email = email;
            this.phone = phone;
        }

        public override void Menu()
        {
            Console.Clear();
            Console.WriteLine("┌──────────────────────────────────────┐");
            Console.WriteLine("│                                      │");
            Console.WriteLine("│   DOTNET Hospital Managment System   │");
            Console.WriteLine("│──────────────────────────────────────│");
            Console.WriteLine("│             Patient Menu             │");
            Console.WriteLine("│                                      │");
            Console.WriteLine("└──────────────────────────────────────┘");
            Console.WriteLine();

            Console.WriteLine($"Welcome to DOTNET Hospital Managment System {fullname}");
            Console.WriteLine();
            Console.WriteLine("Please choose an option:");
            foreach (string option in options)
            {
                Console.WriteLine(option);
            }

            try
            {
                var info = Console.ReadKey(true);
                switch (info.Key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        MyDetails();
                        break;
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        MyDoctor();
                        break;
                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        MyAppointment();
                        break;
                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:
                        BookAppointment();
                        break;
                    case ConsoleKey.D5:
                    case ConsoleKey.NumPad5:
                        Console.Clear();
                        //[TODO]: find a way to go back to main menu
                        break;
                    case ConsoleKey.D6:
                    case ConsoleKey.NumPad6:
                        Environment.Exit(0);
                        break;
                    default:
                        throw new Exception($"Invalid option, please choose from 1-{options.Length}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine();
                Console.WriteLine(e.Message);
                Console.ReadKey();
                Menu();
            }
            Console.ReadKey();
        }

        public void MyDetails()
        {
            //[TODO]
        }

        public void MyDoctor()
        {
            //[TODO]
        }

        public void MyAppointment()
        {
            //[TODO]
        }

        public void BookAppointment()
        {
            //[TODO]
        }



    }
}
