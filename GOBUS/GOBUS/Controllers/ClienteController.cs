using GOBUS.Data;
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
    public class ClienteController : Controller
    {

        private GOBUSContext dbCtx = new GOBUSContext();

        private IRepositorioCliente<Cliente> ClienteRepository;

        public ClienteController()
        {
            this.ClienteRepository = new RepositorioCliente<Cliente>(new GOBUSContext());
        }

        

        public ClienteController(IRepositorioCliente<Cliente> repositorioCliente)
        {
            this.ClienteRepository = repositorioCliente;
        }

        public ActionResult Index()
        {

            //List<Cliente> cliente = new List<Cliente>();

            //cliente = dbCtx.Clientes.OrderBy(x => x.Apellidos).ToList();

            var cliente = from c in ClienteRepository.GetCliente()
                          select c;

            return View(cliente);



        }

        public ActionResult Details(int id)
        {

            //Cliente cliente = dbCtx.Clientes.Find(id);

            //if(cliente == null)
            //{

            //    return HttpNotFound();

            //}

            Cliente cliente = ClienteRepository.GetClienteByID(id);

            return View(cliente);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Cliente cliente)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    try
                    {

                        //dbCtx.Clientes.Add(cliente);

                        //dbCtx.SaveChanges();

                        ClienteRepository.InsertCliente(cliente);
                        ClienteRepository.Save();

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

            //Cliente cliente = dbCtx.Clientes.Find(id);

            //if(cliente == null)
            //{

            //    return HttpNotFound();

            //}

            Cliente c = ClienteRepository.GetClienteByID(id);

            return View(c);
        }

        [HttpPost]
        public ActionResult Edit(Cliente cliente)
        {
            try
            {

                if (ModelState.IsValid)
                {

                    try
                    {

                        //dbCtx.Entry(cliente).State = System.Data.Entity.EntityState.Modified;

                        //dbCtx.SaveChanges();

                        ClienteRepository.UpdateCliente(cliente);
                        ClienteRepository.Save();

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

            //Cliente cliente = dbCtx.Clientes.Find(id);

            //if(cliente == null)
            //{

            //    return HttpNotFound();

            //}

            Cliente c = ClienteRepository.GetClienteByID(id);

            return View(c);
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {

                try
                {

                    //Cliente cliente = dbCtx.Clientes.Find(id);

                    //dbCtx.Clientes.Remove(cliente);

                    //dbCtx.SaveChanges();

                    Cliente c = ClienteRepository.GetClienteByID(id);
                    ClienteRepository.DeleteCliente(id);
                    ClienteRepository.Save();

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
