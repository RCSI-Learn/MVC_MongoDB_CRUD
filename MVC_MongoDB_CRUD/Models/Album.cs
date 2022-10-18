using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MVC_MongoDB_CRUD.Models {
    public class Album {
        [BsonId]
        public ObjectId Id { get; set; } 
        public string Name { get; set; }
        public string Artist { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int Duration { get; set; }
        public List<Song> Songs { get; set; }
    }
}
