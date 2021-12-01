using System;
using System.Collections.Generic;

namespace API.Models
{
    public class Venda
    {
        //public Venda() => CriadoEm = DateTime.Now;
        public int VendaId { get; set; }
        public string Cliente { get; set; }
        public int FormaPagamentoId { get; set; }
        public FormaPagamento FormaP { get; set; }
        public ItemVenda ItemVenda { get; set; }
        public Produto Produto { get; set; }
        public int ProdutoId { get; set; }
        public int ItemVendaId { get; set; }
    }
}