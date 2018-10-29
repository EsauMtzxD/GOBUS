using GOBUS.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GOBUS.Data.Contratos
{
    public interface IRepositorioCliente<T>
    {

        IEnumerable<Cliente> GetCliente();
        Cliente GetClienteByID(int Id);
        void InsertCliente(Cliente cliente);
        void DeleteCliente(int Id);
        void UpdateCliente(Cliente cliente);
        void Save();

    }
}
