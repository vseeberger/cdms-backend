using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    [System.ComponentModel.DataAnnotations.Schema.Table("Pedidos")]
    public class Pedido
    {
        private DateTime dtmCadastro = DateTime.Now;
        private DateTime dtmPedido = DateTime.Now;
        private DateTime dtmAtualizacao = DateTime.Now;

        [Key]
        public int Id { get; set; }
        public DateTime DtmCadastro { get => dtmCadastro; set => dtmCadastro = value; }
        public bool BAtivo { get; set; }
        public DateTime DtmPedido { get => dtmPedido; set => dtmPedido = value; }
        [Required]
        public int ClienteId { get; set; }
        [NotMapped]
        public Cliente Cliente { get; set; }
        [Required(ErrorMessage = "O pedido deve ter um valor")]
        [Range(0.1, double.MaxValue, ErrorMessage = "O valor mínimo do pedido deve ser de 0.1")]
        public decimal DValorPedido { get; set; }
        public decimal DDesconto { get; set; }
        [Required(ErrorMessage = "O pedido deve ter um valor")]
        [Range(0.1, double.MaxValue, ErrorMessage = "O valor total mínimo do pedido deve ser de 0.1")]
        public decimal DValorTotal { get; set; }

        public ICollection<PedidoItens> Produtos { get; set; }
        public DateTime DtmAtualizacao { get => dtmAtualizacao; set => dtmAtualizacao = value; }
    }
}