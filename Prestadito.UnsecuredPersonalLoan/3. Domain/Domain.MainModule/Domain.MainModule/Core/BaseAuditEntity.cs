﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Prestadito.UnsecuredPersonalLoan.Domain.MainModule.Core
{
    public class BaseAuditEntity : AuditEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = null!;

        [BsonElement("blnActive")]
        public bool BlnActive { get; set; }
    }
}
