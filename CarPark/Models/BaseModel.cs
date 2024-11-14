﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CarPark.Models
{
    public abstract class BaseModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = "";
    }
}
