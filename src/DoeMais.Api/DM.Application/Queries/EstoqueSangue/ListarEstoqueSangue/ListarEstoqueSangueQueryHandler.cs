using DM.Core.Messages.Handlers;
using DM.Core.WebApi;
using DM.Domain.Enums;
using DM.Domain.Repositories;
using DM.Shared.ViewModels;

namespace DM.Application.Queries.EstoqueSangue.ListarEstoqueSangue
{
    public class ListarEstoqueSangueQueryHandler : QueryHandler<ListarEstoqueSangueQuery, EstoqueSangueViewModel>
    {
        private readonly IRepositoryCommandAll<Domain.Entities.EstoqueSangue> _repositoryCommandAllEstoqueSangue;

        private readonly IRepositoryCommandAll<Domain.Entities.Doacao> _repositoryCommandAllDoacao;
        public ListarEstoqueSangueQueryHandler(IRepositoryCommandAll<Domain.Entities.EstoqueSangue> repositoryCommandAllEstoqueSangue, IRepositoryCommandAll<Domain.Entities.Doacao> repositoryCommandAllDoacao)
        {
            _repositoryCommandAllEstoqueSangue = repositoryCommandAllEstoqueSangue;
            _repositoryCommandAllDoacao = repositoryCommandAllDoacao;
        }

        public override async Task<RequestResult<EstoqueSangueViewModel>> Handle(ListarEstoqueSangueQuery request, CancellationToken cancellationToken)
        {
            EstoqueSangueViewModel result = new ();
            
            var estoqueSangue = _repositoryCommandAllEstoqueSangue.Query(leitura: true);

            foreach (var estoque in estoqueSangue.ToList())
            {
                var doacoes = await _repositoryCommandAllDoacao.FindBy(leitura: true,
                    includes: new string[] { "Doador" },
                    filtro: d => d.Doador.FatorRh == estoque.FatorRh && 
                        d.Doador.TipoSanguineo == estoque.TipoSanguineo);
                
                var quantidadeDoadores = doacoes.GroupBy(x => x.DoadorId).Count();

                if (estoque.FatorRh == FatorRh.Positivo)
                {
                    switch (estoque.TipoSanguineo)
                    {
                        case TipoSanguineo.O:
                            result.OPositivo = new EstoqueSangueItemViewModel(quantidadeDoadores, estoque.QuantidadeML);
                            break;
                        case TipoSanguineo.A:
                            result.APositivo = new EstoqueSangueItemViewModel(quantidadeDoadores, estoque.QuantidadeML);
                            break;
                        case TipoSanguineo.B:
                            result.BPositivo = new EstoqueSangueItemViewModel(quantidadeDoadores, estoque.QuantidadeML);
                            break;
                        case TipoSanguineo.AB:
                            result.ABPositivo = new EstoqueSangueItemViewModel(quantidadeDoadores, estoque.QuantidadeML);
                            break;
                    }
                }
                else
                {
                    switch (estoque.TipoSanguineo)
                    {
                        case TipoSanguineo.O:
                            result.ONegativo = new EstoqueSangueItemViewModel(quantidadeDoadores, estoque.QuantidadeML);
                            break;
                        case TipoSanguineo.A:
                            result.ANegativo = new EstoqueSangueItemViewModel(quantidadeDoadores, estoque.QuantidadeML);
                            break;
                        case TipoSanguineo.B:
                            result.BNegativo = new EstoqueSangueItemViewModel(quantidadeDoadores, estoque.QuantidadeML);
                            break;
                        case TipoSanguineo.AB:
                            result.ABNegativo = new EstoqueSangueItemViewModel(quantidadeDoadores, estoque.QuantidadeML);
                            break;
                    }
                }
            }

            return Sucesso(result);
        }
    }
}
