using DM.Application.DTOs;
using DM.Core.DomainObjects.ValueObjects;
using DM.Core.Messages.Handlers;
using DM.Core.MessagesExceptions;
using DM.Core.WebApi;
using DM.Domain.Repositories;
using MongoDB.Driver;
using System.Text.Json;

namespace DM.Application.Command.Doador.AdicionarDoador
{
    public class AdicionarDoadorCommandHandler : CommandHandler<AdicionarDoadorCommand, bool>
    {
        private readonly IRepositoryCommandAll<Domain.Entities.Doador> _repositoryDoadorCommand;

        public AdicionarDoadorCommandHandler(IRepositoryCommandAll<Domain.Entities.Doador> repositoryDoadorCommand)
        {
            _repositoryDoadorCommand = repositoryDoadorCommand;
        }

        public override async Task<RequestResult<bool>> Handle(AdicionarDoadorCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) 
            {
                var mensagensErros = message.ValidationResultCommand.Errors.Select(x => x.ErrorMessage).ToList();
                return Falha(mensagensErros);
            }

            EnderecoDTO enderecoDTO = await ObterCep(message.Cep);
            
            if (enderecoDTO == null)
                return Falha(MessagesExceptions.ERRO_API_CEP);

            var doadorExiste = await _repositoryDoadorCommand.FirstOrDefault((doador) => doador.Email.Equals(message.Email));

            if (doadorExiste != null)
                return Falha(MessagesExceptions.EMAIL_EM_USO);

            Domain.Entities.Doador doador = new(message.NomeCompleto, 
                message.Email, 
                message.Peso, 
                message.Genero, 
                message.TipoSanguineo, 
                message.FatorRh, 
                message.DataNascimento,
                new Endereco(enderecoDTO.Logradouro, 
                    enderecoDTO.Localidade, 
                    enderecoDTO.Uf, 
                    message.Cep));;

            await _repositoryDoadorCommand.CreateAsync(doador);
            
            await _repositoryDoadorCommand.UnitOfWork.Commit();

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

            return  JsonSerializer.Deserialize<EnderecoDTO>(responseCep, options);
        }
    }
}
