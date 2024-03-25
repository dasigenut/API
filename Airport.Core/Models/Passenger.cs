namespace WebApplication1
{
    public class Passenger
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CountryOrigion { get; set; }
        public string distnationCountry { get; set; }
        public int NumBags { get; set; }
        public int IdFlight { get; set; }
        //יחיד לרבים one-to-many
        public Flight Flight { get; set; }
    }
}
