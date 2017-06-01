using HC.Template.Interface.ServiceModels.ConfigurationServiceModels;
using HC.Template.InternalServices.ConfigurationService.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HC.Template.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Settings")]
    public class SettingsController : Controller
    {
        private IConfigService _configservice;

        public SettingsController(IConfigService configservice)
        {
            _configservice = configservice;
        }


        [HttpGet]
        [Route("GetApplicationTitle")]
        public AppTitleResponse GetConfigApplicationTitle()
        {
            var response = _configservice.GetApplicationTitle();
            return response;
        }


        [HttpGet]
        [Route("GetStringSetting")]
        public StringSettingResponse GetConfigStringSetting()
        {
            var response = _configservice.GetStringSetting();
            return response;
        }


        [HttpGet]
        [Route("GetIntSetting")]
        public IntSettingResponse GetConfigIntSetting()
        {
            var response = _configservice.GetIntSetting();
            return response;
        }


        [HttpGet]
        [Route("GetEnumSetting")]
        public EnumSettingResponse GetConfigEnumSetting()
        {
            var response = _configservice.GetEnumSetting();
            return response;
        }


        [HttpGet]
        [Route("GetListSetting")]
        public ListSettingResponse GetConfigListSetting()
        {
            var response = _configservice.GetListSetting();
            return response;
        }


        [HttpGet]
        [Route("GetDictionarySetting")]
        public DictSettingResponse GetConfigDictionarySetting()
        {
            var response = _configservice.GetDictionarySetting();
            return response;
        }
    }
}