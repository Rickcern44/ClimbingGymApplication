using ClimbingGymAPI.Models;
using System.Collections.Generic;

namespace ClimbingGymAPI.DAL
{
    public interface IGymDAO
    {
        List<Gym> ListAllGyms();
    }
}