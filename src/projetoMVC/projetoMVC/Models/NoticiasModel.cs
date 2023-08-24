using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace projetoMVC.Models
{
    [Table("Noticias")]
    public class NoticiasModel
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100, ErrorMessage = "O tamanho máximo do campo {0} é de {1} caracteres")]

        public string Titulo { get; set; }
        [MaxLength(100, ErrorMessage = "O tamanho máximo do campo {0} é de {1} caracteres")]
        public string SubTitulo { get; set; }
        [MaxLength(500, ErrorMessage = "O tamanho máximo do campo {0} é de {1} caracteres")]
        public string Manchete { get; set; }
        public string Texto { get; set; }
        public DateTime Data { get; set; }
        public int Contador { get; set; }
    }
}
