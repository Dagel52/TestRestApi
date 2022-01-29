using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestRestApi.Entities;

namespace TestRestApi.Repositories
{
    public class InMemAnimalsRepository : IAnimalsRepository
    {
        private readonly List<Animal> _animals = new()
        {
            new Animal { Id = Guid.NewGuid(), Age = 2, Name = "Буся", Diet = "Фрукты", Type = "Капибара" },
            new Animal { Id = Guid.NewGuid(), Age = 0.5, Name = "Джордж", Diet = "Злаки", Type = "Хомяк" },
            new Animal { Id = Guid.NewGuid(), Age = 8, Name = "Алиса", Diet = "Фрукты", Type = "Слон" },
            new Animal { Id = Guid.NewGuid(), Age = 9.6, Name = "Макс", Diet = "Овощи и фрукты", Type = "Альпака" },
            new Animal { Id = Guid.NewGuid(), Age = 11, Name = "Малыш", Diet = "Трава и сено", Type = "Як" }
        };

        public async Task<IEnumerable<Animal>> GetAnimalsAsync()
        {
            return await Task.FromResult(_animals);
        }

        public async Task<Animal> GetAnimalAsync(Guid id)
        {
            var animal = _animals.SingleOrDefault(animals => animals.Id == id);
            return await Task.FromResult(animal);
        }

        public async Task CreateAnimalAsync(Animal animal)
        {
            _animals.Add(animal);
            await Task.CompletedTask;
        }

        public async Task UpdateAnimalAsync(Animal animal)
        {
            var index = _animals.FindIndex(existingAnimal => existingAnimal.Id == animal.Id);
            _animals[index] = animal;
            await Task.CompletedTask;
        }

        public async Task DeleteAnimalAsync(Guid id)
        {
            var index = _animals.FindIndex(existingAnimal => existingAnimal.Id == id);
            _animals.RemoveAt(index);
            await Task.CompletedTask;
        }
    }
}
