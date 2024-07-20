using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DandN
{
    public class User
    {

        public string UserID { get; set; }
        public string Surname { get; set; }
        public string Fornames { get; set; }
        public string Title { get; set; }
        public string Position { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Location { get; set; }
        public User() { }
        public User(string userID, string surname, string fornames, string title, string position, string phone, string email, string location)
        {
            UserID = userID;
            Surname = surname;
            Fornames = fornames;
            Title = title;
            Position = position;
            Phone = phone;
            Email = email;
            Location = location;


        }








    }
}

