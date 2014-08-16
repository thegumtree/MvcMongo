using MVCMongo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCMongo.Controllers
{
    public class MongoController : Controller
    {
        MongoDBEntities db = new MongoDBEntities();
        //
        // GET: /Mongo/

        public ActionResult Index()
        {
            var collection = from f in db.Departments
                             select f;
            return View(collection);
        }

        //
        // GET: /Mongo/Details/5

        public ActionResult Details(int id)
        {
            Department dep = (from f in db.Departments
                              where f.DepartmentId == id
                              select f).First();
            return View(dep);
        }

        //
        // GET: /Mongo/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Mongo/Create

        [HttpPost]
        public ActionResult Create(Department dept)
        {
            try
            {
                db.CreateDepartment(dept);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //
        // GET: /Mongo/Edit/5

        public ActionResult Edit(int id = 0)
        {
            List<Department> list = (from f in db.Departments
                                     where f.DepartmentId == id
                                     select f).ToList();
            Department dept = new Department();
            if (list.Count > 0) dept = list[0];
            return View(dept);
        }

        //
        // POST: /Mongo/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, Department dept)
        {
            try
            {
                db.EditDepartment(dept);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Mongo/Delete/5

        public ActionResult Delete(int id)
        {
            Department dep = (from f in db.Departments
                              where f.DepartmentId == id
                              select f).First();
            return View(dep);
        }

        //
        // POST: /Mongo/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, Department collection)
        {
            try
            {
                Department dep = (from f in db.Departments
                                  where f.DepartmentId == id
                                  select f).First();
                db.DeleteDepartment(dep);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (db == null) db.Dispose();
            base.Dispose(disposing);
        }
    }
}
