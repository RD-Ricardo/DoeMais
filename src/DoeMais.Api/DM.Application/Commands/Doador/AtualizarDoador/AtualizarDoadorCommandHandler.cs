using DM.Application.DTOs;
using DM.Core.DomainObjects.ValueObjects;
using DM.Core.Messages.Handlers;
using DM.Core.MessagesExceptions;
using DM.Core.WebApi;
using DM.Domain.Repositories;
using MediatR;
using System.Text.Json;

namespace DM.Application.Command.Doador.AtualizarDoador
{
    public class AtualizarDoadorCommandHandler : CommandHandler<AtualizarDoadorCommand, Unit>
    {
        private readonly IRepositoryCommandAll<Domain.Entities.Doador> _repositoryCommandAllDoador;
        public AtualizarDoadorCommandHandler(IRepositoryCommandAll<Domain.Entities.Doador> repositoryCommandAllDoador)
        {
            _repositoryCommandAllDoador = repositoryCommandAllDoador;
        }
        public override async Task<RequestResult<Unit>> Handle(AtualizarDoadorCommand message, CancellationToken cancellationToken)
        {
            var doadorExistente = await _repositoryCommandAllDoador.FirstOrDefault(filtro: x => x.Id == message.Id);

            if (doadorExistente == null)
                return Falha(MessagesExceptions.DOADOR_NAO_ENCONTRADO);

            var enderecoDTO = await ObterCep(message.Cep);

            if (enderecoDTO == null)
                return Falha(MessagesExceptions.ERRO_API_CEP);
            
            doadorExistente.Update( 
                message.NomeCompleto, 
                message.Email, 
                message.Genero, 
                message.Peso, 
                message.DataNascimento,
                new Endereco(enderecoDTO.Logradouro,
                    enderecoDTO.Localidade,
                    enderecoDTO.Uf,
                    message.Cep));

            _repositoryCommandAllDoador.Update(doadorExistente);

            await _repositoryCommandAllDoador.UnitOfWork.Commit();

            return Sucesso();
        }

        private async Task<EnderecoDTO> ObterCep(string cep)
        {
            var httpClient = new HttpClient();

            var requestCep = await httpClient.GetAsync($"https://viacep.com.br/ws/{cep}/json");

            if (!requestCep.IsSuccessStatusCode)
                return null;

            var responseCep = await requestCep.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };

            return JsonSerializer.Deserialize<EnderecoDTO>(responseCep, options);
        }
    }
}
