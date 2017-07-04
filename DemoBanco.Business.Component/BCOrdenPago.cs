using DemoBanco.Business.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoBanco.Business.Entities;
using DemoBanco.DataAccess.Component;

namespace DemoBanco.Business.Component
{
    public class BCOrdenPago : IBCOrdenPago
    {
        private DAOrdenPago _daOrdenPago;
        private DAOrdenPago DAOrdenPago
        {
            get
            {
                _daOrdenPago = _daOrdenPago == null ? new DAOrdenPago() : _daOrdenPago;
                return _daOrdenPago;
            }
        }
        public OrdenPago Create(OrdenPago entity)
        {
            return DAOrdenPago.Create(entity);
        }

        public void Delete(int id)
        {
            DAOrdenPago.Delete(id);
        }

        public OrdenPago Update(OrdenPago entity)
        {
            return DAOrdenPago.Update(entity);
        }

        public OrdenPago Get(int id)
        {
            return DAOrdenPago.Get(id);
        }

        public List<OrdenPago> ListAll()
        {
            return DAOrdenPago.ListAll();
        }

        public List<OrdenPago> ListBySucursal(int sucursalId, string moneda = null)
        {
            return DAOrdenPago.ListBySucursal(sucursalId, moneda);
        }
    }
}
