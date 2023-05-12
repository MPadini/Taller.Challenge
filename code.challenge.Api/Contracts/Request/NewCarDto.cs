namespace code.challenge.Api.Contracts.Request
{
    public class NewCarDto
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public int Doors { get; set; }
        public string Color { get; set; }
        public float Price { get; set; }
    }
}
