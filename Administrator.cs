using System;
using System.Collections.Generic;
using System.Linq;
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

            string doctorID = Console.ReadLine() ?? "";
            //[TODO]: Search and display a doctor
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

            string patientID = Console.ReadLine() ?? "";

            //[TODO] : Search and display a patient
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

            //[TODO] : Add a doctor
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

            //[TODO] : Add a patient
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
                        //[TODO]: find a way to go back to main menu
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
