using BackEnd.Models;
using BackEnd.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistritoController : ControllerBase
    {
        IDistritoService DistritoService;

        public DistritoController(IDistritoService distritoService)
        {
            DistritoService = distritoService;
        }

        // GET: api/<DistritoController>
        [HttpGet]
        public IEnumerable<DistritoModel> Get()
        {
            return DistritoService.GetDistritos();
        }

        // GET api/<DistritoController>/5
        [HttpGet("{id}")]
        public DistritoModel Get(int id)
        {
            return DistritoService.GetById(id);
        }

        // POST api/<DistritoController>
        [HttpPost]
        public string Post([FromBody] DistritoModel distrito)
        {
            var result = DistritoService.AddDistrito(distrito);

            if (result)
            {
                return "Distrito Agregada Correctamente.";
            }
            return "Hubo un error al agregar  la entidad.";

        }

        // PUT api/<DistritoController>/5
        [HttpPut]
        public string Put([FromBody] DistritoModel distrito)
        {
            var result = DistritoService.UpdateDistrito(distrito);

            if (result)
            {
                return "Distrito Editada Correctamente.";
            }
            return "Hubo un error al editar  la entidad.";
        }

        // DELETE api/<DistritoController>/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {

            DistritoModel distrito = new DistritoModel { DistritoId = id };
            var result = DistritoService.DeteleDistrito(distrito);

            if (result)
            {
                return "Distrito Eliminada Correctamente.";
            }
            return "Hubo un error al eliminar  la entidad.";

        }
    }
}