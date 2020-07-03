using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClimbingGymAPI.DAL;
using ClimbingGymAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ClimbingGymAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GymController : ControllerBase
    {
        private IGymDAO _gymDAO;
        public GymController(IGymDAO gymDAO)
        {
            this._gymDAO = gymDAO;
        }
        // GET: api/<GymController>
        [HttpGet]
        public ActionResult<List<Gym>> GetGyms()
        {
            return _gymDAO.ListAllGyms();
        }

        // GET api/<GymController>/5
        [HttpGet("{id}")]
        public ActionResult<Gym> Get(int id)
        {
            return _gymDAO.GetGymById(id);
        }
        //TODO 5: Make the gym controller parse the object different.
        // POST api/<GymController>
        [HttpPost]
        public ActionResult<Gym> CreateGym(Gym gym)
        {
            return _gymDAO.CreateNewGym(gym);
        }

        // PUT api/<GymController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<GymController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
