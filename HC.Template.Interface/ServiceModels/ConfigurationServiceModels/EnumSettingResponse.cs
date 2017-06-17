namespace HC.Template.Interface.ServiceModels.ConfigurationServiceModels
{
    public class EnumSettingResponse
    {
        public InternalEnum InternalEnum { get; set; }
    }

    public enum InternalEnum
    {
        Off = 0,
        On = 1
    }
}
