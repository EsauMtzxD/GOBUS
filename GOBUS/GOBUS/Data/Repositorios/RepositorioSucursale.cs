using GOBUS.Data.Contratos;
using GOBUS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GOBUS.Data.Repositorios
{
    public class RepositorioSucursale<T> : IRepositorioSucursale<T> where T : Sucursale, new()
    {

        private GOBUSContext dbCtx;

        public RepositorioSucursale(GOBUSContext db)
        {

            this.dbCtx = db;

        }

        public void DeleteSucursale(int Id)
        {

            Sucursale s = dbCtx.Sucursales.Find(Id);
            dbCtx.Sucursales.Remove(s);

        }

        public Sucursale GetSucursaleById(int Id)
        {
            return dbCtx.Sucursales.Find(Id);
        }

        public IEnumerable<Sucursale> GetSucursales()
        {
            return dbCtx.Sucursales.ToList();
        }

        public void InsertarSucursale(Sucursale s)
        {
            dbCtx.Sucursales.Add(s);
        }

        public void Save()
        {
            dbCtx.SaveChanges();
        }

        public void UpdateSucursale(Sucursale s)
        {
            dbCtx.Entry(s).State = System.Data.Entity.EntityState.Modified;
        }
    }
}