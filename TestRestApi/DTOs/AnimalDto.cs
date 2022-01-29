using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestRestApi.DTOs
{
    public record AnimalDto
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public double Age { get; init; }
        public string Diet { get; init; }
        public string Type { get; init; }
    }
}
