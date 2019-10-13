using System;
namespace HelpdeskCRUDAPI.Models
{
    public class Ticket
    {
        public int id
        {
            get;
            set;
        }
        public string subject   
            {

            get;
            set;

        }
        public string department
        {
            get;
            set;
        }
        public string category
        {

            get;
            set;

        }
        public string comment
        {

            get;
            set;

        }

        public Ticket()
        {

        }
    }
}
