using GOBUS.Data.Contratos;
using GOBUS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GOBUS.Data.Repositorios
{
    public class RepositorioServicio<T> : IRepositorioServicio<T> where T : Servicio, new()
    {

        private GOBUSContext dbCtx;

        public RepositorioServicio(GOBUSContext db)
        {

            this.dbCtx = db;

        }

        public void DeleteServicio(int Id)
        {
            Servicio s = dbCtx.Servicios.Find(Id);
            dbCtx.Servicios.Remove(s);
        }

        public Servicio GetServicioById(int Id)
        {
            return dbCtx.Servicios.Find(Id);
        }

        public IEnumerable<Servicio> GetServicios()
        {
            return dbCtx.Servicios.ToList();
        }

        public void InsertarServicio(Servicio s)
        {
            dbCtx.Servicios.Add(s);
        }

        public void Save()
        {
            dbCtx.SaveChanges();
        }

        public void UpdateServicio(Servicio s)
        {
            dbCtx.Entry(s).State = System.Data.Entity.EntityState.Modified;
        }
    }
}