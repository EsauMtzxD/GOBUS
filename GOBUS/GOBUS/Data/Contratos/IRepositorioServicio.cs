using GOBUS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOBUS.Data.Contratos
{
    public interface IRepositorioServicio<T>
    {

        IEnumerable<Servicio> GetServicios();
        Servicio GetServicioById(int Id);
        void InsertarServicio(Servicio s);
        void DeleteServicio(int Id);
        void UpdateServicio(Servicio s);
        void Save();

    }
}
