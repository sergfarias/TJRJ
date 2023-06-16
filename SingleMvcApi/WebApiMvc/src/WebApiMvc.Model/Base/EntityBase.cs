namespace WebApiMvc.Model.Base;

public abstract class EntityBase
{

    public Guid Id { get; private set; }

    protected EntityBase(Guid id)
    {
        Id = id;
    }
}
