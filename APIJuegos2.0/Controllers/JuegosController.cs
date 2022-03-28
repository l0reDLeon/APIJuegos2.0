using APIJuegos2._0.DTOs;
using APIJuegos2._0.Entidades;
using APIJuegos2._0.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIJuegos2._0.Controllers
{
    [ApiController]
    [Route("api/juegos")]
    public class JuegosController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IMapper mapper;
        private readonly IWebHostEnvironment entorno;

        public JuegosController(ApplicationDbContext context, IMapper mapper, IWebHostEnvironment env)
        {
            this.dbContext = context;
            this.mapper = mapper;
            this.entorno = env;
        }

        [HttpGet]
        public async Task<ActionResult<List<GetJuegosDTO>>> Get()
        {
            var juegos = await dbContext.Juegos.ToListAsync();


            return mapper.Map<List<GetJuegosDTO>>(juegos);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<GetJuegosDTO>> Get(int id)
        {
            var alumno = await dbContext.Juegos.FirstOrDefaultAsync(alumnoBD => alumnoBD.Id == id);

            if (alumno == null)
            {
                return NotFound();
            }
            return mapper.Map<GetJuegosDTO>(alumno);

        }

        [HttpGet("{nombre}")]
        public async Task<ActionResult<List<GetJuegosDTO>>> Get([FromRoute] string nombre)
        {
            var juegos = await dbContext.Juegos.Where(juegosBD => juegosBD.Nombre.Contains(nombre)).ToListAsync();
            new EscribirGet(juegos,nombre,entorno);
            return mapper.Map<List<GetJuegosDTO>>(juegos);

        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] JuegosDTO juegosDto)
        {

            var existeJuego = await dbContext.Juegos.AnyAsync(x => x.Nombre == juegosDto.Nombre);

            if (existeJuego)
            {
                return BadRequest($"Ya existe un juego con el nombre {juegosDto.Nombre}");
            }

            var Juego = mapper.Map<Juegos>(juegosDto);

            new EscribirPost("Nombre: " + juegosDto.Nombre,"POST.txt", entorno);
            dbContext.Add(Juego);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(Juegos juego, int id)
        {
            var exist = await dbContext.Juegos.AnyAsync(x => x.Id == id);
            if (!exist)
            {
                return NotFound();
            }

            if (juego.Id != id)
            {
                return BadRequest("El id del juego no coincide con el establecido en la url.");
            }

            dbContext.Update(juego);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var exist = await dbContext.Juegos.AnyAsync(x => x.Id == id);
            if (!exist)
            {
                return NotFound("El recurso no fue encontrado.");
            }

            dbContext.Remove(new Juegos()
            {
                Id = id
            });
            await dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
