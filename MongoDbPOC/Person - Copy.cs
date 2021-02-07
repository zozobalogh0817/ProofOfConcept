using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDbPOC
{
    public class PersonCopy
    {
        public int id { get; set; }
        public IEnumerable<int> dogids { get; set; }
        [BsonIgnore]
        public IEnumerable<DogCopy> dogs { get; set; }
        public string name { get; set; }
    }
}