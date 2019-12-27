using EO.Internal;
using Narail.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Narail.Controllers
{
    public class AuthorAdminController : Controller
    {

        // GET: AuthorAdmin
        public ActionResult Index()
        {
            using (NarailDBEntities db = new NarailDBEntities())
            {
                var a = db.Authors.ToList();
                return View(a);
            }
        }


        public ActionResult Create ()
        {
          
            return View();
        }

        [HttpPost]
        public ActionResult Create (Author author, HttpPostedFileBase File)
        {
            using (NarailDBEntities db = new NarailDBEntities())
            {
                var authorExist = db.Authors.Any(m => m.Email == author.Email);

                if (authorExist == false)
                {
                    author.Email = author.Email;
                    author.About = author.About;
                    author.NameSurname = author.NameSurname;
                    author.AddedDate = DateTime.Now;
                    author.AddedBy = "Anar Karimov";


                    if (File != null)
                    {
                        FileInfo fileInfo = new FileInfo(File.FileName);
                        WebImage img = new WebImage(File.InputStream);
                        string uzanti = (Guid.NewGuid().ToString() + fileInfo.Extension).ToLower();
                        img.Resize(225, 180, false, false);
                        string tamyol = "~/images/users/" + uzanti;
                        img.Save(Server.MapPath(tamyol));
                        author.Image = "/images/users/" + uzanti;
                    }

                    db.Authors.Add(author);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            

           
        }

        public ActionResult Delete(int? Id) 
        {

            if (Id == null)
            {
                return HttpNotFound();
            }

            using (NarailDBEntities db = new NarailDBEntities())
            {
                Author author = db.Authors.Find(Id);
                db.Authors.Remove(author);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
           
        
        
        }

        public ActionResult Details(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return HttpNotFound();

            }

            using (NarailDBEntities db = new NarailDBEntities())
            {
                Author author = db.Authors.Find(Id);
                return PartialView(author);

            }
                
        }

        public ActionResult Edit(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return HttpNotFound();

            }

            using (NarailDBEntities db = new NarailDBEntities())
            {
                Author author = db.Authors.Find(Id);
                return View(author);

            }

        }

        [HttpPost]
        public ActionResult Edit(Author author, HttpPostedFileBase File)
        {
            using (NarailDBEntities db = new NarailDBEntities())
            {
                if (author != null)
                {

                    db.Entry(author).State = System.Data.Entity.EntityState.Modified;
                    db.Entry(author).Property(m => m.AddedBy).IsModified = false;
                    db.Entry(author).Property(m => m.AddedDate).IsModified = false;
                }

                if (File != null)
                {
                    FileInfo fileInfo = new FileInfo(File.FileName);
                    WebImage img = new WebImage(File.InputStream);
                    string uzanti = (Guid.NewGuid().ToString() + fileInfo.Extension).ToLower();
                    img.Resize(225, 180, false, false);
                    string tamyol = "~/images/users/" + uzanti;
                    img.Save(Server.MapPath(tamyol));
                    author.Image = "/images/users/" + uzanti;
                }
                else
                {
                    db.Entry(author).Property(m => m.Image).IsModified = false;
                }
                author.ModifyBy = "Anar Karimov";
                author.ModifyDate = DateTime.Now;

                
            }

            using (NarailDBEntities db = new NarailDBEntities())
            {
                db.SaveChanges();
                return RedirectToAction("Index", "AuthorAdmin");
            }


        }

    }

    
    
   
}