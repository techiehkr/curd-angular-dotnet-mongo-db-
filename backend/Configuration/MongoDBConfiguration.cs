namespace backend.Configuration;

public class MongoDBConfiguration
{
    public string ConnectionString { get; set; } // corrected the property name here
    public string DatabaseName { get; set; }
}
