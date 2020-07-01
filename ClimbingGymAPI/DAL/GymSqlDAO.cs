using ClimbingGymAPI.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

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

                    string sqlQuery = "Select * from Gym";
                    SqlCommand cmd = new SqlCommand(sqlQuery, conn);
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
        public Gym GetGymById(int id)
        {
            Gym gym = new Gym();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string sqlQuery = @"SELECT * FROM Gym WHERE GymId = @id";
                    SqlCommand cmd = new SqlCommand(sqlQuery, conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        gym = DataToRow(rdr);
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Sorry that Gym does not exist.");
            }
            return gym;
        }

        public Gym CreateNewGym(Gym gym)
        {

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sqlQuery = @"Insert Gym (Name, Address, PhoneNumber, Email, MaxCapacity)
                                        Values (@Name, @Address, @PhoneNumber, @Email, @MaxCapacity)";
                SqlCommand cmd = new SqlCommand(sqlQuery, conn);
                cmd.Parameters.AddWithValue("@Name", gym.Name);
                cmd.Parameters.AddWithValue("@Address", gym.Address.ToString());
                cmd.Parameters.AddWithValue("@PhoneNumber", gym.PhoneNumber);
                cmd.Parameters.AddWithValue("@Email", gym.Email);
                cmd.Parameters.AddWithValue("@MaxCapacity", gym.MaxCapacity);
                cmd.ExecuteNonQuery();
            }
            return gym;
        }

        private Gym DataToRow(SqlDataReader rdr)
        {
            Gym gym = new Gym();
            gym.Name = Convert.ToString(rdr["Name"]);
            gym.GymId = Convert.ToInt32(rdr["GymId"]);
            //Parse the address given
            Address address = ParseAddress(Convert.ToString(rdr["address"]));
            gym.Address = address;
            gym.PhoneNumber = Convert.ToString(rdr["Phonenumber"]);
            gym.Email = Convert.ToString(rdr["Email"]);
            gym.MaxCapacity = Convert.ToInt32(rdr["MaxCapacity"]);
            return gym;
        }
        //TODO 3: Write a method to clean up the address on the way to the user
        public Address ParseAddress(string addressInput)
        {
            //The url for the parse
            string API_URL = @"http://api.addresslabs.com/v1/";
            Address address = new Address();
            RestClient client = new RestClient(API_URL);
            RestRequest request = new RestRequest("parsed-address?address=" + addressInput);
            IRestResponse<Address> response = client.Get<Address>(request);
            return response.Data;
        }
    }
}
