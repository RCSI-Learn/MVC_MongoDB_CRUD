using MongoDB.Driver;
namespace MVC_MongoDB_CRUD.Repositories {
    public class MongoDBRepository {
        MongoClient client;
        public IMongoDatabase db;
        public MongoDBRepository() {
            this.client = new MongoClient("mongodb://admin:secret@archbspwm1:27017");
            db = client.GetDatabase("MusicCatalog");
        }
    }
}
