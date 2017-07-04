using DemoBanco.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoBanco.Business.Interface
{
    public interface IBCSucursal
    {
        Sucursal Get(int id );
        Sucursal Create(Sucursal entity);
        Sucursal Update(Sucursal entity);
        void Delete(int id);
        List<Sucursal> ListAll();
        List<Sucursal> ListByBanco(int BancoId);
    }
}
