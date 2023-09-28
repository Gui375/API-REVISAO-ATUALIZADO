using ExemploAPI.Application.Interfaces;
using ExemploAPI.Application.ViewModels;
using ExemploAPI.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ExemploAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartaController : ControllerBase
    {
        private readonly string _cartasCaminhoArquivo;
        private readonly ICartaService _cartaService;

        public CartaController(ICartaService cartaService)
        {
            _cartasCaminhoArquivo = Path.Combine(Directory.GetCurrentDirectory(), "Data", "cartas.json");
            _cartaService = cartaService;
        }

        [HttpGet]
        [Route("ObterTodos")]
        public IActionResult ObterTodos()
        {
            IEnumerable<CartaViewModel> cartas = _cartaService.ObterTodos();
            return Ok(cartas);
        }

        [HttpPost]
        public IActionResult Post([FromBody] CartaViewModel carta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            _cartaService.Adicionar(carta);
            return Ok();
        }

        [HttpGet]
        [Route("ObterPorId/{id}")]
        public IActionResult ObterPorId(int id)
        {

            var result = _cartaService.ObterPorId(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
