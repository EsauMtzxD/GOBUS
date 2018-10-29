using GOBUS.Data.Contratos;
using GOBUS.Data.Repositorios;
using GOBUS.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GOBUS.Controllers
{
    public class SucursaleController : Controller
    {

        private GOBUSContext dbCtx = new GOBUSContext();

        private IRepositorioSucursale<Sucursale> RepositorioSucursale;

        public SucursaleController()
        {

            this.RepositorioSucursale = new RepositorioSucursale<Sucursale>(new GOBUSContext());

        }

        public SucursaleController(IRepositorioSucursale<Sucursale> repositorioSucursale)
        {

            this.RepositorioSucursale = repositorioSucursale;

        }

        public ActionResult Index()
        {

            //List<Sucursale> sucursales = new List<Sucursale>();

            //sucursales = dbCtx.Sucursales.OrderBy(x => x.Nombre).ToList();

            var sucursales = from s in RepositorioSucursale.GetSucursales()
                             select s;

            return View(sucursales);
        }

        public ActionResult Details(int id)
        {

            //Sucursale sucursale = dbCtx.Sucursales.Find(id);

            //if(sucursale == null)
            //{

            //    return HttpNotFound();

            //}

            Sucursale sucursale = RepositorioSucursale.GetSucursaleById(id);

            return View(sucursale);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Sucursale sucursale)
        {
            try
            {

                if (ModelState.IsValid)
                {

                    try
                    {

                        //dbCtx.Sucursales.Add(sucursale);

                        //dbCtx.SaveChanges();

                        RepositorioSucursale.InsertarSucursale(sucursale);
                        RepositorioSucursale.Save();

                    }
                    catch (DbEntityValidationException e)
                    {
                        foreach (var eve in e.EntityValidationErrors)
                        {
                            Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                                eve.Entry.Entity.GetType().Name, eve.Entry.State);
                            foreach (var ve in eve.ValidationErrors)
                            {
                                Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"", ve.PropertyName, ve.ErrorMessage);
                            }
                        }
                        throw;
                    }

                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {

            //Sucursale sucursale = dbCtx.Sucursales.Find(id);

            //if(sucursale == null)
            //{

            //    return HttpNotFound();

            //}

            Sucursale sucursale = RepositorioSucursale.GetSucursaleById(id);

            return View(sucursale);
        }

        [HttpPost]
        public ActionResult Edit(Sucursale sucursale)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    try
                    {
                        //dbCtx.Entry(sucursale).State = System.Data.Entity.EntityState.Modified;
                        //dbCtx.SaveChanges();

                        RepositorioSucursale.UpdateSucursale(sucursale);
                        RepositorioSucursale.Save();

                    }
                    catch (DbEntityValidationException e)
                    {

                        foreach (var eve in e.EntityValidationErrors)
                        {

                            Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                                eve.Entry.Entity.GetType().Name, eve.Entry.State);

                            foreach (var ve in eve.ValidationErrors)
                            {

                                Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"", ve.PropertyName, ve.ErrorMessage);

                            }
                        }
                        throw;
                    }
                }

                    return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {

            //Sucursale sucursale = dbCtx.Sucursales.Find(id);

            //if(sucursale == null)
            //{

            //    return HttpNotFound();

            //}

            Sucursale sucursale = RepositorioSucursale.GetSucursaleById(id);

            return View(sucursale);
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {

                try
                {
                    //Sucursale sucursale = dbCtx.Sucursales.Find(id);

                    //dbCtx.Sucursales.Remove(sucursale);

                    //dbCtx.SaveChanges();

                    Sucursale s = RepositorioSucursale.GetSucursaleById(id);
                    RepositorioSucursale.DeleteSucursale(id);
                    RepositorioSucursale.Save();

                }
                catch (DbEntityValidationException e)
                {

                    foreach (var eve in e.EntityValidationErrors)
                    {

                        Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                            eve.Entry.Entity.GetType().Name, eve.Entry.State);

                        foreach (var ve in eve.ValidationErrors)
                        {

                            Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"", ve.PropertyName, ve.ErrorMessage);

                        }
                    }
                    throw;
                }


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
