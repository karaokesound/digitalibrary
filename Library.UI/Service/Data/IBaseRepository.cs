using Library.UI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Library.UI.Services
{
    public interface IBaseRepository<TEntity> where TEntity :class
    {
        IEnumerable<TEntity> GetAll();

        TEntity GetByID(object id);

        //IEnumerable<TEntity> GetWithRawSql(string query, params object[] parameters);

        void Insert(TEntity entity);


        void Update(TEntity entityToUpdate);

        void Delete(TEntity entityToDelete);

        void Delete(object id);

        void Save();
    }
}
