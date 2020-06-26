using ClimbingGymAPI.Models;
using Microsoft.AspNetCore.Connections;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;

namespace ClimbingGymAPI.DAL
{
    public class GymSqlDAO : IGymDAO
    {
        private string connectionString;

        public GymSqlDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Gym> ListAllGyms()
        {
            List<Gym> allGyms = new List<Gym>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sqlCommand = "Select * from Gym";
                    SqlCommand cmd = new SqlCommand(sqlCommand, conn);
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        Gym gym = DataToRow(rdr);
                        allGyms.Add(gym);
                    }
                }

            }
            catch (SqlException ex)
            {
                //TODO 1: Implement logging here instead of a cw 
                Console.WriteLine($"There was an error connecting to the Database {ex.Message}");
            }
            return allGyms;
        }

        private static Gym DataToRow(SqlDataReader rdr)
        {
            Gym gym = new Gym();
            gym.GymId = Convert.ToInt32(rdr["Gym Id"]);
            gym.Name = Convert.ToString(rdr["Name"]);
            //Split the Address up by spaces
            string addressString = (rdr["Address1"]).ToString();
            string[] splitAddress = addressString.Split(" ");
            string address1 = splitAddress[0] + " " + splitAddress[1] + " " + splitAddress[2];
            Address address = new Address(gym.GymId, address1, null, splitAddress[3], splitAddress[4], splitAddress[5]);
            //Constinue adding the 
            gym.Address = address;
            gym.PhoneNumber = Convert.ToString(rdr["Phone Number"]);
            gym.MaxCapacity = Convert.ToInt32(rdr["Max Capacity"]);
            gym.Email = Convert.ToString(rdr["Email"]);
            gym.DayPrice = Convert.ToDecimal(rdr["Day Price"]);
            return gym;
        }
        //TODO 3: Write a method to clean up the address on the way to the user
    }
}
