using AluraChallenge___1.Model;
using AluraChallenge___1.Models;
using AluraChallenge___1.Repository.Context;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Linq;

namespace AluraChallenge___1.Repository
{
    public class VideoRepository
    {
        private readonly DataBaseContext dataBaseContext;

        public VideoRepository(DataBaseContext ctx)
        {
            dataBaseContext = ctx;
        }

       public IList<VideoModel> Listar()
        {
            var lista = new List<VideoModel>();

            lista = dataBaseContext.Video.Include(c => c.Categoria)
                .ToList<VideoModel>();
            return lista;
        }

        public VideoModel Consultar(int id)
        {
            var video = dataBaseContext.Video
                .Include(c => c.Categoria)
                .Where( v => v.Id == id).FirstOrDefault();
            return video;
        }

        public void Inserir(VideoModel video)
        {
            dataBaseContext.Video.Add(video);
            dataBaseContext.SaveChanges();

        }

        public void Alterar(VideoModel video) 
        {
            dataBaseContext.Video.Update(video);
            dataBaseContext.SaveChanges();
        }

        public void Excluir(int id)
        {
            var video = new VideoModel {Id = id};

            dataBaseContext.Video.Remove(video);
            dataBaseContext.SaveChanges();
        }

        public VideoModel ConsultaPorTitulo(string titulo)
        {
            var video = dataBaseContext.Video
                 .Where(v => v.Title.Contains(titulo)) 
                 .AsTracking().FirstOrDefault<VideoModel>();

            return video;
        }

    }
}
