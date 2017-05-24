using System;
using System.Collections.Generic;
using System.Text;
using HC.Template.Infrastructure.ConfigModels;
using HC.Template.Interface.ServiceModels;

namespace HC.Template.InternalServices.Mappers.Contracts
{
    public interface IExampleServiceMapper
    {
        ExampleResponse MapGetExampleString(AppSettings appSettings);
    }
}
