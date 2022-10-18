using MongoDB.Bson;
using MongoDB.Driver;
using MVC_MongoDB_CRUD.Models;
using System.Collections.Generic;

namespace MVC_MongoDB_CRUD.Repositories {
    public class AlbumCollection : IAlbumCollection{
        internal MongoDBRepository _repository = new MongoDBRepository();
        private IMongoCollection<Album> Collection;
        public AlbumCollection() {
            Collection = _repository.db.GetCollection<Album>("Albums");
        }

        public void DeleteAlbum(string Id) {
            var filter = Builders<Album>
            .Filter
            .Eq(x => x.Id, new ObjectId(Id));
            Collection.DeleteOneAsync(filter);
        }

        public Album GetAlbumById(string Id) {
            var album = Collection.Find(new BsonDocument { { "_id", new ObjectId(Id)} }).FirstAsync().Result;
            return album;
        }

        public List<Album> GetAllAlbums() {
            var query = Collection.Find(new BsonDocument()).ToListAsync();
            return query.Result;
        }

        public void InsertAlbum(Album album) {
            Collection.InsertOneAsync(album);
        }

        public void UpdateAlbum(Album album) {
            var filter = Builders<Album>
                .Filter
                .Eq(x => x.Id, album.Id);
            Collection.ReplaceOneAsync(filter, album);
        } 
    }
}
