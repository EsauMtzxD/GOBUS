using GOBUS.Data.Contratos;
using GOBUS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GOBUS.Data.Repositorios
{
    public class RepositorioCita<T> : IRepositorioCitas<T> where T : Cita, new()
    {

        private GOBUSContext context;

        public RepositorioCita(GOBUSContext Db)
        {
            this.context = Db;
        }

        public void DeleteCita(int Id)
        {

            Cita cita = context.Citas.Find(Id);

            context.Citas.Remove(cita);

        }

        public IEnumerable<Cita> GetCita()
        {
            return context.Citas.ToList();
        }

        public Cita GetCitaByID(int Id)
        {
            return context.Citas.Find(Id);
        }

        public void InsertCita(Cita cita)
        {
            context.Citas.Add(cita);
        }

        public void UpdateCita(Cita cita)
        {
            context.Entry(cita).State = System.Data.Entity.EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }

    }
}