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

        //Patient constructor
        public Patient(string address, string email, string phone, string id, string password, string fullname, string role) : base(id, password, fullname, role)
        {
            this.address = address;
            this.email = email;
            this.phone = phone;
        }

        //Patient Details method
        private void Details()
        {
            Console.Clear();
            Console.WriteLine("┌──────────────────────────────────────┐");
            Console.WriteLine("│                                      │");
            Console.WriteLine("│   DOTNET Hospital Managment System   │");
            Console.WriteLine("│──────────────────────────────────────│");
            Console.WriteLine("│              My Details              │");
            Console.WriteLine("│                                      │");
            Console.WriteLine("└──────────────────────────────────────┘");
            Console.WriteLine();
            Console.WriteLine($"{fullName}'s Details");
            Console.WriteLine();
            Console.WriteLine($"Patient ID: {id}\nFull Name: {fullName}\nAddress: {address}\nEmail: {email}\nPhone: {phone}");
            Console.ReadKey();
            Menu();
        }

        //Assigned Doctor method
        private void AssignedDoctor()
        {
            Console.Clear();
            Console.WriteLine("┌──────────────────────────────────────┐");
            Console.WriteLine("│                                      │");
            Console.WriteLine("│   DOTNET Hospital Managment System   │");
            Console.WriteLine("│──────────────────────────────────────│");
            Console.WriteLine("│               My Doctor              │");
            Console.WriteLine("│                                      │");
            Console.WriteLine("└──────────────────────────────────────┘");
            Console.WriteLine();
            Console.WriteLine("Your doctor:");
            Console.WriteLine();

            string[] labels = { "Name", "Email Address", "Phone", "Address" };
            

            //[TODO]: List assigned doctor or null if no doc assigned.
        }

        //List Appointments method
        private void Appointments()
        {
            Console.Clear();
            Console.WriteLine("┌──────────────────────────────────────┐");
            Console.WriteLine("│                                      │");
            Console.WriteLine("│   DOTNET Hospital Managment System   │");
            Console.WriteLine("│──────────────────────────────────────│");
            Console.WriteLine("│            My Appointment            │");
            Console.WriteLine("│                                      │");
            Console.WriteLine("└──────────────────────────────────────┘");
            Console.WriteLine();
            Console.WriteLine($"Appointment for {fullName}");
            Console.WriteLine();

            //[TODO]: List all appointments
        }

        //Book Appointment method
        private void BookAppointment()
        {
            Console.Clear();
            Console.WriteLine("┌──────────────────────────────────────┐");
            Console.WriteLine("│                                      │");
            Console.WriteLine("│   DOTNET Hospital Managment System   │");
            Console.WriteLine("│──────────────────────────────────────│");
            Console.WriteLine("│            Book Appointment          │");
            Console.WriteLine("│                                      │");
            Console.WriteLine("└──────────────────────────────────────┘");

            //[TODO]: Create booking system

            Console.ReadKey();
            Menu();
        }

        public void CreateBooking()
        {
            //[TODO]: Create booking system
        }

        //override Menu method from User to display Patient Menu
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

            Console.WriteLine($"Welcome to DOTNET Hospital Managment System {fullName}");
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
                    //1. List patient Details
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        Details();
                        break;
                    //2. List my doctor details
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        AssignedDoctor();
                        break;
                    //3. List all appointments
                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        Appointments();
                        break;
                    //4. Book appointment
                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:
                        BookAppointment();
                        break;
                    //5. Exit to login
                    case ConsoleKey.D5:
                    case ConsoleKey.NumPad5:
                        Console.Clear();
                        Program.Main([]);
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




    }
}
