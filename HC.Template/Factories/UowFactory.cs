using HC.Template.Infrastructure.UOWs;
using HC.Template.Infrastructure.UOWs.Contracts;

namespace HC.Template.Factories
{
    public class UowFactory
    {
        public UowFactory(): base()
        {

        }

        public IUnitOfWork GetUnitOfWork()
        {
            return new UnitOfWork();
        }

    }
}
