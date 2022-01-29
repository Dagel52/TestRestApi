using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestRestApi.Entities
{
    public record Animal
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public double Age { get; init; }
        public string Diet {get; init;}
        public string Type { get; init; }
    }
}
