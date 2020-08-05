using System;

namespace kafkaAndDbPairing.domain.entity
{
    public class Employee
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
