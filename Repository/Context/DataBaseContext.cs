using AluraChallenge___1.Model;
using AluraChallenge___1.Models;
using Microsoft.EntityFrameworkCore;

namespace AluraChallenge___1.Repository.Context
{
    public class DataBaseContext : DbContext

    {
        public DbSet<VideoModel> Video { get; set; }

        public DbSet<CategoriaModel> Categoria { get; set; }


        public DataBaseContext(DbContextOptions options) : base(options)
        {
        }
        protected DataBaseContext()
        {
        }
    }
}
