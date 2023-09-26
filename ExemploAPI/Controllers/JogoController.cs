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

        public JogoController()
        {
            _jogoCaminhoArquivo = Path.Combine(Directory.GetCurrentDirectory(), "Data", "jogosMega.json");
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
            List<JogoViewModel> jogos = LerJogosDoArquivo();
            return Ok(jogos);
        }

        [HttpPost]
        public IActionResult Post([FromBody] NovoJogoViewModel jogo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            List<JogoViewModel> jogos = LerJogosDoArquivo();
            int proximoCodigo = ObterProximoCodigoDisponivel();

            JogoViewModel novoJogo = new JogoViewModel()
            {
                Id = proximoCodigo,
                Nome = jogo.Nome,
                Cpf = jogo.Cpf,
                primeiroNro = jogo.primeiroNro,
                segundoNro = jogo.segundoNro,
                terceiroNro = jogo.terceiroNro,
                quartoNro = jogo.quartoNro,
                quintoNro = jogo.quintoNro,
                sextoNro = jogo.sextoNro,
                dataJogo = DateTime.Now
            };

            jogos.Add(novoJogo);
            EscreverProdutosNoArquivo(jogos);

            return Ok("Jogo Registrado com sucesso!");
        }

        [HttpGet]
        [Route("ObterPorCodigo/{codigo}")]
        public IActionResult ObterPorCodigo(int codigo)
        {
            List<JogoViewModel> jogos = LerJogosDoArquivo();
            JogoViewModel jogo = jogos.Find(p => p.Id == codigo);
            if (jogo == null)
            {
                return NotFound();
            }

            return Ok(jogo);
        }
    }
}
