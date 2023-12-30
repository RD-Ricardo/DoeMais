using DM.Core.WebApi;
using FluentValidation.Results;
using MediatR;

namespace DM.Core.Messages
{
    public abstract class Query<TResponse> : Message, IRequest<RequestResult<TResponse>>
    {
        public DateTime TimeStamp { get; private set; } = DateTime.Now;
        public ValidationResult ValidationResultQuery { get; set; }
        
        public Query()
        {
            ValidationResultQuery = new ValidationResult();
        }

        public abstract bool IsValid();
    }
}
