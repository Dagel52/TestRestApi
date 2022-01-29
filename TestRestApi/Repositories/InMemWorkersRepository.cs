using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestRestApi.Entities;

namespace TestRestApi.Repositories
{
    public class InMemWorkersRepository : IWorkersRepository
    {
        private readonly List<Worker> _workers = new()
        {
            new Worker { Id = Guid.NewGuid(), Age = 22, Name = "Максим", Salary = 28000, Position = "Уборщик" },
            new Worker { Id = Guid.NewGuid(), Age = 45, Name = "Лидия", Salary = 53000, Position = "Администратор" },
            new Worker { Id = Guid.NewGuid(), Age = 19, Name = "Джордж", Salary = 41000, Position = "Дрессировщик" },
            new Worker { Id = Guid.NewGuid(), Age = 31, Name = "Николай", Salary = 64000, Position = "Директор" },
            new Worker { Id = Guid.NewGuid(), Age = 54, Name = "Петр", Salary = 55000, Position = "Уборщик" }
        };

        public async Task<IEnumerable<Worker>> GetWorkersAsync()
        {
            return await Task.FromResult(_workers);
        }

        public async Task<Worker> GetWorkerAsync(Guid id)
        {
            var worker = _workers.Where(workers => workers.Id == id).SingleOrDefault();
            return await Task.FromResult(worker);
        }

        public async Task CreateWorkerAsync(Worker worker)
        {
            _workers.Add(worker);
            await Task.CompletedTask;
        }

        public async Task UpdateWorkerAsync(Worker worker)
        {
            var index = _workers.FindIndex(existingWorker => existingWorker.Id == worker.Id);
            _workers[index] = worker;
            await Task.CompletedTask;
        }

        public async Task DeleteWorkerAsync(Guid id)
        {
            var index = _workers.FindIndex(existingWorker => existingWorker.Id == id);
            _workers.RemoveAt(index);
            await Task.CompletedTask;
        }
    }
}
