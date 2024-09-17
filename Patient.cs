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
            if (File.Exists($"DB\\Patients\\RegisteredDoctors\\{id}.txt"))
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

            string[] labelNames = { "Doctor", "Patient", "Description" };
            // Table header string with custom padding to acheive uniform borders
            string tableHeaders = $"{labelNames[0],-20} | {labelNames[1],-20} | {labelNames[2],-10}";
            // Anonymous function: set a divider that will match the length of the headers
            string divider = new('─', tableHeaders.Length + 20);
            Console.WriteLine(tableHeaders);
            Console.WriteLine(divider);

            if (File.Exists($"DB\\Appointments\\Patients\\{id}.txt"))
            {
                string[] appointments = File.ReadAllLines($"DB\\Appointments\\Patients\\{id}.txt");
                foreach (string appointment in appointments)
                {
                    string[] appointmentData = appointment.Split('|');
                    Appointment a = new Appointment(appointmentData[0], appointmentData[1], appointmentData[2]);
                    Console.WriteLine(a);
                }
            }
            else
            {
                Console.WriteLine("No appointments found");
            }
            Console.ReadKey();
            Menu();
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
            CreateBooking();

            Console.ReadKey();
            Menu();
        }

        public void CreateBooking()
        {
            Console.Clear();
            //Check if patient has a doctor assigned, within RegisteredDoctors directory
            if (File.Exists($"DB\\Patients\\RegisteredDoctors\\{id}.txt"))
            {
                string doctorID = File.ReadAllText($"DB\\Patients\\RegisteredDoctors\\{id}.txt");

                //lookup for doctor using the doctorID
                string doctorFile = File.ReadAllText($"DB\\Doctors\\{doctorID}.txt");
                string[] doctorData = doctorFile.Split(';');

                Console.WriteLine();
                Console.WriteLine($"Booking an appointment with Dr. {doctorData[2]}");
                Console.Write("Description of the appointment: ");
                string description = Console.ReadLine() ?? "";

                if (string.IsNullOrEmpty(description))
                {
                    Console.WriteLine("Description cannot be empty, press any key to try again");
                    Console.ReadKey();
                    BookAppointment();
                }

                // Check if the patient/doctor already has an appointment with this doctor/patient => Append a new appointment to the file on a new line
                if (File.Exists($"DB\\Appointments\\Patients\\{id}.txt") && File.Exists($"DB\\Appointments\\Doctors\\{doctorID}.txt"))
                {
                    File.AppendAllText($"DB\\Appointments\\Patients\\{id}.txt", $"{doctorID}|{id}|{description}\n");
                    File.AppendAllText($"DB\\Appointments\\Doctors\\{doctorID}.txt", $"{doctorID}|{id}|{description}\n");
                }
                // If not create a new file with the patient/doctor ID as the filename and write the appointment details to it
                else if (!File.Exists($"DB\\Appointments\\Patients\\{id}.txt") && !File.Exists($"DB\\Appointments\\Doctors\\{doctorID}.txt"))
                {
                    File.WriteAllText($"DB\\Appointments\\Patients\\{id}.txt", $"{doctorID}|{id}|{description}\n");
                    File.WriteAllText($"DB\\Appointments\\Doctors\\{doctorID}.txt", $"{doctorID}|{id}|{description}\n");
                }

                Console.WriteLine("The appointment has been booked successfully");
            }
            //If no doctor is assigned to the current patient, then assign a doctor first, this will occur if a new patient is created by admin.
            else
            {
                Console.WriteLine();
                Console.WriteLine($"{fullName} are not registered with any doctor! Please choose which doctor you would like to register with");
                //[TODO]: Assign doctor
                //Read all current doctors within Doctors directory
                string[] doctorFiles = Directory.GetFiles("DB\\Doctors");
                //List all doctors
                foreach (string doctorFile in doctorFiles)
                {
                    string[] doctorData = File.ReadAllText(doctorFile).Split(';');
                    Doctor d = new Doctor(doctorData[0], doctorData[1], doctorData[2], doctorData[3], doctorData[4], doctorData[5], "Doctor");
                    Console.WriteLine(d);
                }
                //Prompt user to enter the ID of the doctor they would like to register with
                Console.WriteLine();
                try
                {
                    Console.Write("Please chooose a doctor: ");
                    int chosenOption = int.Parse(Console.ReadLine() ?? "0");
                    chosenOption -= 1;
                    if (chosenOption > doctorFiles.Length || chosenOption < 0)
                    {
                        throw new Exception("Invalid option, press any key to try again");
                    }
                    else
                    {
                        //find the doctor ID from the doctorFiles array
                        string doctorID = doctorFiles[chosenOption].Split('\\').Last().Split('.').First();
                        //Write the doctor ID to the patient's file in RegisteredDoctors directory
                        File.WriteAllText($"DB\\Patients\\RegisteredDoctors\\{id}.txt", doctorID.ToString());
                        // Also add the patient ID to the RegisteredPatients
                        if (File.Exists($"DB\\Doctors\\RegisteredPatients\\{doctorID}.txt"))
                        {
                            File.AppendAllText($"DB\\Doctors\\RegisteredPatients\\{doctorID}.txt", $"\n{id}");
                        }
                        else
                        {
                            File.WriteAllText($"DB\\Doctors\\RegisteredPatients\\{doctorID}.txt", $"{id}");
                        }
                        Console.WriteLine("Doctor assigned successfully");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.ReadKey();
                    CreateBooking();
                }
            }
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
