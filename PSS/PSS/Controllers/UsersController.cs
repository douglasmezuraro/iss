using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using PSS.Models;
using SGCO.Context;
using PSS.Utils;
using System.Web.Security;
using System.Web.Script.Serialization;
using System.Web;

namespace PSS.Controllers
{
    public class UsersController : Controller
    {
        private Context db = new Context();

        [Authorize]
        public ActionResult Index()
        {
            if (Global.User != null)
            {
                var users = db.Users.Include(u => u.City).Where(u => u.IsActive).OrderBy(u => u.Id);

                if (Global.User.UserType == UserType.Customer)
                {
                    return View(users.ToList().Where(u => u.Id == Global.User.Id));
                }

                return View(users.ToList());
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        [Authorize]
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

            return View(user);
        }
       
        public ActionResult Create()
        {
            ViewBag.CityId = new SelectList(db.Cities.Where(c => c.IsActive).OrderBy(c => c.Name), "Id", "Name");

            return View();
        }
      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.CityId = new SelectList(db.Cities.Where(c => c.IsActive).OrderBy(c => c.Name), "Id", "Name", user.CityId);

            return View(user);
        }

        [Authorize]
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

            ViewBag.CityId = new SelectList(db.Cities.Where(c => c.IsActive).OrderBy(c => c.Name), "Id", "Name", user.CityId);

            return View(user);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.CityId = new SelectList(db.Cities.Where(c => c.IsActive).OrderBy(c => c.Name), "Id", "Name", user.CityId);

            return View(user);
        }

        [Authorize]
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

            return View(user);
        }

        [Authorize]
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
        [AllowAnonymous]
        public ActionResult Login(User user)
        {
            var model = db.Users.Where(u => u.Email.Equals(user.Email) && u.Password.Equals(user.Password)).FirstOrDefault();

            if (model == null)
            {
                return RedirectToAction("Login");
            }

            Global.User = model;
            SetAuthenticationToken(model);

            return RedirectToAction("Index");
        }

        [AllowAnonymous]
        public ActionResult Logoff()
        {
            Global.User = null;
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

        private void SetAuthenticationToken(User user)
        {
            string data = null;

            if (user != null)
            {
                data = new JavaScriptSerializer().Serialize(user);
            }

            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, user.Name, System.DateTime.Now, System.DateTime.Now.AddDays(1), true, user.Email);
            string cookieData = FormsAuthentication.Encrypt(ticket);

            HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, cookieData)
            {
                HttpOnly = true,
                Expires = ticket.Expiration
            };

            HttpContext.Response.Cookies.Add(cookie);
        }

        private User GetUserData()
        {
            User user = null;

            try
            {
                HttpCookie cookie = HttpContext.Request.Cookies[FormsAuthentication.FormsCookieName];
                if (cookie != null)
                {
                    FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(cookie.Value);

                    user = new JavaScriptSerializer().Deserialize(ticket.UserData, typeof(User)) as User;
                }
            }
            catch (System.Exception ex)
            {
                // TODO: Tratar erro
            }

            return user;
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
