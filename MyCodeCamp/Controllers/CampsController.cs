using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyCodeCamp.Data;
using MyCodeCamp.Data.Entities;

namespace MyCodeCamp.Controllers
{
    [Route("api/[controller]")]
    public class CampsController: Controller
    {
        private readonly ICampRepository _repo;

        public CampsController(ICampRepository repo)
        {
            _repo = repo;
        }

        [HttpGet("")]
        public IActionResult Get()
        {
            var camps = _repo.GetAllCamps();

            return Ok(camps);
        }

        [HttpGet("{id}", Name = "CampGet")]
        public IActionResult Get(int id, bool includeSpeakers = false)
        {
            try
            {
                var camp = includeSpeakers ? _repo.GetCampWithSpeakers(id) : _repo.GetCamp(id);

                if (camp == null) return NotFound($"Camp {id} was not found");

                return Ok(camp);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Camp model)
        {
            try
            {
                _repo.Add(model);
                if (await _repo.SaveAllAsync())
                {
                    var newUri = Url.Link("CampGet", new {id = model.Id});

                    return Created(newUri, model);
                }
            }
            catch (Exception)
            {
            }

            return BadRequest();
        }
    }
}