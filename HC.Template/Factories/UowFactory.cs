using HC.Template.Factories.Contracts;
using HC.Template.Infrastructure.ConfigModels;
using HC.Template.Infrastructure.UOWs;
using HC.Template.Infrastructure.UOWs.Contracts;

namespace HC.Template.Factories
{
    public class UowFactory: IUowFactory
    {
        private ConnectionStrings _connectionSettings;

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
