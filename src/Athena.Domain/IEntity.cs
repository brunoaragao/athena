namespace Athena.Domain;

public interface IEntity<TEntityId>
{
    public TEntityId Id { get; }
}