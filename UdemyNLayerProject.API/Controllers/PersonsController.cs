using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UdemyNLayerProject.Core.Model;
using UdemyNLayerProject.Core.Services;

namespace UdemyNLayerProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly IService<Person> _service;
        private readonly IMapper _mapper;
        public PersonsController(IService<Person> service,IMapper mapper)
        {
            _mapper = mapper;
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var person = await _service.GetAllAsync();
            return Ok(person);
        }

        [HttpPost]
        public async Task<IActionResult> Save(Person person)
        {
            var neperson = await _service.AddAsync(person);
            return Created(string.Empty, neperson);
        }
    }
}
