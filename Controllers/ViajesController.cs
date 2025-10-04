using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ViajesAPI.Models;
using ViajesAPI.Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ViajesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ViajesController : ControllerBase
    {
        private readonly IViajeService _viajeService;
        public ViajesController(IViajeService viajeService)
        {
            _viajeService = viajeService;
        }
        // GET: api/<ViajesController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _viajeService.GetAll());
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno");
            }
            
        }

        // GET api/<ViajesController>/5
        [HttpGet("{estado}")]
        public async Task<IActionResult> Get(string estado)
        {
            try
            {
                return Ok(await _viajeService.GetByEstado(estado));
            }
            catch(Exception)
            {
                return StatusCode(500, "Error interno");
            }
            
        }

        // POST api/<ViajesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ViajesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromQuery] int id, [FromBody] Viaje viaje)
        {
            return Ok(await _viajeService.ActualizarFecha(viaje,id));
        }

        // DELETE api/<ViajesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
