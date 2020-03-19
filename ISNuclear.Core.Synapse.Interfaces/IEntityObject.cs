using System.ComponentModel;

namespace ISNuclear.Data.Interfaces
{
    public interface IEntityObject: IDeleteable
    {
        int Id { get; }
    }
}
