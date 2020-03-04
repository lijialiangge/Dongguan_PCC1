using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Eaton_DG_PCC.Models;

namespace Eaton_DG_PCC.Controllers
{
    public class datangsController : Controller
    {
        private datangEntities db = new datangEntities();

        // GET: datangs
        public ActionResult Index()
        {
            return View(db.datang.ToList());
        }
        public ActionResult Indexs()
        {
            return View(db.datang.ToList());
        }
        public ActionResult Login()
        {
            //AdminEntity entity = this.Admin.GetSingle(1);
            //return View(db.datang.ToList());
            return View();
        }

        // GET: datangs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            datang datang = db.datang.Find(id);
            if (datang == null)
            {
                return HttpNotFound();
            }
            return View(datang);
        }

        // GET: datangs/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: datangs/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,uid,name,password,grp,time,other")] datang datang)
        {
            if (ModelState.IsValid)
            {
                db.datang.Add(datang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(datang);
        }

        // GET: datangs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            datang datang = db.datang.Find(id);
            if (datang == null)
            {
                return HttpNotFound();
            }
            return View(datang);
        }

        // POST: datangs/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,uid,name,password,grp,time,other")] datang datang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(datang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(datang);
        }

        // GET: datangs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            datang datang = db.datang.Find(id);
            if (datang == null)
            {
                return HttpNotFound();
            }
            return View(datang);
        }

        // POST: datangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            datang datang = db.datang.Find(id);
            db.datang.Remove(datang);
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
