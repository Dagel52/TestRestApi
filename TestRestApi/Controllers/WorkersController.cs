using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestRestApi.DTOs;
using TestRestApi.Entities;
using TestRestApi.Repositories;

namespace TestRestApi.Controllers
{
    [Route("workers")]
    [ApiController]
    public class WorkersController : ControllerBase
    {
        private readonly IWorkersRepository _repository;

        public WorkersController(IWorkersRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<WorkerDto>>> GetWorkersAsync()
        {
            var workers = (await _repository.GetWorkersAsync())
                .Select(workers => workers.AsDtoWorker());

            if (workers is null)
            {
                return NotFound();
            }

            return Ok(workers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<WorkerDto>> GetWorkerAsync(Guid id)
        {
            var worker = await _repository.GetWorkerAsync(id);
            if (worker is null)
            {
                return NotFound();
            }

            return Ok(worker.AsDtoWorker());
        }

        [HttpPost]
        public async Task<ActionResult<WorkerDto>> CreateWorkerAsync(CreateWorkerDto workerDto)
        {
            Worker worker = new()
            {
                Id = Guid.NewGuid(),
                Name = workerDto.Name,
                Age = workerDto.Age,
                Salary = workerDto.Salary,
                Position = workerDto.Position
            };

            await _repository.CreateWorkerAsync(worker);

            return CreatedAtAction(nameof(GetWorkerAsync), new { id = worker.Id }, worker.AsDtoWorker());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateWorkerAsync(Guid id, UpdateWorkerDto workerDto)
        {
            var existingWorker = await _repository.GetWorkerAsync(id);

            if (existingWorker is null)
            {
                return NotFound();
            }

            Worker updatedWorker = existingWorker with
            {
                Name = workerDto.Name,
                Age = workerDto.Age,
                Salary = workerDto.Salary,
                Position = workerDto.Position
            };

            await _repository.UpdateWorkerAsync(updatedWorker);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteWorkerAsync(Guid id)
        {
            var existingWorker = await _repository.GetWorkerAsync(id);

            if (existingWorker is null)
            {
                return NotFound();
            }

            await _repository.DeleteWorkerAsync(id);

            return NoContent();
        }
    }
}
