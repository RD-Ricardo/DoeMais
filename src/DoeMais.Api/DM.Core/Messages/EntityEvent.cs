namespace DM.Core.Messages
{
    public class EntityEvent : Event
    {
        public string ContentEntity { get; private set; }
        public Type EntityType { get; private set; }
        public EntityStateEvent State { get; private set; }
        public int EntidadeId { get; private set; }
        public EntityEvent(string contentEntity, Type entityType, EntityStateEvent state, int entidadeId)
        {
            ContentEntity = contentEntity;
            EntityType = entityType;
            State = state;
            EntidadeId = entidadeId;
        }
    }
}
