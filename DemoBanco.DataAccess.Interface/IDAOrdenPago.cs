using DemoBanco.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoBanco.DataAccess.Interface
{
    public interface IDAOrdenPago
    {
        OrdenPago Get(int id);
        OrdenPago Create(OrdenPago entity);
        OrdenPago Update(OrdenPago entity);
        void Delete(int id);
        List<OrdenPago> ListAll();
        List<OrdenPago> ListBySucursal(int sucursalId, string moneda = null);

    }
}
