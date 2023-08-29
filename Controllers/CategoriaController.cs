using AluraChallenge___1.Model;
using AluraChallenge___1.Models;
using AluraChallenge___1.Repository;
using AluraChallenge___1.Repository.Context;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace AluraChallenge___1.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoriaController : Controller
    {

        private readonly DataBaseContext dataBaseContext;
        private readonly CategoriaRepository categoriaRepository;

        public CategoriaController(DataBaseContext ctx)
        {
            dataBaseContext = ctx;
            categoriaRepository = new CategoriaRepository(ctx);
        }
        
        [HttpGet]
        public ActionResult<List<CategoriaModel>> Get()
        {
            try
            {
               var lista = categoriaRepository.Listar();
                if (lista != null)
                {
                    Console.WriteLine("Lista das categorias: ");
                    return Ok(lista);
                }else 
                {
                    return NotFound("Lista Não encontrada"); 
                }
            }catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id:int}")]
        public ActionResult<CategoriaModel> Get([FromRoute] int id)
        {
            try
            {
                var categoriaModel = categoriaRepository.Consultar(id);
                if (categoriaModel == null)
                {
                    return NotFound("Categoria não encontrada");
                }
                else
                {
                    return Ok(categoriaModel);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult<CategoriaModel> Post([FromBody] CategoriaModel categoriaModel)
        {
            if (!ModelState.IsValid)
            {
                Console.WriteLine("Modelo invalido!");
            }
            try
            {
                categoriaRepository.Inserir(categoriaModel);
                var location = new Uri(Request.GetEncodedUrl() + categoriaModel.Id);
                return Created(location,categoriaModel);

            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id:int}")]
        public ActionResult<CategoriaModel> Put([FromRoute] int id, [FromBody] CategoriaModel categoriaModel)
        {
            if (!ModelState.IsValid)
            {
                Console.WriteLine("Modelo inválido!");
            }
            if (categoriaModel.Id != id)
            {
                return NotFound("Categoria não encontrada");
            }
            try
            {
                categoriaRepository.Atualizar(categoriaModel);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public ActionResult<CategoriaModel> Delete([FromRoute] int id) 
        {
            try { 
            var categoria = categoriaRepository.Consultar(id);
                if (categoria == null)
                {
                    return NotFound();
                }
                else
                {
                    dataBaseContext.Remove(categoria);
                    dataBaseContext.SaveChanges();
                    return NoContent();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
