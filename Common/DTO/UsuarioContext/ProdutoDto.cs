using System;
using System.Collections.Generic;
using System.Text;

namespace App.Common.DTO.AppContext
{
    public class ProdutoDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int IdCategoria { get; set; }
        public decimal Preco { get; set; }
        public string NomeCategoria { get; set; }
    }
}
