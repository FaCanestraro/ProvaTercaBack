using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/inicializar")]
    public class InicializarDadosController : ControllerBase
    {
        private readonly DataContext _context;
        public InicializarDadosController(DataContext context)
        {
            _context = context;
        }

        //POST: api/inicializar/create
        [HttpPost]
        [Route("create")]
        public IActionResult Create()
        {
            _context.Categorias.AddRange(new Categoria[]
                {
                    new Categoria { CategoriaId = 1, Nome = "Bebidas" },
                }
            );
            _context.Produtos.AddRange(new Produto[]
                {
                    new Produto { ProdutoId = 1, Nome = "Chá", Preco = 5, Descricao = "Uma caixa de chá", Quantidade = 2, CategoriaId = 1 },
                    new Produto { ProdutoId = 2, Nome = "Café", Preco = 6, Descricao = "Uma caixa de café", Quantidade = 3, CategoriaId = 1 },
                    new Produto { ProdutoId = 3, Nome = "Nescal", Preco = 7, Descricao = "Uma lata de nescal", Quantidade = 5, CategoriaId = 1 },
                }
            );
            _context.SaveChanges();
            return Ok(new { message = "Dados inicializados com sucesso!" });
        }
    }
}