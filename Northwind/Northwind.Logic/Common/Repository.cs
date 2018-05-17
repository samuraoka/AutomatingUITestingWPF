using Northwind.Logic.Utils;

namespace Northwind.Logic.Common
{
    public abstract class Repository<T>
        where T : Entity
    {
        //TODO

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
