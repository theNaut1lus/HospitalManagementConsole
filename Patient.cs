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
        public Patient(string id, string password, string fullName, string address, string email, string phone, string role) : base(id, password, fullName, role)
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
            //Simple display of patient details as per assignment specs: therefore no extra processing
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

            //additional processing required to format into table as per specifications
            string[] labelNames = { "Name", "Email Address", "Phone", "Address" };
            // Table header string with custom padding to acheive uniform borders
            string tableHeaders = $"{labelNames[0],-20} | {labelNames[1],-20} | {labelNames[2],-10} | {labelNames[3],-20}";
            // Anonymous function: set a divider that will match the length of the headers
            string divider = new('─', tableHeaders.Length + 20);
            Console.WriteLine(tableHeaders);
            Console.WriteLine(divider);
            //Find and display the doctor assigned to the patient using patient's own ID

            if(File.Exists($"DB\\Patients\\RegisteredDoctors\\{id}.txt"))
            {
                //possble that a patient may not have a doctor assigned, so we need a separate directory containing the patient that has an assigned doctor's id
                string assignedDoctorID = File.ReadAllText($"DB\\Patients\\RegisteredDoctors\\{id}.txt");
                //only 1 doctor can be assigned to a patient, so will contain just the 1 doctor ID
                if (File.Exists($"DB\\Doctors\\{assignedDoctorID}.txt"))
                {
                    string doctorFile = File.ReadAllText($"DB\\Doctors\\{assignedDoctorID}.txt");
                    string[] doctorData = doctorFile.Split(';');
                    Doctor d = new Doctor(doctorData[0], doctorData[1], doctorData[2], doctorData[3], doctorData[4], doctorData[5], "Doctor");
                    Console.WriteLine(d);
                }
                else
                {
                    Console.WriteLine("No doctor assigned");
                }
            }
            else
            {
                Console.WriteLine("Patient not found");
            }



            Console.ReadKey();
            Menu();


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
