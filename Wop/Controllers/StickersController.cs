using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Wop.Models;

namespace Wop.Controllers
{
    public class StickersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Stickers
        public ActionResult Index()
        {
            Izbran Elem = new Izbran();
            Elem.ElSelect = db.Selects.ToList();
            Elem.ElStik = db.Stickers.ToList();
            return View(Elem);
        }

        // GET: Stickers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OneElem oneElem = new OneElem();
            oneElem.ElStik = db.Stickers.Find(id);
            if (oneElem.ElStik == null)
            {
                return HttpNotFound();
            }

            oneElem.ElSelect = db.Selects.ToList();
            
            
            return View(oneElem);
        }

        // GET: Stickers/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Stickers/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,UserName,Text,Url")] Sticker sticker)
        {
            sticker.Date = DateTime.Now;
            if (ModelState.IsValid)
            {
                db.Stickers.Add(sticker);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sticker);
        }

        // GET: Stickers/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sticker sticker = db.Stickers.Find(id);
            if (sticker == null)
            {
                return HttpNotFound();
            }
            return View(sticker);
        }

        // POST: Stickers/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,UserName,Text,Url")] Sticker sticker)
        {
            sticker.Date = DateTime.Now;
            if (ModelState.IsValid)
            {
                db.Entry(sticker).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sticker);
        }

        [HttpGet]
        [Authorize]
        public ActionResult Izbran(int StickId = -1, string UserId = null)
        {
            if(StickId == -1 || UserId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Select selecter = new Select();
            selecter.StickId = StickId;
            selecter.UserId = UserId;
            db.Selects.Add(selecter);
            db.SaveChanges();   
            
            return RedirectToAction("Index");
        }


        [Authorize]
        [HttpPost]
        public ActionResult Izbran(Poisk poisс)
        {
            if (poisс.Poisc == null)
            {
                ViewBag.Poisk = "";
            }
            else
            {
                ViewBag.Poisk = poisс.Poisc;
            }    
            Izbran Elem = new Izbran();
            Elem.ElSelect = db.Selects.ToList();
            Elem.ElStik = db.Stickers.ToList();
            return View(Elem);
        }
        // GET: Stickers/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sticker sticker = db.Stickers.Find(id);
            if (sticker == null)
            {
                return HttpNotFound();
            }
            return View(sticker);
        }

        // POST: Stickers/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sticker sticker = db.Stickers.Find(id);
            foreach(var i in db.Selects.ToList())
            {
                if(i.StickId == id)
                {
                    db.Selects.Remove(i);
                }
            }
            db.Stickers.Remove(sticker);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
