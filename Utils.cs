using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

//MailKit external Package to perform Email outs
using MailKit.Net.Smtp;
using MimeKit;
using MailKit;

namespace HospitalManagementConsole
{
    internal static class Utils
    {
        //Using a separate method for generating header design with labels and divider values passed through.
        public static void Header(string[] labelNames, string divider)
        {
            //build header using labelNames string[] being passed through
            string header = "";
            //loop through labelNames and add to header string
            for (int i = 0; i < labelNames.Length; i++)
            {
                //for 'Phone' need a smaller width, to match specifications
                if (labelNames[i] == "Phone")
                {
                    header += $"{labelNames[i],-10}";
                }
                //rest have standard padding of 20
                else header += $"{labelNames[i],-20}";

                //add divider between labels
                if (i != labelNames.Length - 1)
                {
                    header += " | ";
                }
            }
            // Anonymous function: set a divider that will match the length of the headers
            divider = new('─', header.Length + 15);

            Console.WriteLine(header);
            Console.WriteLine(divider);
        }

        //build a static method for doing validation on different types of input types such as email, id, phone, etc.
        public static bool ValidateInput(string input, string type)
        {
            //switch statement to handle different types of input
            switch (type)
            {
                //case for email
                case "Email":
                    //use built in email validation
                    try
                    {
                        var addr = new System.Net.Mail.MailAddress(input);
                        return addr.Address == input;
                    }
                    catch
                    {
                        return false;
                    }
                //case for id
                case "id":
                    //check if input is a valid id: type int and 5 digits long
                    return int.TryParse(input, out _) && input.Length == 5;
                //case for phone
                case "Phone":
                    //check if input is a valid mobile number: type int and is 10 digits long
                    return int.TryParse(input, out _) && input.Length == 10;
                //default case, return true to skip exception
                default:
                    return true;
            }
        }

        //build a static method for sending emails
        public static string SendEmail(string name, string emailAddress, string subject, string body)
        {
            var from = "sidakaulakh@gmail.com";
            //create a new email message
            var message = new MimeMessage();
            //set the sender
            message.From.Add(new MailboxAddress("Hospital Management System", from));
            //set the recipient
            message.To.Add(new MailboxAddress(name, emailAddress));
            //set the subject
            message.Subject = subject;
            //set the body
            message.Body = new TextPart("plain")
            {
                Text = body
            };

            //Extract password from .secret text file in the root directory of the project
            string password = System.IO.File.ReadAllText("..\\..\\..\\.secret");




            using (var client = new SmtpClient())
            {
                //connect to the smtp server
                client.Connect("smtp.gmail.com", 587, false);
                //authenticate with the server
                client.Authenticate("sidakaulakh@gmail.com", password);
                //send the email
                var response = client.Send(message);
                //disconnect from the server
                client.Disconnect(true);
                return response;
            }
        }
    }
}
//ifgo bsrm cykz liuz