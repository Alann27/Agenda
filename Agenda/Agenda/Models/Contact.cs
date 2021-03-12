using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Agenda.Models
{
    public class Contact
    {
        public Contact(string name, string phoneNumber)
        {
            Name = name;
            PhoneNumber = phoneNumber;
            FirstLetterName = name.Length >= 1 ? name.Substring(0, 1).ToUpper() : "";
            PhotoContact = "cameraIcon.png";
        }

        public Contact()
        {

        }

        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string FirstLetterName { get; set; }
        //public string PhotoContact { get; set; }
        public ImageSource PhotoContact { get; set; }
    }
}
