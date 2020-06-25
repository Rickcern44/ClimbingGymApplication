using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClimbingGymAPI.Models
{
    public class Person
    {
        public int Id { get; set; }
        public int GymId { get; set; }
        public string Name { get; set; }
        public Address Address{ get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public bool Member { get; set; }
    }
}
