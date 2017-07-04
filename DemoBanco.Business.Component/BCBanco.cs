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
    public class BCBanco : IBCBanco
    {
        private DABanco _daBanco;
        private DABanco DABanco
        {
            get
            {
                _daBanco= _daBanco == null ? new DABanco() : _daBanco;
                return _daBanco;
            }
        }
        public Banco Create(Banco entity)
        {
            return DABanco.Create(entity);
        }

        public void Delete(int id)
        {
            DABanco.Delete(id);
        }

        public Banco Update(Banco entity)
        {
            return DABanco.Update(entity);
        }

        public Banco Get(int id)
        {
            return DABanco.Get(id);
        }

        public List<Banco> ListAll()
        {
            return DABanco.ListAll();
        }
    }
}
