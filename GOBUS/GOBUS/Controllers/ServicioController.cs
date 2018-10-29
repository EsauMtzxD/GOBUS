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
    public class ServicioController : Controller
    {

        private GOBUSContext dbCtx = new GOBUSContext();

        private IRepositorioServicio<Servicio> RepositorioServicio;

        public ServicioController()
        {

            this.RepositorioServicio = new RepositorioServicio<Servicio>(new GOBUSContext());

        }

        public ServicioController(IRepositorioServicio<Servicio> repositorioServicio)
        {

            this.RepositorioServicio = repositorioServicio;

        }

        public ActionResult Index()
        {

            //List<Servicio> servicios = new List<Servicio>();

            //servicios = dbCtx.Servicios.OrderBy(x => x.NombreServicio).ToList();

            var servicios = from s in RepositorioServicio.GetServicios()
                            select s;

            return View(servicios);
        }

        public ActionResult Details(int id)
        {

            //Servicio servicio = dbCtx.Servicios.Find(id);

            //if(servicio == null)
            //{

            //    return HttpNotFound();

            //}

            Servicio servicio = RepositorioServicio.GetServicioById(id);

            return View(servicio);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Servicio servicio)
        {
            try
            {

                if (ModelState.IsValid)
                {

                    try
                    {

                        //dbCtx.Servicios.Add(servicio);

                        //dbCtx.SaveChanges();

                        RepositorioServicio.InsertarServicio(servicio);
                        RepositorioServicio.Save();

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

            //Servicio servicio = dbCtx.Servicios.Find(id);

            //if(servicio == null)
            //{

            //    return HttpNotFound();

            //}

            Servicio servicio = RepositorioServicio.GetServicioById(id);

            return View(servicio);
        }

        [HttpPost]
        public ActionResult Edit(Servicio servicio)
        {
            try
            {

                if (ModelState.IsValid)
                {

                    try
                    {

                        //dbCtx.Entry(servicio).State = System.Data.Entity.EntityState.Modified;

                        //dbCtx.SaveChanges();

                        RepositorioServicio.UpdateServicio(servicio);
                        RepositorioServicio.Save();

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

            //Servicio servicio = dbCtx.Servicios.Find(id);

            //if(servicio == null)
            //{

            //    return HttpNotFound();

            //}

            Servicio servicio = RepositorioServicio.GetServicioById(id);

            return View(servicio);
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {

                try
                {

                    //Servicio servicio = dbCtx.Servicios.Find(id);

                    //dbCtx.Servicios.Remove(servicio);

                    //dbCtx.SaveChanges();

                    Servicio s = RepositorioServicio.GetServicioById(id);
                    RepositorioServicio.DeleteServicio(id);
                    RepositorioServicio.Save();

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
