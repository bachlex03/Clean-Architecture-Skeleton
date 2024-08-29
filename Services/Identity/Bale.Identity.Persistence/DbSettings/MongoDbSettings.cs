
namespace Bale.Identity.Persistence.DbSettings;

public class MongoDbSettings
{
   public const string SectionName = "MongoDbSettings";
    public string connectionString { get; set; }
    public string DatabaseName { get; set; }
}
