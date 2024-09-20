using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementConsole
{
    public class Appointment
    {
        private string doctorID, patientID, description;
        public Appointment(string doctorID, string patientID, string description)
        {
            this.doctorID = doctorID;
            this.patientID = patientID;
            this.description = description;
        }

        // Getter and Setter for DoctorID, PatientID and Description
        public string DoctorID
        {
            get { return doctorID; }
            set { doctorID = value; }
        }

        public string PatientID
        {
            get { return patientID; }
            set { patientID = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        // Override ToString method to display appointment details, when used in Console.WriteLine
        public override string ToString()
        {
            string[] doctorInfo = File.ReadAllLines($"DB\\Doctors\\{doctorID}.txt");
            string doctorName = doctorInfo[0].Split(';')[2];

            string[] patientInfo = File.ReadAllLines($"DB\\Patients\\{patientID}.txt");
            string patientName = patientInfo[0].Split(';')[2];

            return $"{doctorName,-20} | {patientName,-20} | {description,-20}";
        }
        public string ToSave()
        {

            return $"{doctorID}|{patientID}|{description}\n";
        }

        ~Appointment()
        {
            Console.WriteLine("Appointment object destroyed and clearing memory");
            GC.Collect();

        }
    }
}
