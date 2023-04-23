namespace Environment.Settings;

public class DatabaseSettings
{
    public string MongoDbConnectionString { get; set; } = null!;
    public string DatabaseName { get; set; } = null!;
    public string CollectionName { get; set; } = null!;

}