using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementConsole
{
    internal class Doctor : User
    {
        private string address, email, phone;

        public Doctor(string address, string email, string phone, string id, string password, string fullname, string role) : base(id, password, fullname, role)
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
            Console.WriteLine("│             Doctor Menu              │");
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
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        ListDetails();
                        break;
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        ListAssignedPatients();
                        break;
                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        ListAppointments();
                        break;
                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:
                        CheckParticularPatient();
                        break;
                    case ConsoleKey.D5:
                    case ConsoleKey.NumPad5:
                        ListAppointmentsWIthPatient();
                        break;
                    case ConsoleKey.D6:
                    case ConsoleKey.NumPad6:
                        Console.Clear();
                        //[TODO]: find a way to go back to main menu
                        break;
                    case ConsoleKey.D7:
                    case ConsoleKey.NumPad7:
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

        public void ListDetails()
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

            string[] labels = { "Name", "Email Address", "Phone", "Address" };
            string headers = $"{labels[0],-20} | {labels[1],-20} | {labels[2],-10} | {labels[3],-20}";
            // Divider matches the length of the headers
            string divider = new('─', headers.Length + 20);
            Console.WriteLine(headers);
            Console.WriteLine(divider);

            Console.WriteLine(this);
            Console.ReadKey();
            Menu();
        }

        public void ListAssignedPatients()
        {
            Console.Clear();
            Console.WriteLine("┌──────────────────────────────────────┐");
            Console.WriteLine("│                                      │");
            Console.WriteLine("│   DOTNET Hospital Managment System   │");
            Console.WriteLine("│──────────────────────────────────────│");
            Console.WriteLine("│              My Patients             │");
            Console.WriteLine("│                                      │");
            Console.WriteLine("└──────────────────────────────────────┘");
            Console.WriteLine();
            Console.WriteLine($"Patients assigned to {fullName}");
            Console.WriteLine();

            string[] labels = { "Name", "Doctor", "Email Address", "Phone", "Address" };

            //TODO: Get all patients assigned to this doctor, null if no assigned.
        }

        public void ListAppointments()
        {
            Console.Clear();
            Console.WriteLine("┌──────────────────────────────────────┐");
            Console.WriteLine("│                                      │");
            Console.WriteLine("│   DOTNET Hospital Managment System   │");
            Console.WriteLine("│──────────────────────────────────────│");
            Console.WriteLine("│           All Appointments           │");
            Console.WriteLine("│                                      │");
            Console.WriteLine("└──────────────────────────────────────┘");
            Console.WriteLine();

            string[] labels = { "Doctor", "Patient", "Description" };
            //[TODO] : 
        }

        public void CheckParticularPatient()
        {
            Console.Clear();
            Console.WriteLine("┌──────────────────────────────────────┐");
            Console.WriteLine("│                                      │");
            Console.WriteLine("│   DOTNET Hospital Managment System   │");
            Console.WriteLine("│──────────────────────────────────────│");
            Console.WriteLine("│         Check Patient Details        │");
            Console.WriteLine("│                                      │");
            Console.WriteLine("└──────────────────────────────────────┘");
            Console.WriteLine();
            Console.Write("Enter the ID of the patient to check: ");
            //[TODO] : Patient search
        }

        public void ListAppointmentsWIthPatient()
        {
            Console.Clear();
            Console.WriteLine("┌──────────────────────────────────────┐");
            Console.WriteLine("│                                      │");
            Console.WriteLine("│   DOTNET Hospital Managment System   │");
            Console.WriteLine("│──────────────────────────────────────│");
            Console.WriteLine("│           Appointment With           │");
            Console.WriteLine("│                                      │");
            Console.WriteLine("└──────────────────────────────────────┘");

            Console.WriteLine();
            Console.Write("Enter the ID of the patient you would like to view appointments for: ");

            //[TODO] : Appointment search
        }

    }
}
