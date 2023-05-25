using System.Collections.Generic;

namespace Library.UI.Services
{
    public interface IBaseRepository<TEntity> where TEntity :class
    {
        IEnumerable<TEntity> GetAll();

        TEntity GetByID(object id);

        void Insert(TEntity entity);

        void Update(TEntity entityToUpdate);

        void Delete(TEntity entityToDelete);

        void Delete(object id);

        void Save();
    }
}
