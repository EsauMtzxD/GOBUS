using GOBUS.Data.Contratos;
using GOBUS.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace GOBUS.Data.Repositorios
{
    public class RepositorioCliente<T> : IRepositorioCliente<T> where T : Cliente, new()
    {

        private GOBUSContext context;

        public RepositorioCliente(GOBUSContext Db)
        {
            this.context = Db;
        }

        public IEnumerable<Cliente> GetCliente()
        {
            return context.Clientes.ToList();
        }

        public Cliente GetClienteByID(int id)
        {
            return context.Clientes.Find(id);
        }

        public void InsertCliente(Cliente cliente)
        {
            context.Clientes.Add(cliente);
        }

        public void DeleteCliente(int Id)
        {
            Cliente student = context.Clientes.Find(Id);
            context.Clientes.Remove(student);
        }

        public void UpdateCliente(Cliente cliente)
        {
            context.Entry(cliente).State = System.Data.Entity.EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }

 

    }
}