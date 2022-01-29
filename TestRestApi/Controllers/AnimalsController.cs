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
    [Route("animals")]
    [ApiController]
    public class AnimalsController : ControllerBase
    {
        private readonly IAnimalsRepository _repository;

        public AnimalsController(IAnimalsRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AnimalDto>>> GetAnimalsAsync()
        {
            var animals = (await _repository.GetAnimalsAsync())
                .Select(animal => animal.AsDtoAnimal());

            if (animals is null)
            {
                return NotFound();
            }

            return Ok(animals);
        }   
        
        [HttpGet("{id}")]
        public async Task<ActionResult<AnimalDto>> GetAnimalAsync(Guid id)
        {
            var animal = await _repository.GetAnimalAsync(id);
            if (animal is null)
            {
                return NotFound();
            }

            return Ok(animal.AsDtoAnimal());
        }

        [HttpPost]
        public async Task<ActionResult<AnimalDto>> CreateAnimalAsync(CreateAnimalDto animalDto)
        {
            Animal animal = new()
            {
                Id = Guid.NewGuid(),
                Name = animalDto.Name,
                Age = animalDto.Age,
                Diet = animalDto.Diet,
                Type = animalDto.Type
            };

            await _repository.CreateAnimalAsync(animal);

            return CreatedAtAction(nameof(GetAnimalAsync), new { id = animal.Id }, animal.AsDtoAnimal());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAnimalAsync(Guid id, UpdateAnimalDto animalDto)
        {
            var existingAnimal = await _repository.GetAnimalAsync(id);

            if (existingAnimal is null)
            {
                return NotFound();
            }

            Animal updatedAnimal = existingAnimal with
            {
                Name = animalDto.Name,
                Age = animalDto.Age,
                Diet = animalDto.Diet,
                Type = animalDto.Type
            };

            await _repository.UpdateAnimalAsync(updatedAnimal);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAnimalAsync(Guid id)
        {
            var existingAnimal = await _repository.GetAnimalAsync(id);

            if (existingAnimal is null)
            {
                return NotFound();
            }

            await _repository.DeleteAnimalAsync(id);

            return NoContent();
        }
    }
}
