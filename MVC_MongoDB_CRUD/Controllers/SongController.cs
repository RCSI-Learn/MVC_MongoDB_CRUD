using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC_MongoDB_CRUD.Models;
using MVC_MongoDB_CRUD.Repositories;
using System;
using System.Collections.Generic;

namespace MVC_MongoDB_CRUD.Controllers {
    public class SongController : Controller {
        private IAlbumCollection db = new AlbumCollection();
        public IActionResult Index() {
            return View();
        }

        // GET: SongController/Create
        public ActionResult Create(string Id) {
            SongViewModel SongVM = new SongViewModel() { AlbumId = Id, Song = new Song() };
            return View(SongVM);
        }

        // POST: SongController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection) {
            try {
                var album = db.GetAlbumById(collection["AlbumId"]);
                if (album.Songs == null) {
                    album.Songs = new List<Song>();
                }
                album.Songs.Add(new Song {
                    Name = collection["Song.Name"],
                    Duration = int.Parse(collection["Song.Duration"])
                });
                db.UpdateAlbum(album);
                return RedirectToAction("Index", "Album");
            }
            catch {
                return View();
            }
        }
    }
}
