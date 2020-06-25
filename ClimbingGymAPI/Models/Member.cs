using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClimbingGymAPI.Models
{
    //Going To have to rework this later 
    public class Member
    {
        public int Membernumber { get; set; }
        public int GymId { get; set; }
        public string Password { get; set; }
        public int UserId { get; set; }
    }
}
