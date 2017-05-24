using HC.Template.Domain.Models;
using HC.Template.Interface.ServiceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HC.Template.Infrastructure.ConfigModels;
using HC.Template.InternalServices.Mappers.Contracts;

namespace HC.Template.Mappers
{
    public class ExampleServiceMapper : IExampleServiceMapper
    {
        public ExampleResponse  MapGetExampleString(AppSettings appSettings)
        {
            var response = new ExampleResponse()
            {
                ApplicationTitle = appSettings.ApplicationTitle
            };

            return response;
        }
    }
}
