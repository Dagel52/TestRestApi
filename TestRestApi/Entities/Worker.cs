using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestRestApi.Entities
{
    public record Worker
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public double Age { get; init; }
        public decimal Salary { get; init; }
        public string Position { get; init; }
    }
}
