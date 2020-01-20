using PSS.Models;
using PSS.Utils;
using SGCO.Context;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.Script.Serialization;
using System.Web;

namespace PSS.Controllers
{
    public sealed class UsersController : Controller
    {
        private readonly DBContext _context = new DBContext();

        [Authorize]
        public ActionResult Index()
        {
            if (Global.User == null)
            {
                return RedirectToAction("Login");
            }

            var users = _context.Users.Include(u => u.City).Where(u => u.IsActive).OrderBy(u => u.Name);

            if (Global.User.UserType == UserType.Customer)
            {
                return View(users.ToList().Where(u => u.Id == Global.User.Id));
            }

            return View(users.ToList());
        }

        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            User user = _context.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }

            user.City = _context.Cities.Find(user.CityId);

            return View(user);
        }
       
        public ActionResult Create()
        {
            ViewBag.CityId = new SelectList(_context.Cities.Where(c => c.IsActive).OrderBy(c => c.Name), "Id", "Name");

            return View();
        }
      
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                _context.Users.Add(user);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.CityId = new SelectList(_context.Cities.Where(c => c.IsActive).OrderBy(c => c.Name), "Id", "Name", user.CityId);

            return View(user);
        }

        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (id != Global.User.Id)
            {
                return new HttpStatusCodeResult(HttpStatusCode.Unauthorized);
            }

            User user = _context.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }

            ViewBag.CityId = new SelectList(_context.Cities.Where(c => c.IsActive).OrderBy(c => c.Name), "Id", "Name", user.CityId);

            return View(user);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(user).State = EntityState.Modified;
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.CityId = new SelectList(_context.Cities.Where(c => c.IsActive).OrderBy(c => c.Name), "Id", "Name", user.CityId);

            return View(user);
        }

        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (id != Global.User.Id)
            {
                return new HttpStatusCodeResult(HttpStatusCode.Unauthorized);
            }

            User user = _context.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }

            user.City = _context.Cities.Find(user.CityId);

            return View(user);
        }

        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = _context.Users.Find(id);
            user.IsActive = false;
            _context.Entry(user).State = EntityState.Modified;
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult Login(User user)
        {
            var model = _context.Users.Where(u => u.Email.Equals(user.Email) && u.Password.Equals(user.Password)).FirstOrDefault();

            if (model == null)
            {
                return RedirectToAction("Login");
            }

            SetAuthenticationToken(model);

            return RedirectToAction("Index");
        }

        [AllowAnonymous]
        public ActionResult Logout()
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
                Global.User = user;
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
            catch (System.Exception)
            {
                // TODO: Tratar erro
            }

            return user;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
