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
    public class BCSucursal : IBCSucursal
    {
        private DASucursal _daSucursal;
        private DASucursal DASucursal
        {
            get
            {
                _daSucursal= _daSucursal == null ? new DASucursal() : _daSucursal;
                return _daSucursal;
            }
        }
        public Sucursal Create(Sucursal entity)
        {
            return DASucursal.Create(entity);
        }

        public void Delete(int id)
        {
            DASucursal.Delete(id);
        }

        public Sucursal Update(Sucursal entity)
        {
            return DASucursal.Update(entity);
        }

        public Sucursal Get(int id)
        {
            return DASucursal.Get(id);
        }

        public List<Sucursal> ListAll()
        {
            return DASucursal.ListAll();
        }

        public List<Sucursal> ListByBanco(int BancoId)
        {
            return DASucursal.ListByBanco(BancoId);
        }
    }
}
