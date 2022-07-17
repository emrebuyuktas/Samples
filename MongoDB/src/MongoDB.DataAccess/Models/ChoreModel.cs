
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDB.DataAccess.Models
{
    public class ChoreModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string ChoreText { get; set; }
        public int FruquencyInDays { get; set; }
        public UserModel? AssignedTo { get; set; }
        public DateTime? LastCompleted { get; set; }
    }
}
