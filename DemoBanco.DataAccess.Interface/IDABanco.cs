using DemoBanco.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoBanco.DataAccess.Interface
{
    public interface IDABanco
    {
        Banco Get(int id);
        Banco Create(Banco entity);
        Banco Update(Banco entity);
        void Delete(int id);
        List<Banco> ListAll();
    }
}
