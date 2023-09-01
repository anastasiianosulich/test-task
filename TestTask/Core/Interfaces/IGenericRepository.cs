using Core.Entities;
using Core.Specifications;

public interface IGenericRepository<T> where T : BaseEntity
{
   Task<T> GetByIdAsync(int id);
   Task<T> GetEntityBySpecificationAsync(ISpecification<T> specification);
   Task<IReadOnlyList<T>> GetAllWithSpecificationAsync(ISpecification<T> specification);
   Task<IReadOnlyList<T>> GetAllAsync();
   void Add(T entity);
   void Update(T entity);
   void Delete(T entity);
}