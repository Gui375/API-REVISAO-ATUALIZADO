using ExemploAPI.Application.Interfaces;
using ExemploAPI.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ExemploAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JogoController : ControllerBase
    {
        private readonly string _jogoCaminhoArquivo;
        private readonly IJogoService _jogoService;

        public JogoController(IJogoService jogoService)
        {
            _jogoCaminhoArquivo = Path.Combine(Directory.GetCurrentDirectory(), "Data", "jogosMega.json");
            _jogoService = jogoService;
        }

        #region Métodos arquivo
        private List<JogoViewModel> LerJogosDoArquivo()
        {
            if (!System.IO.File.Exists(_jogoCaminhoArquivo))
            {
                return new List<JogoViewModel>();
            }

            string json = System.IO.File.ReadAllText(_jogoCaminhoArquivo);
            return JsonConvert.DeserializeObject<List<JogoViewModel>>(json);
        }

        private int ObterProximoCodigoDisponivel()
        {
            List<JogoViewModel> jogos = LerJogosDoArquivo();
            if (jogos.Any())
            {
                return jogos.Max(p => p.Id) + 1;
            }
            else
            {
                return 1;
            }
        }

        private void EscreverProdutosNoArquivo(List<JogoViewModel> jogos)
        {
            string json = JsonConvert.SerializeObject(jogos);
            System.IO.File.WriteAllText(_jogoCaminhoArquivo, json);
        }
        #endregion

        [HttpGet]
        [Route("ObterTodos")]
        public IActionResult ObterTodos()
        {
            IEnumerable<JogoViewModel> jogos = _jogoService.ObterTodos();
            return Ok(jogos);
        }

        [HttpPost]
        public IActionResult Post([FromBody] NovoJogoViewModel jogo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = _jogoService.Adicionar(jogo);

            return Ok(result);
        }

        [HttpGet]
        [Route("ObterPorCodigo/{codigo}")]
        public IActionResult ObterPorCodigo(int id)
        {

            var result = _jogoService.BuscarPorId(id);
            if(result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
