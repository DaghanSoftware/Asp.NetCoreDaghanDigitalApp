using System.Threading.Tasks;

namespace DaghanDigital.Core.UnitOfWorks
{
    public interface IUnitOfWork
    {
        Task CommitAsync();
        void Commit();
    }
}
