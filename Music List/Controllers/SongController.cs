using Microsoft.AspNetCore.Mvc;
using Music_List.Data;
using Music_List.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Music_List.Controllers
{
    public class SongController : Controller
    {
        private readonly ApplicationDbContext _db;

        public SongController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Song> objList = _db.Songs;
            return View(objList);
        }

        //Get Create
        public IActionResult Create()
        {
            return View();
        }

        //Post Create
        [HttpPost] //need to have this 
        [ValidateAntiForgeryToken] //means it will be secure and only worked when logged in etc
        public IActionResult Create(Song obj)
        {
            _db.Songs.Add(obj); //power of entity framework to be able to add by passing the obj from argument
            _db.SaveChanges(); //entity framework saves the changes to db
            return RedirectToAction("Index"); //instead of returning view it uses the Index Action from above
        }


        //Post Delete
        [HttpPost] //need to have this 
        [ValidateAntiForgeryToken] //means it will be secure and only worked when logged in etc
        public IActionResult DeletePost(int? id) //not passing obj but the ID so when it deletes on page path ?means optional
        {
            var obj = _db.Songs.Find(id);
            if(obj == null)
            {
                return NotFound();
            }

            _db.Songs.Remove(obj); //power of entity framework to be able to delete by passing the obj from argument
            _db.SaveChanges(); //entity framework saves the changes to db
            return RedirectToAction("Index"); //instead of returning view it uses the Index Action from above
        }


        //Get Delete
        public IActionResult Delete(int? id) //not passing obj but the ID so when it deletes on page path ?means optional
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _db.Songs.Find(id);

            if(obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }


        //Get update
        public IActionResult Update(int? id) //not passing obj but the ID so when it deletes on page path ?means optional
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _db.Songs.Find(id);

            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }


        //Post Update
        [HttpPost] //need to have this 
        [ValidateAntiForgeryToken] //means it will be secure and only worked when logged in etc
        public IActionResult UpdatePost(Song obj)
        {
            _db.Songs.Update(obj); //power of entity framework to be able to add by passing the obj from argument
            _db.SaveChanges(); //entity framework saves the changes to db
            return RedirectToAction("Index"); //instead of returning view it uses the Index Action from above
        }
    }
}
