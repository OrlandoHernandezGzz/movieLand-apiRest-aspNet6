using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieLandAPI.DTOs;
using MovieLandAPI.Models;

namespace MovieLandAPI.Controllers
{
    [ApiController]
    [Route("api/genders")]
    public class GendersController: ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public GendersController(
            ApplicationDbContext context,
            IMapper mapper
        ) {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<GenderDTO>>> Get()
        {
            var genders = await context.Genders.ToListAsync();
            return mapper.Map<List<GenderDTO>>(genders);
        }

        [HttpGet("{id:int}", Name = "getGender")]
        public async Task<ActionResult<GenderDTO>> Get(int id)
        {
            var gender = await context.Genders
                .FirstOrDefaultAsync(genderDB => genderDB.Id == id);

            if (gender == null) return NotFound();

            return mapper.Map<GenderDTO>(gender);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreationGenderDTO creationGenderDTO)
        {
            var gender = mapper.Map<Gender>(creationGenderDTO);
            context.Add(gender);
            await context.SaveChangesAsync();

            var genderDTO = mapper.Map<GenderDTO>(gender);

            return new CreatedAtRouteResult("getGender", new { id = genderDTO.Id }, genderDTO);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] CreationGenderDTO creationGenderDTO)
        {
            var existGender = await context.Genders
                .AnyAsync(genderDB => genderDB.Id == id);

            if (!existGender) return NotFound();

            var gender = mapper.Map<Gender>(creationGenderDTO);
            gender.Id = id;

            context.Entry(gender).State = EntityState.Modified;
            await context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existGender = await context.Genders
                .AnyAsync(genderDB => genderDB.Id == id);

            if (!existGender) return NotFound();

            context.Remove(new Gender() { Id = id });
            await context.SaveChangesAsync();   
            return NoContent(); 
        }

    }
}
