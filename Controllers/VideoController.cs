using AluraChallenge___1.Model;
using AluraChallenge___1.Repository;
using AluraChallenge___1.Repository.Context;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace AluraChallenge___1.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class VideoController : ControllerBase
    {
        private readonly DataBaseContext dataBaseContext;

        private readonly VideoRepository videoRepository;

        public VideoController(DataBaseContext context)
        {
            videoRepository = new VideoRepository(context);
            dataBaseContext = context;
        }

        [HttpGet]
        public ActionResult<List<VideoModel>> Get()
        {
            try
            {
                var lista = videoRepository.Listar();
                if (lista != null)
                {
                    return Ok(lista);
                }
                else
                {
                    return NotFound("Nenhum video encontrado");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Erro ao tentar buscar videos");
            }
        }

        [HttpGet("{id:int}")]
        public ActionResult<VideoModel> Get([FromRoute] int id)
        {
            try
            {
                var videoModel = videoRepository.Consultar(id);
                if (videoModel != null)
                {
                    return Ok(videoModel);
                }
                else
                {
                    return NotFound("Video não encontrado");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("{titulo}")]
        public ActionResult<VideoModel> Search([FromRoute]string titulo)
        {
            try
            {
                var videoModel = videoRepository.ConsultaPorTitulo(titulo);
                if (videoModel != null)
                {
                    return Ok(videoModel);
                }
                else
                {
                    return NotFound("Video não encontrado");
                }

            } catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult<VideoModel> Post([FromBody] VideoModel videoModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Esse formato não é valido");
            }
            try
            {
                videoRepository.Inserir(videoModel);
                var location = new Uri(Request.GetEncodedUrl() + videoModel.Id);
                return Created(location, videoModel);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = $"Não foi possivel inserir um novo video. Detalhes {ex.Message}" });
            }
        }

        [HttpPut("{id:int}")]
        public ActionResult<VideoModel> Put([FromRoute] int id, [FromBody] VideoModel videoModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (videoModel.Id != id)
            {
                return NotFound();
            }
            try
            {
                videoRepository.Alterar(videoModel);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = $"Não foi possivel alterar o video. Detalhes {ex.Message}" });
            }

        }

        [HttpDelete("{id:int}")]
        public ActionResult <VideoModel> Delete([FromRoute] int id)
        {
            try
            {
                var videoModel = videoRepository.Consultar(id);
                if (videoModel != null)
                {
                    dataBaseContext.Video.Remove(videoModel);
                    dataBaseContext.SaveChanges();
                    return NoContent();
                }
                else
                {
                    return NotFound();
                }
            }   
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
        }

    }
}
