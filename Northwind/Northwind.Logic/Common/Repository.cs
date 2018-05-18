using Northwind.Logic.Utils;

namespace Northwind.Logic.Common
{
    public abstract class Repository<T>
        where T : Entity
    {
        public T GetById(long id)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                return unitOfWork.Get<T>(id);
            }
        }

        public void Save(T entity)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                unitOfWork.SaveOrUpdate(entity);
                unitOfWork.Commit();
            }
        }

        //TODO
    }
}
