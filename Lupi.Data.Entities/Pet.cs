using System;

namespace Lupi.Data.Entities
{
    public class Pet
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Size { get; set; }
        public DateTime BirthDate { get; set; }
        public double Weight { get; set; }
        public Collar AssignedCollar { get; set; }
        public Breed Breed { get; set; }
        public Base64Image Image { get; set; }
    }
}
