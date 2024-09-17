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

        //Doctor constructor
        public Doctor(string id, string password, string fullName, string address, string email, string phone, string role) : base(id, password, fullName, role)
        {
            this.address = address;
            this.email = email;
            this.phone = phone;
        }

            //Doctor Details method
            public void Details()
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

            //additional processing required to format into table as per specifications
            string[] labelNames = { "Name", "Email Address", "Phone", "Address" };
            // Table header string with custom padding to acheive uniform borders
            string tableHeaders = $"{labelNames[0],-20} | {labelNames[1],-20} | {labelNames[2],-10} | {labelNames[3],-20}";
            // Anonymous function: set a divider that will match the length of the headers
            string divider = new('─', tableHeaders.Length + 20);
            Console.WriteLine(tableHeaders);
            Console.WriteLine(divider);
            //Display the doctor's details
            Console.WriteLine(this);
            Console.ReadKey();
            Menu();
        }

        //Method to display the doctor's details
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

        //Method to display all appointments for the doctor
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

        //Method to check a particular patient
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

        //Method to list appointments with a particular patient
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

            string patientID = Console.ReadLine() ?? "";

            //[TODO] : Appointment search using patient ID
        }


        //override Menu method from User to display Patient Menu
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
                    //1. List doctor details
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        Details();
                        break;
                    //2. List patients
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        ListAssignedPatients();
                        break;
                    //3. List appointments
                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        ListAppointments();
                        break;
                    //4. Check particular patient
                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:
                        CheckParticularPatient();
                        break;
                    //5. List appointment with patient
                    case ConsoleKey.D5:
                    case ConsoleKey.NumPad5:
                        ListAppointmentsWIthPatient();
                        break;
                    //6. Logout
                    case ConsoleKey.D6:
                    case ConsoleKey.NumPad6:
                        Console.Clear();
                        Program.Main([]);
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

        public override string ToString()
        {
            return $"{fullName,-20} | {email,-20} | {phone,-5} | {address,-20}";
        }

    }
}
