using System;
using System.Collections.Generic;
using System.Text;
using HC.Template.Infrastructure.UOWs.Contracts;

namespace HC.Template.Factories.Contracts
{
    public interface IUowFactory
    {
        IUnitOfWork GetUnitOfWork();
    }
}
