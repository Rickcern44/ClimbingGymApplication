using ClimbingGymAPI.Models;
using System.Collections.Generic;

namespace ClimbingGymAPI.DAL
{
    public interface IGymDAO
    {
        Gym CreateNewGym(Gym gym);
        Gym GetGymById(int id);
        List<Gym> ListAllGyms();
        Address ParseAddress(string addressInput);
    }
}