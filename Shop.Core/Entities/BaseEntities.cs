namespace Shop.Core.Entities;

public abstract class BaseEntities
{
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public DateTime ModifiedDate { get; set; } = DateTime.Now;
    public virtual bool IsDeleted { get; set; }
}
