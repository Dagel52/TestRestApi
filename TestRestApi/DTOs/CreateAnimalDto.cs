using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestRestApi.DTOs
{
    public record CreateAnimalDto
    {
        [Required]
        public string Name { get; init; }
        [Required]
        [Range(0,100)]
        public double Age { get; init; }
        [Required]
        public string Diet { get; init; }
        [Required]
        public string Type { get; init; }
    }
}
