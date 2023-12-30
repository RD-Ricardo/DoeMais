namespace DM.Core.DomainObjects.ValueObjects
{
    public class Email
    {
        public string  Value { get; private set; }
        public Email(string value)
        {
            Value = value;
        }
    }
}
