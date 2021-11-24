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
                    new Categoria { CategoriaId = 1, Nome = "Eletrodomésticos" },
                }
            );
            _context.Produtos.AddRange(new Produto[]
                {
                    new Produto { ProdutoId = 1, Nome = "Geladeira Electrolux 454L DB53X", Preco = 5629, Quantidade = 1, CategoriaId = 1 },
                    new Produto { ProdutoId = 2, Nome = "Fogão Consul 5 Bocas CFS5VAR", Preco = 1879, Quantidade = 2, CategoriaId = 1 },
                    new Produto { ProdutoId = 3, Nome = "Microondas Philco 32L PMO33EB", Preco = 930, Quantidade = 3, CategoriaId = 1 },
                }
            );
            _context.FormaPagamentos.AddRange(new FormaPagamento[]
                {
                    new FormaPagamento { FormaPagamentoId = 1, Nome = "Cartão de Crédito", Ordem = 1 },
                    new FormaPagamento { FormaPagamentoId = 2, Nome = "PIX", Ordem = 2 }
                }
            );
            _context.SaveChanges();
            return Ok(new { message = "Dados inicializados com sucesso!" });
        }
    }
}