using System.Net;
using DataMatrix.Domain.ActionResponse;

namespace DataMatrix.Core.IRepository.IBase;

public interface IRepo<TEntity, TDTO> where TEntity : class
{
    Task<ActionMethodResult> Delete(Guid id, CancellationToken token);
    IQueryable<TEntity> GetAll();
    Task<ActionMethodResult> Find(Guid id, CancellationToken token);
}