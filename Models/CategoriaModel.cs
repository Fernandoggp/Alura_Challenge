using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using AluraChallenge___1.Model;

namespace AluraChallenge___1.Models
{
    [Table("CATEGORIA")]
    public class CategoriaModel
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }

        [Column("TITULO")]
        [Display(Name = "Titulo da categoria")]
        [Required(ErrorMessage = "Titulo da categoria é obrigatória!")]
        [MaxLength(70, ErrorMessage = "O tamanho máximo para o campo é de 30 caracteres.")]
        [MinLength(2, ErrorMessage = "Digite um titulo com 2 ou mais caracteres")]
        public string Titulo { get; set; }

        [Column("COR")]
        [Display(Name = "Cor da categoria")]
        [Required(ErrorMessage = "A cor da categoria é obrigatória!")]
        public string Cor { get; set; }

        //public IList<VideoModel>? Videos { get; }

        public CategoriaModel()
        {
        }

        public CategoriaModel(int id)
        {
            Id = id;
        }

        public CategoriaModel(int id, string titulo, string cor, IList<VideoModel>? videos) : this(id)
        {
            Titulo = titulo;
            Cor = cor;
           // Videos = videos;
        }
    }
}
