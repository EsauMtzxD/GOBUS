using GOBUS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOBUS.Data.Contratos
{
    public interface IRepositorioSucursale<T>
    {

        IEnumerable<Sucursale> GetSucursales();
        Sucursale GetSucursaleById(int Id);
        void InsertarSucursale(Sucursale s);
        void DeleteSucursale(int Id);
        void UpdateSucursale(Sucursale s);
        void Save();

    }
}
