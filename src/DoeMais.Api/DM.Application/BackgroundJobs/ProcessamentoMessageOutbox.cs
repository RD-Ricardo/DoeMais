using DM.Core.Communication.Mediator;
using DM.Core.Messages;
using DM.Infrastructure.Data.CommandsDb;
using DM.Infrastructure.Data.Outbox;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Quartz;
using System.Reflection;

namespace DM.Application.BackgroundJobs
{
    [DisallowConcurrentExecution]
    public class ProcessamentoMessageOutbox : IJob
    {
        private readonly DoeMaisDbContextMySql _dbContext;
        private readonly IMediatorHandler _mediatorHandler;

        public ProcessamentoMessageOutbox(DoeMaisDbContextMySql context, IMediatorHandler mediatorHandler)
        {
            _dbContext = context;
            _mediatorHandler = mediatorHandler;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            var messages = await _dbContext.Set<OutBoxMessage>()
                .Where(x => x.ProcessedOnUtc == null)
                .Take(20)
                .ToListAsync(context.CancellationToken);

            Assembly assembly = Assembly.Load("DM.Application");

            foreach (OutBoxMessage outBoxMessage in messages)
            {
                object domainEvent = null;

                if (ExisteEventoEmOutroAssembly(outBoxMessage.Type))
                {
                    assembly = Assembly.Load("DM.Core");
                }

                Type tipoEvento = assembly.GetType(outBoxMessage.TypeFullName);

                domainEvent = JsonConvert.DeserializeObject(outBoxMessage.Content, tipoEvento);
                
                if(domainEvent == null) 
                {
                    continue;
                }

                await _mediatorHandler.PublicarDomainEvent(domainEvent as Event);
                
                outBoxMessage.ProcessedOnUtc = DateTime.Now;
                _dbContext.OutBoxMessages.Update(outBoxMessage);
                await _dbContext.SaveChangesAsync();
            }


        }

        static bool ExisteEventoEmOutroAssembly(string @eventType)
        {
            string[] eventosCore = new string[] { "EntityEvent" };

            return eventosCore.Contains(@eventType);
        }
    }
}
