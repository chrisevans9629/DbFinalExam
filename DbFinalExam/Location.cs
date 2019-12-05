namespace DbFinalExam
{
    public class Location
    {
        public int LocationId { get; set; }
        public int CustomerId { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string Telephone { get; set; }
        public int BuildingSize { get; set; }
        public string State { get; set; }
        public string Address { get; set; }

        public override string ToString()
        {
            return Address;
        }
    }
}
