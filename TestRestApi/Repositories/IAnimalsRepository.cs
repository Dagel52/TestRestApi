using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestRestApi.Entities;

namespace TestRestApi.Repositories
{
    public interface IAnimalsRepository
    {
        Task<Animal> GetAnimalAsync(Guid id);
        Task<IEnumerable<Animal>> GetAnimalsAsync();
        Task CreateAnimalAsync(Animal animal);
        Task UpdateAnimalAsync(Animal animal);
        Task DeleteAnimalAsync(Guid id);

    }
}