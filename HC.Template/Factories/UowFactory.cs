using HC.Template.Factories.Contracts;
using HC.Template.Infrastructure.ConfigModels;
using HC.Template.Infrastructure.UOWs;
using HC.Template.Infrastructure.UOWs.Contracts;

namespace HC.Template.Factories
{
    public class UowFactory: IUowFactory
    {
        private ConnectionStrings _connectionSettings;

        /* *************************************
         * Not sure if I should use this. Depends on dependency injection from startup.cs
        //private IUnitOfWork _uow;
        //public UowFactory(ConnectionStrings connectionSettings, IUnitOfWork uow) : base()
        //{
        //    _connectionSettings = connectionSettings;
        //    _uow = uow;
        //}

        //public IUnitOfWork GetUnitOfWork()
        //{
        //    return _uow;
        //}
       
         */

        public UowFactory(ConnectionStrings connectionSettings) : base()
        {
            _connectionSettings = connectionSettings;
        }

        public IUnitOfWork GetUnitOfWork()
        {
            return new UnitOfWork(_connectionSettings);
        }

    }
}
