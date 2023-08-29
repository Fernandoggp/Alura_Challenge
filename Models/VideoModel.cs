using AluraChallenge___1.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AluraChallenge___1.Model
{
    [Table("VIDEO")]
    public class VideoModel
    {

        [Key]
        [Column("ID")]
        public int Id { get; set; }

        [Column("TITULO")]
        [Display(Name = "Titulo do video")]
        [Required(ErrorMessage = "Titulo do video é obrigatório!")]
        [MaxLength(70, ErrorMessage = "O tamanho máximo para o campo nome é de 30 caracteres.")]
        [MinLength(2, ErrorMessage = "Digite um nome com 2 ou mais caracteres")]
        public string Title { get; set; }

        [Column("DESCRICAO")]
        [Display(Name = "Descricao do video")]
        [Required(ErrorMessage = "A descrição do video é obrigatória!")]
        public string Descricao { get; set; }

        [Column("URL")]
        [Display(Name = "Url do video")]
        [Required(ErrorMessage = "A URL do video é obrigatória!")]
        public string Url { get; set; }

        [Column("CATEGORIAID")]
        [Display(Name = "Categoria do video")]
        public int CategoriaID { get; set; }

        public CategoriaModel? Categoria { get;}

    }

}
