using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClimbingGymAPI.Models
{
    public class Address
    {
        //Constructor 
        public Address()
        {

        }
        public Address(int id, string address1, string address2, string city, string state, string zip)
        {
            this.Id = id;
            this.Address1 = address1;
            this.Address2 = address2;
            this.City = city;
            this.State = state;
            this.Zip = zip;
        }
        public int Id { get; set; }
        public string Address1 { get; set; }
        public string? Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
    }
}
