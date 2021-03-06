﻿using GOBUS.Data.Contratos;
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
    public class CitaController : Controller
    {

        private Models.GOBUSContext dbCtx = new Models.GOBUSContext();

        private IRepositorioCitas<Cita> CitaRepositorio;

        public CitaController()
        {

            this.CitaRepositorio = new RepositorioCita<Cita>(new GOBUSContext());

        }

        public CitaController(IRepositorioCitas<Cita> repositorioCita)
        {

            this.CitaRepositorio = repositorioCita;

        }

        public ActionResult Index()
        {

            //List<Cita> citas = new List<Cita>();

            //citas = dbCtx.Citas.OrderBy(x => x.FechaCita).ToList();

            var citas = from c in CitaRepositorio.GetCita()
                        select c;

            return View(citas);
        }

      
        public ActionResult Details(int id)
        {

            //Cita cita = dbCtx.Citas.Find(id);

            //if(cita == null)
            //{

            //    return HttpNotFound();

            //}

            Cita citas = CitaRepositorio.GetCitaByID(id);

            return View(citas);
        }

        
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cita/Create
        [HttpPost]
        public ActionResult Create(Cita cita)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    try
                    {

                        //dbCtx.Citas.Add(cita);

                        //dbCtx.SaveChanges();

                        CitaRepositorio.InsertCita(cita);
                        CitaRepositorio.Save();

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

            //Cita cita = dbCtx.Citas.Find(id);

            //if(cita == null)
            //{

            //    return HttpNotFound();

            //}

            Cita cita = CitaRepositorio.GetCitaByID(id);

            return View(cita);
        }

        [HttpPost]
        public ActionResult Edit(Cita cita)
        {
            try
            {

                if (ModelState.IsValid)
                {

                    try
                    {

                        //dbCtx.Entry(cita).State = System.Data.Entity.EntityState.Modified;

                        //dbCtx.SaveChanges();

                        CitaRepositorio.UpdateCita(cita);
                        CitaRepositorio.Save();

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

            //Cita cita = dbCtx.Citas.Find(id);

            //if(cita == null)
            //{

            //    return HttpNotFound();

            //}

            Cita cita = CitaRepositorio.GetCitaByID(id);

            return View(cita);
        }

        // POST: Cita/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {

                try
                {

                    //Cita cita = dbCtx.Citas.Find(id);

                    //dbCtx.Citas.Remove(cita);

                    //dbCtx.SaveChanges();

                    Cita c = CitaRepositorio.GetCitaByID(id);
                    CitaRepositorio.DeleteCita(id);
                    CitaRepositorio.Save();

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
