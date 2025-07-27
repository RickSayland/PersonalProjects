namespace PersonalProjectsCore.Finance;

public abstract class Entity
{
    public Guid Id { get; init; } = Guid.NewGuid();
}