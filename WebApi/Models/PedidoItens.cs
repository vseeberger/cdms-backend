using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class PedidoItens
    {
        [Required(ErrorMessage = "Informe a sequencia do item")]
        public int Item { get; set; }

        [Key]
        [Column(Order = 1)]
        [Required(ErrorMessage = "O produto deve ser vinculado ao pedido")]
        public int PedidoId { get; set; }
        [Key]
        [Column(Order = 2)]
        public int ProdutoId { get; set; }
        [NotMapped]
        public Produto Produto { get; set; }
        public decimal ProdutoValorUn { get; set; }

        public decimal ProdutoQuantidade { get; set; }
    }
}