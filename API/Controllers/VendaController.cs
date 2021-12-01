using System.Linq;
using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/venda")]
    public class VendaController : ControllerBase
    {
        private readonly DataContext _context;
        public VendaController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("create")]
        public IActionResult Create([FromBody] Venda venda)
        {
            venda.FormaP = _context.FormasPagamento.Find(venda.FormaPagamentoId);
            venda.ItemVenda = _context.ItensVenda.Find(venda.ItemVendaId);
            venda.Produto = _context.Produtos.Find(venda.ProdutoId);
            _context.Vendas.Add(venda);
            _context.SaveChanges();
            return Created("", venda);
        }

        //GET: api/venda/list
        //ALTERAR O MÉTODO PARA MOSTRAR TODOS OS DADOS DA VENDA E OS DADOS RELACIONADOS
        [HttpGet]
        [Route("list")]
        public IActionResult List()
        {
            return Ok(_context.Vendas
            .Include(FormaPagamento => FormaPagamento.FormaP)
            .Include(ItemVenda => ItemVenda.ItemVenda)
            .Include(Produto => Produto.Produto)
            .ToList());


        }
    }
}