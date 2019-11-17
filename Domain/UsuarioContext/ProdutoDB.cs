using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Domain.AppContext
{
    [Table("Produtos")]
    public partial class ProdutoDB
    {
        public ProdutoDB()
        {
          
        }

        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Required]
        [Column("Nome")]
        [StringLength(150)]
        public string Nome { get; set; }

        [Required]
        [Column("Preco")]        
        public decimal  Preco { get; set; }

        [Required]
        [Column("IdCategoria")]
        public int IdCategoria { get; set; }

    }
}
