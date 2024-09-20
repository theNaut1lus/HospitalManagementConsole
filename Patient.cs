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
            Utils.Header(labelNames,"-");

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
                Console.WriteLine("No doctor assigned");
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
            Utils.Header(labelNames, "-");

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
                    Console.WriteLine("Description cannot be empty, press any key to try again, or 'e' to exit.");
                    var info = Console.ReadKey(true).Key;
                    if (info == ConsoleKey.E)
                    {
                        Menu();
                    }
                    else BookAppointment();
                }

                //create a new appointment object with the entered details
                Appointment a = new Appointment(doctorID, id, description);


                // Check if the patient/doctor already has an appointment with this doctor/patient => Append a new appointment to the files on a new line using ToSave() method
                if (File.Exists($"DB\\Appointments\\Patients\\{id}.txt") && File.Exists($"DB\\Appointments\\Doctors\\{doctorID}.txt"))
                {
                    File.AppendAllText($"DB\\Appointments\\Patients\\{id}.txt", a.ToSave());
                    File.AppendAllText($"DB\\Appointments\\Doctors\\{doctorID}.txt", a.ToSave());
                }
                // If not create a new file with the patient/doctor ID as the filename and write the appointment details to it using ToSave() method
                else if (!File.Exists($"DB\\Appointments\\Patients\\{id}.txt") && !File.Exists($"DB\\Appointments\\Doctors\\{doctorID}.txt"))
                {
                    File.WriteAllText($"DB\\Appointments\\Patients\\{id}.txt", a.ToSave());
                    File.WriteAllText($"DB\\Appointments\\Doctors\\{doctorID}.txt", a.ToSave());
                }

                Console.WriteLine("The appointment has been booked successfully");

                //send an email to the patient to confirm the appointment
                string subject = "Appointment Confirmation";
                string body = $"Dear {fullName},\n\nYour appointment with Dr. {doctorData[2]} has been successfully booked.\n\nDescription: {description}\n\nRegards,\nHospital Management System";
                //if sendemail returns a string with OK in it, then the email was sent successfully, otherwise print out email unsuccessful but still book appointment
                if (Utils.SendEmail(fullName, email, subject, body).Contains("OK"))
                {
                    Console.WriteLine("An email has been sent to confirm the appointment");
                }
                else
                {
                    Console.WriteLine("Email was not sent successfully");
                }
            }
            //If no doctor is assigned to the current patient, then assign a doctor first, this will occur if a new patient is created by admin.
            else
            {
                Console.WriteLine();
                Console.WriteLine($"{fullName} are not registered with any doctor! Please choose which doctor you would like to register with");
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
                        // Also add the patient ID to the RegisteredPatients, a doctor can have multiple patients, but not vice-versa
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

        public override string ToString()
        {
            string doctorName = "";
            if (File.Exists($"DB\\Patients\\RegisteredDoctors\\{id}.txt"))
            {
                // Get the registered doctor using the patient's ID from the RegisteredDoctors directory
                string registeredDoctorID = File.ReadAllText($"DB\\Patients\\RegisteredDoctors\\{id}.txt");
                string[] doctor = File.ReadAllLines($"DB\\Doctors\\{registeredDoctorID}.txt");
                doctorName = doctor[0].Split(';')[2];
                return $"{fullName,-20} | {doctorName,-20} | {email,-20} | {phone,-5} | {address,-20}";
            }
            else
            {
                return $"{fullName,-20} | {"", -20} | {email,-20} | {phone,-5} | {address,-20}";
            }
        }

        public string ToSave()
        {

           return $"{id};{password};{fullName};{address};{email};{phone}";
        }

        ~Patient()
        {
            Console.WriteLine("Patient object destroyed and clearing memory");
            GC.Collect();
        }

    }
}
