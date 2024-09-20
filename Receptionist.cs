using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementConsole
{
    internal class Receptionist
    {
        public Receptionist()
        {
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

            string[] labelNames = { "Name", "Email Address", "Phone", "Address" };
            Utils.Header(labelNames, "─");

            //Get all files in the patients directory
            string[] patientFiles = Directory.GetFiles("DB\\Patients");
            if (patientFiles.Length > 0)
            {
                //process each patient file
                foreach (string patient in patientFiles)
                {
                    //Read the file and display the details
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
            Console.WriteLine("│             Patient Details          │");
            Console.WriteLine("│                                      │");
            Console.WriteLine("└──────────────────────────────────────┘");
            Console.WriteLine();

            Console.WriteLine("Enter the Patient ID to check details: ");
            string patientID = Console.ReadLine();

            //Check if the patient file exists
            if (File.Exists($"DB\\Patients\\{patientID}.txt"))
            {
                //Read the file and display the details
                string[] patientDetails = File.ReadAllText($"DB\\Patients\\{patientID}.txt").Split(';');
                Patient p = new Patient(patientDetails[0], patientDetails[1], patientDetails[2], patientDetails[3], patientDetails[4], patientDetails[5], "Patient");
                Console.WriteLine(p);
            }
            else
            {
                Console.WriteLine("Patient not found.");
            }
            Console.ReadKey();
            Menu();
        }

        public void Menu() { }

    }
}
