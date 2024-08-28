﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementConsole
{
    internal class Administrator : User
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

            Console.WriteLine($"Welcome to DOTNET Hospital Managment System {fullname}");
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
                        ListDoctors();
                        break;
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        CheckParticularDoctor();
                        break;
                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        ListPatients();
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

        public void ListDoctors()
        {
            //[TODO]
        }

        public void CheckParticularDoctor()
        {
            //[TODO]
        }

        public void ListPatients()
        {
            //[TODO]
        }

        public void CheckParticularPatient() 
        {
            //[TODO]
        }

        public void AddDoctor()
        {
            //[TODO]
        }

        public void AddPatient()
        {
            //[TODO]
        }
    }
}
