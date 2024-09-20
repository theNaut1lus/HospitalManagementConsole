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
            Utils.Header(labelNames, "-");

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

            //additional processing required to format into table as per specifications
            string[] labelNames = { "Name", "Doctor", "Email Address", "Phone", "Address" };
            Utils.Header(labelNames, "-");

            //Get all patients assigned to this doctor from RegisteredPatients directory
            if (File.Exists($"DB\\Doctors\\RegisteredPatients\\{id}.txt"))
            {
                string[] patients = File.ReadAllLines($"DB\\Doctors\\RegisteredPatients\\{id}.txt");
                foreach (string patient in patients)
                {
                    // for each registered patient, read their respective file and display the details
                    string[] registeredPatient = File.ReadAllLines($"DB\\Patients\\{patient}.txt");
                    string[] registeredPatientDetails = registeredPatient[0].Split(';');
                    Patient p = new Patient(registeredPatientDetails[0], registeredPatientDetails[1], registeredPatientDetails[2], registeredPatientDetails[3], registeredPatientDetails[4], registeredPatientDetails[5], "Patient");
                    Console.WriteLine(p);
                }
            }
            else
            {
                Console.WriteLine("No patients assigned to you.");
            }
            Console.ReadKey();
            Menu();
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

            //additional processing required to format into table as per specifications
            string[] labelNames = { "Doctor", "Patient", "Description" };
            Utils.Header(labelNames, "-");

            //Get all appointments for this doctor from Appointments directory

            if (File.Exists($"DB\\Appointments\\Doctors\\{id}.txt"))
            {
                string[] appointments = File.ReadAllLines($"DB\\\\Appointments\\Doctors\\{id}.txt");
                foreach (string appointment in appointments)
                {
                    // for each appointment within the doctor's file, display the appointment details
                    string[] appointmentDetails = appointment.Split('|');
                    Appointment a = new Appointment(appointmentDetails[0], appointmentDetails[1], appointmentDetails[2]);
                    Console.WriteLine(a);
                }
            }
            else
            {
                Console.WriteLine("No appointments for you.");
            }
            Console.ReadKey();
            Menu();
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
            try
            {
                string patientID = Console.ReadLine() ?? "";
                //validate patient ID format
                if (!Utils.ValidateInput(patientID, "id"))
                {
                    throw new Exception("Invalid ID format, return to menu by pressing any key");
                }
                //Check if patient exists in the Patients directory
                if (File.Exists($"DB\\Patients\\{patientID}.txt"))
                {
                    string[] patientDetails = File.ReadAllText($"DB\\Patients\\{patientID}.txt").Split(';');
                    Console.WriteLine();
                    string[] labelNames = { "Patient", "Doctor", "Email Address", "Phone", "Address" };
                    Utils.Header(labelNames, "-");

                    Patient p = new Patient(patientDetails[0], patientDetails[1], patientDetails[2], patientDetails[3], patientDetails[4], patientDetails[5], "Patient");
                    Console.WriteLine(p);
                }
                else
                {
                    throw new Exception("Patient not found, return to menu by pressing any key");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.ReadKey();
                Menu();
            }
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

            try
            {
                string patientID = Console.ReadLine() ?? "";
                //validate patient ID format
                if (!Utils.ValidateInput(patientID, "id"))
                {
                    throw new Exception("Invalid ID format, return to menu by pressing any key");
                }
                //check if patient exists and is  registered patient of the doctor in patient's registered doctor directory.
                if (File.Exists($"DB\\Patients\\{patientID}.txt"))
                {
                    if (File.Exists($"DB\\Patients\\RegisteredDoctors\\{patientID}.txt"))
                    {
                        string[] registeredDoctors = File.ReadAllLines($"DB\\Patients\\RegisteredDoctors\\{patientID}.txt");
                        // if registeredDoctors contains the doctor's id, then the patient is assigned to the doctor.
                        if (registeredDoctors.Contains(id))
                        {
                            Console.WriteLine();

                            //additional processing required to format into table as per specifications
                            string[] labelNames = { "Doctor", "Patient", "Description" };
                            Utils.Header(labelNames, "-");

                            if (File.Exists($"DB\\Appointments\\Patients\\{patientID}.txt"))
                            {
                                string[] appointments = File.ReadAllLines($"DB\\Appointments\\Patients\\{patientID}.txt");
                                foreach (string appointment in appointments)
                                {
                                    string[] appointmentDetails = appointment.Split('|');
                                    Appointment a = new Appointment(appointmentDetails[0], appointmentDetails[1], appointmentDetails[2]);
                                    Console.WriteLine(a);
                                }
                            }
                            else
                            {
                                Console.WriteLine("No appointments for you.");

                            }
                        }
                        else
                        {
                            throw new Exception("Patient not assigned to you, return to menu by pressing any key");
                        }
                    }
                    else
                    {
                        throw new Exception("No patients assigned to you, return to menu by pressing any key");
                    }
                }
                else
                {
                    throw new Exception("Patient not found, return to menu by pressing any key");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.ReadKey();
                Menu();
            }

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

        public string ToSave()
        {
            return $"{id};{password};{fullName};{address};{email};{phone}";
        }

    }
}
