namespace ClimbingGymAPI.Models
{
    public class Address
    {
        //Constructor 
        public Address()
        {

        }

        public string Number { get; set; }
        public string Street { get; set; }
        public string StreetSuffix { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public override string ToString()
        {
            return $"{Number} {Street} {StreetSuffix} {City} {State} {Zip}";
        }
    }
    
}
