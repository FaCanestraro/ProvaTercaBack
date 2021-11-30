using System;

namespace API.Models
{
     public class FormaPagamento
    {
        public FormaPagamento() => CriadoEm = DateTime.Now;
        public int Id { get; set; }
        public string Metodo { get; set; }
        public string Vezes { get; set; }
        public DateTime CriadoEm { get; set; }
    }
}