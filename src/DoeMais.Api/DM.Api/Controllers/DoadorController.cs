using DM.Application.Command.Doador.AdicionarDoador;
using DM.Application.Command.Doador.AtualizarDoador;
using DM.Application.Queries.Doador.ListarTodosDoadores;
using DM.Application.Queries.Doador.ObterDoadorPorId;
using DM.Core.Communication.Mediator;
using DM.Core.WebApi;
using DM.Shared.InputModels;
using DM.Shared.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DM.Api.Controllers
{
    [Route("api/[controller]")]
    public class DoadorController : MainController
    {
        private readonly IMediatorHandler _mediator;
        public DoadorController(IMediatorHandler mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult> ObterTodosDoadores()
        {
            var query = new ListarTodosDoadoresQuery();

            var result = await _mediator.PublicarConsulta<ListarTodosDoadoresQuery, IEnumerable<DoadorViewModel>>(query);

            return CustomResponse(result);
        }

        [HttpGet("{doadorId}")]
        public async Task<ActionResult> ObterDoador(string doadorId)
        {
            var query = new ObterDoadorPorIdQuery(doadorId);

            var result = await _mediator.PublicarConsulta<ObterDoadorPorIdQuery, DoadorPorIdViewModel>(query);

            return CustomResponse(result);
        }

        [HttpPost]
        public async Task<ActionResult> CadastrarDoador(DoadorInputModel doadorInput)
        {
            var command = new AdicionarDoadorCommand(doadorInput.NomeCompleto,
                doadorInput.Email,
                doadorInput.Peso,
                doadorInput.TipoSanguineo,
                doadorInput.FatorRh,
                doadorInput.Genero,
                doadorInput.DataNascimento,
                doadorInput.Cep);

            var result = await _mediator.PublicarComando<AdicionarDoadorCommand, bool>(command);
            
            return CustomResponse(result);
        }

        [HttpPut("{doadorId}")]
        public async Task<ActionResult> AtualizarDoador([FromRoute] string doadorId, 
            [FromBody] AtualizarDoadorInputModel doadorInput)
        {
            var command = new AtualizarDoadorCommand(
                doadorId,
                doadorInput.NomeCompleto,
                doadorInput.Email,
                doadorInput.Genero,
                doadorInput.Peso,
                doadorInput.DataNascimento,
                doadorInput.Cep);

            var result = await _mediator.PublicarComando<AtualizarDoadorCommand, Unit>(command);

            return CustomResponse(result);
        }
    }
}
