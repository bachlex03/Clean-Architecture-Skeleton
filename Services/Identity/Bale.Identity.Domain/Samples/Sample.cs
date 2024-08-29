
using Bale.Identity.Domain.Common.Primitives;
using MongoDB.Bson.Serialization.Attributes;

namespace Bale.Identity.Domain.Samples;

public class Sample : Entity
{
    [BsonId]
    public string Id { get; set; }

    [BsonElement("name")]
    public string Name { get; set; }
    [BsonElement("email")]
    public string Email { get; set; }

}
