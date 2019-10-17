using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using PSS.Models;
using SGCO.Context;

namespace PSS.Controllers
{
    public class UsersController : Controller
    {
        private Context db = new Context();

        public ActionResult Index()
        {
            User loggedUser = (User)Session["User"];

            if (loggedUser != null)
            {
                var users = db.Users.Include(u => u.City)
                                    .Include(u => u.Gender)
                                    .Include(u => u.UserType)
                                    .Where(u => u.IsActive == true);

                if (loggedUser.UserTypeId == UserType.Client)
                {
                    return View(users.ToList().Where(u => u.Id == loggedUser.Id));
                }

                return View(users.ToList());
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }

            user.City = db.Cities.Find(user.CityId);
            user.Gender = db.Genders.Find(user.GenderId);
            user.UserType = db.UserTypes.Find(user.UserTypeId);

            return View(user);
        }

        public ActionResult Create()
        {
            ViewBag.CityId = new SelectList(db.Cities, "Id", "Name");
            ViewBag.GenderId = new SelectList(db.Genders, "Id", "Description");
            ViewBag.UserTypeId = new SelectList(db.UserTypes, "Id", "Description");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,LastName,CPF,Phone,Email,Birth,Password,UserTypeId,GenderId,Address,Number,PostalCode,Complement,Reference,CityId,IsActive")] User user)
        {
            if (ModelState.IsValid)
            {
                user.IsActive = true;
                db.Users.Add(user);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.CityId = new SelectList(db.Cities, "Id", "Name", user.CityId);
            ViewBag.GenderId = new SelectList(db.Genders, "Id", "Description", user.GenderId);
            ViewBag.UserTypeId = new SelectList(db.UserTypes, "Id", "Description", user.UserTypeId);

            return View(user);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }

            ViewBag.CityId = new SelectList(db.Cities, "Id", "Name", user.CityId);
            ViewBag.GenderId = new SelectList(db.Genders, "Id", "Description", user.GenderId);
            ViewBag.UserTypeId = new SelectList(db.UserTypes, "Id", "Description", user.UserTypeId);

            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,LastName,CPF,Phone,Email,Birth,Password,UserTypeId,GenderId,Address,Number,PostalCode,Complement,Reference,CityId,IsActive")] User user)
        {
            if (ModelState.IsValid)
            {
                user.IsActive = true;
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.CityId = new SelectList(db.Cities, "Id", "Name", user.CityId);
            ViewBag.GenderId = new SelectList(db.Genders, "Id", "Description", user.GenderId);
            ViewBag.UserTypeId = new SelectList(db.UserTypes, "Id", "Description", user.UserTypeId);

            return View(user);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }

            user.City = db.Cities.Find(user.CityId);
            user.Gender = db.Genders.Find(user.GenderId);
            user.UserType = db.UserTypes.Find(user.UserTypeId);

            return View(user);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.Users.Find(id);
            user.IsActive = false;
            db.Entry(user).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User user)
        {
            var model = db.Users.Where(u => u.Email.Equals(user.Email)
                                    && u.Password.Equals(user.Password)).FirstOrDefault();

            Session["User"] = model;

            return RedirectToAction("index");
        }

        public ActionResult Logoff()
        {
            Session["User"] = null;
            return RedirectToAction("index");
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
