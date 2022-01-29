using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestRestApi.DTOs
{
    public record CreateWorkerDto
    {
        [Required]
        public string Name { get; init; }
        [Required]
        [Range(16,65)]
        public double Age { get; init; }
        [Required]
        [Range(13500,150000)]
        public decimal Salary { get; init; }
        [Required]
        public string Position { get; init; }
    }
}
