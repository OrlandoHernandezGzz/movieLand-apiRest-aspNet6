using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieLandAPI.DTOs;
using MovieLandAPI.Models;
using MovieLandAPI.Services;

namespace MovieLandAPI.Controllers
{
    [ApiController]
    [Route("api/actors")]
    public class ActorsController: ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        private readonly IFileStorage fileStorage;
        private readonly string container = "actors";

        public ActorsController(
            ApplicationDbContext context,
            IMapper mapper,
            IFileStorage fileStorage
        ) {
            this.context = context;
            this.mapper = mapper;
            this.fileStorage = fileStorage;
        }

        [HttpGet]
        public async Task<ActionResult<List<ActorDTO>>> Get()
        {
            var actors = await context.Actors.ToListAsync();
            return mapper.Map<List<ActorDTO>>(actors);
        }

        [HttpGet("{id:int}", Name = "getActor")]
        public async Task<ActionResult<ActorDTO>> Get(int id)
        {
            var actor = await context.Actors.FirstOrDefaultAsync(actorDB => actorDB.Id == id);

            if (actor == null) return NotFound();

            return mapper.Map<ActorDTO>(actor);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromForm] CreationActorDTO creationActorDTO)
        {
            var actor = mapper.Map<Actor>(creationActorDTO);

            if (creationActorDTO.Photo != null)
            {
                using var memoryStream = new MemoryStream();
                 
                await creationActorDTO.Photo.CopyToAsync(memoryStream);
                var content = memoryStream.ToArray();
                var extension = Path.GetExtension(creationActorDTO.Photo.FileName);
                actor.Photo = await fileStorage.SaveFile(content, extension, container, creationActorDTO.Photo.ContentType);
            }

            context.Add(actor);
            await context.SaveChangesAsync();

            var actorDTO = mapper.Map<ActorDTO>(actor);

            return new CreatedAtRouteResult("getActor", new { id = actorDTO.Id }, actorDTO);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromForm] CreationActorDTO creationActorDTO)
        {
            var actorDB = await context.Actors.FirstOrDefaultAsync(x => x.Id == id);
            
            if (actorDB == null) return NotFound();

            actorDB = mapper.Map(creationActorDTO, actorDB);

            if (creationActorDTO.Photo != null)
            {
                using var memoryStream = new MemoryStream();

                await creationActorDTO.Photo.CopyToAsync(memoryStream);
                var content = memoryStream.ToArray();
                var extension = Path.GetExtension(creationActorDTO.Photo.FileName);
                actorDB.Photo = await fileStorage.EditFile(content, extension, container, 
                    actorDB.Photo, creationActorDTO.Photo.ContentType);
            }

            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existActor = await context.Actors
                .AnyAsync(actorDB => actorDB.Id == id);

            if (!existActor) return NotFound();

            context.Remove(new Actor() { Id = id });
            await context.SaveChangesAsync();
            return NoContent();
        }

    }
}
