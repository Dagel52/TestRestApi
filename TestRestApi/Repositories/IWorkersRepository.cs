using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestRestApi.Entities;

namespace TestRestApi.Repositories
{
    public interface IWorkersRepository
    {
        Task<Worker> GetWorkerAsync(Guid id);
        Task<IEnumerable<Worker>> GetWorkersAsync();

        Task CreateWorkerAsync(Worker worker);
        Task UpdateWorkerAsync(Worker worker);
        Task DeleteWorkerAsync(Guid id);
    }
}