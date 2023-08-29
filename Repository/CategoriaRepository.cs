using AluraChallenge___1.Models;
using AluraChallenge___1.Repository.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Linq;

namespace AluraChallenge___1.Repository
{
    public class CategoriaRepository
    {
        private readonly DataBaseContext dataBaseContext;

        public CategoriaRepository(DataBaseContext ctx) 
        {
            dataBaseContext = ctx;
        }

        public IList<CategoriaModel> Listar()
        {
            var lista = new List<CategoriaModel>();

            lista = dataBaseContext.Categoria
                .ToList<CategoriaModel>();
            return lista;
        }

        public IList<CategoriaModel> Consultar(int id)
        {
            var lista = new List<CategoriaModel>();

            lista = dataBaseContext.Categoria.Include(v => v.Videos)
                .Where(c => c.Id == id)
                .ToList<CategoriaModel>();
            return lista;
        }

        public void Inserir(CategoriaModel categoria)
        {
            dataBaseContext.Categoria.Add(categoria);
            dataBaseContext.SaveChanges();
        }

        public void Atualizar(CategoriaModel categoria)
        {
            dataBaseContext.Categoria.Update(categoria);
            dataBaseContext.SaveChanges();
        }

        public void Excluir(int id)
        {
            var categoria = new CategoriaModel(id);
            
            dataBaseContext.Remove(categoria);
            dataBaseContext.SaveChanges();
        }

    }
}
