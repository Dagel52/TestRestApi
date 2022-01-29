using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestRestApi.DTOs
{
    public record WorkerDto
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public double Age { get; init; }
        public decimal Salary { get; init; }
        public string Position { get; init; }
    }
}
