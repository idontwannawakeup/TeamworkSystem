namespace TeamworkSystem.DataAccessLayer.Interfaces
{
    public interface IIdentifiableEntity : IEntity
    {
        int Id { get; }
    }
}
