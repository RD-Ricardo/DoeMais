using DM.Application.Commands.Doacao.AdicionarDoacao;
using DM.Application.Queries.Doacao.DoacoesPorDoador;
using DM.Application.Queries.Doacao.ListarTodasDoacoes;
using DM.Application.Queries.Doador.ListarTodosDoadores;
using DM.Core.Communication.Mediator;
using DM.Core.WebApi;
using DM.Shared.InputModels;
using DM.Shared.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DM.Api.Controllers
{
    [Route("api/[controller]")]
    public class DoacaoController : MainController
    {
        private readonly IMediatorHandler _mediatorHandler;

        public DoacaoController(IMediatorHandler mediatorHandler)
        {
            _mediatorHandler = mediatorHandler;
        }

        [HttpPost]
        public async Task<ActionResult> CadastrarDoacao(DoacaoInputModel doacaoInputModel)
        {
            var command = new AdicionarDoacaoCommand(doacaoInputModel.QuantidadeML, doacaoInputModel.DoadorId);

            var result = await _mediatorHandler.PublicarComando<AdicionarDoacaoCommand, Unit>(command);

            return CustomResponse(result);
        }

        [HttpGet("{doadorId}/porDoador")]
        public async Task<ActionResult> ObterTodosDoacaoPorDoador(string doadorId)
        {
            var query = new DoacoesPorDoadorQuery(doadorId);

            var result = await _mediatorHandler.PublicarConsulta<DoacoesPorDoadorQuery, IEnumerable<DoacaoViewModel>>(query);

            return CustomResponse(result);
        }

        [HttpGet]
        public async Task<ActionResult> ObterTodosDoacao()
        {
            var query = new ListarTodasDoacoesQuery();

            var result = await _mediatorHandler.PublicarConsulta<ListarTodasDoacoesQuery, IEnumerable<DoacaoViewModel>>(query);

            return CustomResponse(result);
        }
    }
}
