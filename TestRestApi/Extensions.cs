using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestRestApi.DTOs;
using TestRestApi.Entities;

namespace TestRestApi
{
    public static class Extensions
    {
        public static AnimalDto AsDtoAnimal( this Animal animal)
        {
            return new AnimalDto
            {
                Id = animal.Id,
                Name = animal.Name,
                Age = animal.Age,
                Diet = animal.Diet,
                Type = animal.Type
            };
        }

        public static WorkerDto AsDtoWorker(this Worker worker)
        {
            return new WorkerDto
            {
                Id = worker.Id,
                Name = worker.Name,
                Age = worker.Age,
                Salary = worker.Salary,
                Position = worker.Position
            };
        }
    }
}
