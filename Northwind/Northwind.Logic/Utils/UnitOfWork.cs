using NHibernate;
using System;
using System.Data;

namespace Northwind.Logic.Utils
{
    public class UnitOfWork : IDisposable
    {
        private readonly ISession _session;
        private readonly ITransaction _transaction;
        private bool _isAlive = true;
        private bool _isCommitted;

        public UnitOfWork()
        {
            _session = SessionFactory.OpenSession();
            _transaction = _session.BeginTransaction(IsolationLevel.ReadCommitted);
        }

        public void Dispose()
        {
            if (_isAlive == false)
            {
                return;
            }

            _isAlive = false;

            try
            {
                if (_isCommitted)
                {
                    _transaction.Commit();
                }
            }
            finally
            {
                _transaction.Dispose();
                _session.Dispose();
            }
        }

        public void Commit()
        {
            if (_isAlive == false)
            {
                return;
            }

            _isCommitted = true;
        }

        //TODO

        internal void SaveOrUpdate<T>(T entity)
        {
            //TODO next
            _session.SaveOrUpdate(entity);
        }

        //TODO
    }
}
