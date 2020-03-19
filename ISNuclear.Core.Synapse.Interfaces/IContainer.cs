using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;

namespace ISNuclear.Data.Interfaces
{
    public interface IContainer
    {
        DbChangeTracker ChangeTracker { get; }
        IContainer CreateContainer();
        ObjectContext ObjectContext { get; }
        DbEntityEntry<T> Entry<T>(T entity) where T:class;
        int SaveChanges();
    }
}
