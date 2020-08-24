using System.Collections.Generic;
using System.Threading.Tasks;
using core.Entities;
using core.Specifications;

namespace core.Interface
{
    public interface  IGenericRespository<T> where T : BaseEntities
    {
      Task<T> GetByIdAsync(int id);   
      
      Task<IReadOnlyList<T>> ListAllAsync();
      Task<T> GetEntitywithspec(ISpecification<T> spec);
      Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec);
    }
}