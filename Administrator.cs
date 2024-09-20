using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementConsole
{
    internal class Administrator : User
    {

        public Administrator(string id, string password, string fullname, string role) : base(id, password, fullname, role)
        {
        }

        public void ListAllDoctors()
        {
            Console.Clear();
            Console.WriteLine("┌──────────────────────────────────────┐");
            Console.WriteLine("│                                      │");
            Console.WriteLine("│   DOTNET Hospital Managment System   │");
            Console.WriteLine("│──────────────────────────────────────│");
            Console.WriteLine("│              All Doctors             │");
            Console.WriteLine("│                                      │");
            Console.WriteLine("└──────────────────────────────────────┘");
            Console.WriteLine();

            Console.WriteLine("All doctors registered to the DOTNET Hospital Management System");
            Console.WriteLine();

            string[] labelNames = { "Name", "Email Address", "Phone", "Address" };
            Utils.Header(labelNames, "─");

            //Get all files in the doctors directory
            string[] doctorFiles = Directory.GetFiles("DB\\Doctors");
            if (doctorFiles.Length > 0)
            {
                //process each doctor file
                foreach (string doctor in doctorFiles)
                {
                    //Read the file and display the details
                    string[] doctorDetails = File.ReadAllText(doctor).Split(';');
                    Doctor d = new Doctor(doctorDetails[0], doctorDetails[1], doctorDetails[2], doctorDetails[3], doctorDetails[4], doctorDetails[5], "Doctor");
                    Console.WriteLine(d);

                }
            }
            Console.ReadKey();
            Menu();
        }

        public void CheckParticularDoctor()
        {
            Console.Clear();
            Console.WriteLine("┌──────────────────────────────────────┐");
            Console.WriteLine("│                                      │");
            Console.WriteLine("│   DOTNET Hospital Managment System   │");
            Console.WriteLine("│──────────────────────────────────────│");
            Console.WriteLine("│             Doctor Details           │");
            Console.WriteLine("│                                      │");
            Console.WriteLine("└──────────────────────────────────────┘");
            Console.WriteLine();

            Console.WriteLine("Please enter the ID of the doctor who's details you are checking. Or press n to return to menu");

            try
            {
                string doctorID = Console.ReadLine() ?? "";

                //if n is entered, throw an exception to return to menu
                if(doctorID == "n")
                {
                    throw new Exception("Returning to menu");
                }
                //Validate entered doctor ID format
                else if (!Utils.ValidateInput(doctorID, "id"))
                {
                    throw new Exception("Entered Doctor ID is in an incorrect format, press any key to try again");
                }
                //Check if the doctor file exists for entered ID
                else if (File.Exists($"DB\\Doctors\\{doctorID}.txt"))
                {
                    //read the file and display the details
                    string[] doctorInfo = File.ReadAllText($"DB\\Doctors\\{doctorID}.txt").Split(';');
                    Doctor d = new Doctor(doctorInfo[0], doctorInfo[1], doctorInfo[2], doctorInfo[3], doctorInfo[4], doctorInfo[5], "Doctor");
                    Console.WriteLine();
                    Console.WriteLine($"Details for {d.fullName}");
                    Console.WriteLine();

                    string[] labelNames = { "Name", "Email Address", "Phone", "Address" };
                    Utils.Header(labelNames, "─");
                    Console.WriteLine(d);
                    Console.ReadKey();
                    Menu();
                }
                else
                {
                    throw new Exception("Doctor not found, press any key to try again");
                }

            }
            catch (Exception e)
            {
                if (e.Message == "Doctor not found, press any key to try again")
                {
                    Console.WriteLine();
                    Console.WriteLine(e.Message);
                    Console.ReadKey();
                    CheckParticularDoctor();
                }
                else if (e.Message == "Returning to menu")
                {
                    Console.WriteLine();
                    Console.WriteLine(e.Message);
                    Console.ReadKey();
                    Menu();
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine(e.Message);
                    Console.ReadKey();
                    CheckParticularDoctor();
                }
            }
        }

        public void ListAllPatients()
        {
            Console.Clear();
            Console.WriteLine("┌──────────────────────────────────────┐");
            Console.WriteLine("│                                      │");
            Console.WriteLine("│   DOTNET Hospital Managment System   │");
            Console.WriteLine("│──────────────────────────────────────│");
            Console.WriteLine("│              All Patients            │");
            Console.WriteLine("│                                      │");
            Console.WriteLine("└──────────────────────────────────────┘");
            Console.WriteLine();

            Console.WriteLine("All patients registered to the DOTNET Hospital Management System");
            Console.WriteLine();

            string[] labelNames = { "Name", "Doctor", "Email Address", "Phone", "Address" };
            Utils.Header(labelNames, "─");

            string[] patientFiles = Directory.GetFiles("DB\\Patients");
            if (patientFiles.Length > 0)
            {
                foreach (string patient in patientFiles)
                {
                    string[] patientDetails = File.ReadAllText(patient).Split(';');
                    Patient p = new Patient(patientDetails[0], patientDetails[1], patientDetails[2], patientDetails[3], patientDetails[4], patientDetails[5], "Patient");
                    Console.WriteLine(p);

                }
            }
            Console.ReadKey();
            Menu();
        }

        public void CheckParticularPatient()
        {
            Console.Clear();
            Console.WriteLine("┌──────────────────────────────────────┐");
            Console.WriteLine("│                                      │");
            Console.WriteLine("│   DOTNET Hospital Managment System   │");
            Console.WriteLine("│──────────────────────────────────────│");
            Console.WriteLine("│            Patient Details           │");
            Console.WriteLine("│                                      │");
            Console.WriteLine("└──────────────────────────────────────┘");
            Console.WriteLine();

            Console.WriteLine("Please enter the ID of the patient who's details you are checking. Or press n to return to menu");

            try
            {
                string patientID = Console.ReadLine() ?? "";

                //if n is entered, throw an exception to return to menu
                if (patientID == "n")
                {
                    throw new Exception("Returning to menu");
                }
                //Check if the patient ID is empty or not a number, then through an exception and retry.
                else if (!Utils.ValidateInput(patientID, "id"))
                {
                    throw new Exception("Entered Doctor ID is in an incorrect format, press any key to try again");
                }
                //Check if the patient file exists for entered ID
                else if (File.Exists($"DB\\Patients\\{patientID}.txt"))
                {
                    //read the file and display the details
                    string[] patientInfo = File.ReadAllText($"DB\\Patients\\{patientID}.txt").Split(';');
                    Patient p = new Patient(patientInfo[0], patientInfo[1], patientInfo[2], patientInfo[3], patientInfo[4], patientInfo[5], "Patient");
                    Console.WriteLine();
                    Console.WriteLine($"Details for {p.fullName}");
                    Console.WriteLine();

                    string[] labelNames = { "Name", "Doctor", "Email Address", "Phone", "Address" };
                    Utils.Header(labelNames, "─");
                    Console.WriteLine(p);
                    Console.ReadKey();
                    Menu();
                }
                else
                {
                    throw new Exception("Patient not found, press any key to try again");
                }

            }
            catch (Exception e)
            {
                if (e.Message == "Patient not found, press any key to try again")
                {
                    Console.WriteLine();
                    Console.WriteLine(e.Message);
                    Console.ReadKey();
                    CheckParticularPatient();
                }
                else if (e.Message == "Returning to menu")
                {
                    Console.WriteLine();
                    Console.WriteLine(e.Message);
                    Console.ReadKey();
                    Menu();
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine(e.Message);
                    Console.ReadKey();
                    CheckParticularPatient();
                }
            }
        }

        public void AddDoctor()
        {
            Console.Clear();
            Console.WriteLine("┌──────────────────────────────────────┐");
            Console.WriteLine("│                                      │");
            Console.WriteLine("│   DOTNET Hospital Managment System   │");
            Console.WriteLine("│──────────────────────────────────────│");
            Console.WriteLine("│              Add Doctor              │");
            Console.WriteLine("│                                      │");
            Console.WriteLine("└──────────────────────────────────────┘");
            Console.WriteLine();

            Console.WriteLine("Registering a new doctor with the DOTNET Hospital Management System");
            Console.WriteLine();

            
            //Dictionary to store doctor details initially to be entered via console, easier to loop, manage.
            Dictionary<string, string> doctorDetails = new Dictionary<string, string>()
            {
                {"Password", ""},
                {"First Name", ""},
                {"Last Name", ""},
                {"Email", ""},
                {"Phone", ""},
                {"Street Number", "" },
                {"Street", "" },
                {"City", "" },
                {"State", "" },
                {"Postcode", "" }
            };

            try
            {
                //Loop through each detail in the dictionary and ask for input, if empty throw an exception and retry.
                foreach (KeyValuePair<string, string> detail in doctorDetails)
                {
                    //Ask for input, input name from dictionary key
                    Console.WriteLine($"Please enter the {detail.Key}");
                    //store input in dictionary value
                    doctorDetails[detail.Key] = Console.ReadLine() ?? "";
                    //if null or empty, throw exception
                    if (string.IsNullOrEmpty(doctorDetails[detail.Key]))
                    {
                        throw new Exception($"{detail.Key} cannot be empty, press any key to try again");
                    }
                    //Check if email/phone is in correct format, if not, throw exception, default to true for other inputs.
                    else if (!Utils.ValidateInput(doctorDetails[detail.Key], detail.Key))
                    {
                        throw new Exception("Invalid format, press any key to try again");
                    }
                }

                //Generate a random doctor ID, check if it exists, if it does, keep generating a new one, until found a unique.
                Random randomGenerator = new Random();
                int doctorID = randomGenerator.Next(10000, 99999);
                while (File.Exists($"DB\\Doctors\\{doctorID}.txt"))
                {
                    doctorID = randomGenerator.Next(10000, 99999);
                }

                //Create an address string from the street number, street, city, state and postcode.
                string address = $"{doctorDetails["Street Number"]} {doctorDetails["Street"]}, {doctorDetails["City"]} {doctorDetails["State"]} {doctorDetails["Postcode"]}";
                //Create a full name string from the first name and last name.
                string fullName = doctorDetails["First Name"] + " " + doctorDetails["Last Name"];

                //Create a new doctor object with the entered doctor ID, password, full name, address, email, phone and role.
                Doctor d = new Doctor(doctorID.ToString(), doctorDetails["Password"], doctorDetails["First Name"] + " " + doctorDetails["Last Name"],address ,doctorDetails["Email"], doctorDetails["Phone"], "Doctor");

                //Write the doctor object to a file with the doctor ID as the file name. using the ToSave method to save the object in a string format with ; delimitar.
                File.WriteAllText($"DB\\Doctors\\{doctorID}.txt", d.ToSave());

                //Double check to ensure file was created, if so, display a success message and return to menu.
                if (File.Exists($"DB\\Doctors\\{doctorID}.txt"))
                {
                    Console.WriteLine();
                    Console.WriteLine($"Dr. {d.fullName} added to the system!");
                    Console.ReadKey();
                    Menu();
                }
                else
                {
                    throw new Exception("Doctor not added, press any key to try again");
                }

            }
            //generic exception catch, to display the error message and retry the method.
            catch (Exception e)
            {
                Console.WriteLine();
                Console.WriteLine(e.Message);
                Console.ReadKey();
                AddDoctor();
            }
        }

        public void AddPatient()
        {
            Console.Clear();
            Console.WriteLine("┌──────────────────────────────────────┐");
            Console.WriteLine("│                                      │");
            Console.WriteLine("│   DOTNET Hospital Managment System   │");
            Console.WriteLine("│──────────────────────────────────────│");
            Console.WriteLine("│              Add Patient             │");
            Console.WriteLine("│                                      │");
            Console.WriteLine("└──────────────────────────────────────┘");
            Console.WriteLine();

            Console.WriteLine("Registering a new patient with the DOTNET Hospital Management System");
            Console.WriteLine();

            
            //Dictionary to store doctor details initially to be entered via console, easier to loop, manage.
            Dictionary<string, string> patientDetails = new Dictionary<string, string>()
            {
                {"Password", ""},
                {"First Name", ""},
                {"Last Name", ""},
                {"Email", ""},
                {"Phone", ""},
                {"Street Number", "" },
                {"Street", "" },
                {"City", "" },
                {"State", "" },
                {"Postcode", "" }
            };

            try
            {
                //Loop through each detail in the dictionary and ask for input, if empty throw an exception and retry.
                foreach (KeyValuePair<string, string> detail in patientDetails)
                {
                    //Ask for input, input name from dictionary key
                    Console.WriteLine($"Please enter the {detail.Key}");
                    //store input in dictionary value
                    patientDetails[detail.Key] = Console.ReadLine() ?? "";
                    //if null or empty, throw exception
                    if (string.IsNullOrEmpty(patientDetails[detail.Key]))
                    {
                        throw new Exception($"{detail.Key} cannot be empty, press any key to try again");
                    }
                    //Check if email/phone is in correct format, if not, throw exception, default to true for other inputs.
                    else if (!Utils.ValidateInput(patientDetails[detail.Key], detail.Key))
                    {
                        throw new Exception("Invalid format, press any key to try again");
                    }
                }

                //Generate a random patient ID, check if it exists, if it does, keep generating a new one, until found a unique.
                Random randomGenerator = new Random();
                int patientID = randomGenerator.Next(10000, 99999);
                while (File.Exists($"DB\\Patients\\{patientID}.txt"))
                {
                    patientID = randomGenerator.Next(10000, 99999);
                }

                //Create an address string from the street number, street, city, state and postcode.
                string address = $"{patientDetails["Street Number"]} {patientDetails["Street"]}, {patientDetails["City"]} {patientDetails["State"]} {patientDetails["Postcode"]}";
                //Create a full name string from the first name and last name.
                string fullName = patientDetails["First Name"] + " " + patientDetails["Last Name"];

                //Create a new patient object with the entered patient ID, password, full name, address, email, phone and role.
                Patient p = new Patient(patientID.ToString(), patientDetails["Password"], fullName, address, patientDetails["Email"], patientDetails["Phone"], "Patient");

                //Write the patient object to a file with the patient ID as the file name. using the ToSave method to save the object in a string format with ; delimitar.
                File.WriteAllText($"DB\\Patients\\{patientID}.txt", p.ToSave());

                //Double check to ensure file was created, if so, display a success message and return to menu.
                if (File.Exists($"DB\\Patients\\{patientID}.txt"))
                {
                    Console.WriteLine();
                    Console.WriteLine($"{p.fullName} added to the system!");
                    Console.ReadKey();
                    Menu();
                }
                else
                {
                    throw new Exception("Patient not added, press any key to try again");
                }

            }
            //generic exception catch, to display the error message and retry the method.
            catch (Exception e)
            {
                Console.WriteLine();
                Console.WriteLine(e.Message);
                Console.ReadKey();
                AddPatient();
            }
        }

        public override void Menu()
        {
            Console.Clear();
            Console.WriteLine("┌──────────────────────────────────────┐");
            Console.WriteLine("│                                      │");
            Console.WriteLine("│   DOTNET Hospital Managment System   │");
            Console.WriteLine("│──────────────────────────────────────│");
            Console.WriteLine("│             Administrator Menu       │");
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
                        ListAllDoctors();
                        break;
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        CheckParticularDoctor();
                        break;
                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        ListAllPatients();
                        break;
                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:
                        CheckParticularPatient();
                        break;
                    case ConsoleKey.D5:
                    case ConsoleKey.NumPad5:
                        AddDoctor();
                        break;
                    case ConsoleKey.D6:
                    case ConsoleKey.NumPad6:
                        AddPatient();
                        break;
                    case ConsoleKey.D7:
                    case ConsoleKey.NumPad7:
                        Console.Clear();
                        Program.Main([]);
                        break;
                    case ConsoleKey.D8:
                    case ConsoleKey.NumPad8:
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
