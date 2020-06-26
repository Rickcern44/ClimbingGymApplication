using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClimbingGymAPI.Models
{
    public class Gym
    {

        public Gym()
        {
            this.Address =  new Address();
        }
        public int GymId { get; set; }
        public string Name { get; set; }
        public Address Address { get; set; }
        public string PhoneNumber { get; set; }
        public int MaxCapacity { get; set; }
        public int AttendanceCounter { get; set; } = 0;
        public string Email { get; set; }
        public decimal DayPrice { get; set; }
    }
}
