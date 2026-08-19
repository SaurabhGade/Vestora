namespace Vestora.DAL.Entities;

public class ConfigSetting
{
    /// <summary>
    /// Author: Saurabh Gade
    /// COM_CONFIGSETTINGS Table for migration
    /// </summary>
    public long ConfigId { get; set; }

    public string ConfigKey { get; set; } = string.Empty;

    public string? ConfigValue { get; set; }

    public string ConfigType { get; set; } = "STRING";

    public string? Description { get; set; }

    public bool IsActive { get; set; }

    public long? CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    public long? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }
}