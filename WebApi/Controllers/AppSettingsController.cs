using HC.Template.Interface.Contracts;
using HC.Template.Interface.ServiceModels.ConfigurationServiceModels;
using Microsoft.AspNetCore.Mvc;

namespace HC.Template.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/AppSettings")]
    public class AppSettingsController : Controller
    {
        private IAppSettingsService _appSettingService;

        public AppSettingsController(IAppSettingsService appSettingService)
        {
            _appSettingService = appSettingService;
        }
        
        [HttpGet]
        [Route("GetApplicationTitle")]
        public AppTitleResponse GetAppSettingsApplicationTitle()
        {
            var response = _appSettingService.GetApplicationTitle();
            return response;
        }
        
        [HttpGet]
        [Route("GetStringSetting")]
        public StringSettingResponse GetAppSettingsStringSetting()
        {
            var response = _appSettingService.GetStringSetting();
            return response;
        }
        
        [HttpGet]
        [Route("GetIntSetting")]
        public IntSettingResponse GetAppSettingsIntSetting()
        {
            var response = _appSettingService.GetIntSetting();
            return response;
        }
        
        [HttpGet]
        [Route("GetEnumSetting")]
        public EnumSettingResponse GetAppSettingsEnumSetting()
        {
            var response = _appSettingService.GetEnumSetting();
            return response;
        }
        
        [HttpGet]
        [Route("GetListSetting")]
        public ListSettingResponse GetAppSettingsListSetting()
        {
            var response = _appSettingService.GetListSetting();
            return response;
        }
        
        [HttpGet]
        [Route("GetDictionarySetting")]
        public DictSettingResponse GetAppSettingsDictionarySetting()
        {
            var response = _appSettingService.GetDictionarySetting();
            return response;
        }

        [HttpGet]
        [Route("GetApplicationSettings")]
        public AppSettingsResponse GetAppSettingsApplicationSettings()
        {
            var response = _appSettingService.GetApplicationSettings();
            return response;
        }

        [HttpGet]
        [Route("GetConfigSettings")]
        public ConfigSettingsResponse GetAppSettingsConfigSettings()
        {
            var response = _appSettingService.GetConfigSettings();
            return response;
        }
    }
}