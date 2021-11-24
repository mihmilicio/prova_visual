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

        //POST: api/venda/create
        [HttpPost]
        [Route("create")]
        public IActionResult Create([FromBody] Venda venda)
        {
            venda.FormaPagamento = _context.FormaPagamentos.Find(venda.FormaPagamentoId);
            _context.Vendas.Add(venda);
            _context.SaveChanges();
            return Created("", venda);
        }

        //GET: api/venda/list
        [HttpGet]
        [Route("list")]
        public IActionResult List() =>
            Ok(_context.Vendas
                .Include(v => v.FormaPagamento)
                .Include(v => v.Itens)
                    .ThenInclude(i => i.Produto.Categoria)
                .ToList());
    }
}