using System;

namespace Lupi.Data.Entities
{
    public class Breed
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string HairType { get; set; }
        public string[] HairColors { get; set; }
    }
}
