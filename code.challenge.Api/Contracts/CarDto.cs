﻿namespace code.challenge.Api.Contracts
{
    public class CarDto
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public int Doors { get; set; }
        public string Color { get; set; }
        public float Price { get; set; }
    }
}
