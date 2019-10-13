using System;
namespace HelpdeskCRUDAPI.Models
{
    public class User
    {
        public int id
        {
            get;
            set;
        }
        public string email
            {

            get;
            set;

        }
        public string password
        {
            get;
            set;
        }
        public Boolean accountType
        {

            get;
            set;

        }

        public User()
        {

        }
    }
}
