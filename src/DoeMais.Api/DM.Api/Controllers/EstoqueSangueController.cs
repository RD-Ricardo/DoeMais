using DM.Application.Queries.Doacao.ListarTodasDoacoes;
using DM.Application.Queries.EstoqueSangue.ListarEstoqueSangue;
using DM.Core.Communication.Mediator;
using DM.Core.WebApi;
using DM.Shared.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DM.Api.Controllers
{
    [Route("api/[controller]")]
    public class EstoqueSangueController : MainController
    {
        private readonly IMediatorHandler _mediatorHandler;
        public EstoqueSangueController(IMediatorHandler mediatorHandler)
        {
            _mediatorHandler = mediatorHandler;
        }

        [HttpGet]
        public async Task<ActionResult> ObterTodosDoacao()
        {
            var query = new ListarEstoqueSangueQuery();

            var result = await _mediatorHandler.PublicarConsulta<ListarEstoqueSangueQuery, EstoqueSangueViewModel>(query);

            return CustomResponse(result);
        }
    }
}
