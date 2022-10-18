using MVC_MongoDB_CRUD.Models;
using System.Collections.Generic;

namespace MVC_MongoDB_CRUD.Repositories {
    public interface IAlbumCollection {
        void InsertAlbum(Album album);
        void UpdateAlbum(Album album);
        void DeleteAlbum(string Id);
        List<Album> GetAllAlbums();
        Album GetAlbumById(string Id);
    }
}
