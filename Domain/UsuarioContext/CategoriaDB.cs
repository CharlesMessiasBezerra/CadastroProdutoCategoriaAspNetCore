using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Domain.AppContext
{
    [Table("Categorias")]
    public partial class CategoriaDB
    {
        public CategoriaDB()
        {
          
        }

        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Required]
        [Column("Nome")]
        [StringLength(150)]
        public string Nome { get; set; }
       
    }
}
