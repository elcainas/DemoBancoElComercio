using DemoBanco.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoBanco.Business.Interface
{
    public interface IBCOrdenPago
    {
        OrdenPago Get(int id);
        OrdenPago Create(OrdenPago entity);
        OrdenPago Update(OrdenPago entity);
        void Delete(int id);
        List<OrdenPago> ListAll();
        List<OrdenPago> ListBySucursal(int sucursalId, string Moneda = null);

    }
}
