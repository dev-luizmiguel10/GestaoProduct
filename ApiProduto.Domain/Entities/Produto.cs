using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ApiProduto.Domain.Entities
{
    [Table("tb_produto")]
    public class Produto
    {
        [Key]
        public int ProdutoId { get; set; }
        public string nome_produto { get; set; }
        public decimal preco { get; set; }
        public int qtd_estoque { get; set; }
    }
}
