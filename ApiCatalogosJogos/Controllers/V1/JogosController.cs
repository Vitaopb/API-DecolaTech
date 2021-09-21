using ApiCatalogosJogos.ViewModel;
using ApiCatalogosJogos.InputModel;
using ApiCatalogosJogos.Exceptions;
using ApiCatalogosJogos.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogosJogos.Controllers.V1
{
    [Route("api/V1/[controller]")]
    [ApiController]
    public class JogosController : ControllerBase
    {

        private readonly IJogosServices _jogosServices;
        private object _jogoService;

        public JogosController(IJogoService jogoService)
        {
            _jogosServices = (IJogosServices)jogoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<JogoViewModel>>> Obter([FromQuery, Range(1, int.MaxValue)] int pagina = 1, [FromQuery, Range(1, 50)] int quantidade = 5)
        {
            var jogos = await _jogoService.Obter(pagina, quantidade);

            if (jogos.Count() == 0)
                return NoContent();

            return Ok(jogos);
        }


        [HttpGet("{idJogo:guid}")]
         public async Task<ActionResult<JogoViewModel>> Obter([FromRoute] Guid idJogo)
         {
               var jogos = await _jogosServices.Obter(pagina, quantidade);
            
               if (jogos.Count() == 0)
               {
               return NoContent();
               }

               return Ok(jogos);
        }

        [HttpGet("{idJogo:guid}")]
        public async Task<ActionResult<List<JogoViewModel>>> Obter(Guid idJogo)
        {
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<JogoViewModel>> InserirJogo([FromBody] JogoInputModel jogoInputModel)
        {
            try
            {
                var jogo = await _jogosServices.Inserir(jogoInputModel);
                return Ok();
            }
            catch(JogoJaCadastradoException ex)
            {
                return UnprocessableEntity("Já existe um jogo com este nome para esta produtora");
            }
        }

        [HttpPut("{idJogo:guid}")]

        public async Task<ActionResult> AtualizarJogo([FromRoute] Guid idJogo, [FromBody] JogoInputModel jogoInputModel)
        {
            try
            {
                await _jogosServices.Atualizar(idJogo, jogoInputModel);

                return Ok();    
            }
            catch(JogoNaoCadastradoException ex)
            {
                return NotFound("Não esxite esse jogo");
            }
        }

        [HttpPatch("{idJogo:guid}/preco/{preco:double}")]
        public async Task<ActionResult> AtualizarJogo([FromRoute] Guid idJogo, [FromRoute] double preco)
        {
            try
            {
                await _jogosServices.Atualizar(idJogo, preco);
                return Ok();
            }
            catch(JogoNaoCadastradoException ex)
            {
                return NotFound("Não existe este jogo");
            }
        } 

        [HttpDelete("{idJogo:guid}")]
        public async Task<AcceptedResult> ApagarJogo([FromRoute] Guid idJogo)
        {

            try
            {
                await _jogosServices.ApagarJogo(idJogo);

                return Ok();
            }
            catch (JogoNaoCadastradoException ex)
            {
                return NotFound("Não existe este jogo");
            }
        }
    }
}
