using GOBUS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GOBUS.Data.Contratos
{
    public interface IRepositorioCitas<T>   
    {

        IEnumerable<Cita> GetCita();
        Cita GetCitaByID(int Id);
        void InsertCita(Cita cita);
        void DeleteCita(int Id);
        void UpdateCita(Cita cita);
        void Save();

    }
}
