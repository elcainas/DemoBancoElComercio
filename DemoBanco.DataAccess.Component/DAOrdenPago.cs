using DemoBanco.DataAccess.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoBanco.Business.Entities;
using System.IO;
using Newtonsoft.Json;

namespace DemoBanco.DataAccess.Component
{
    public class DAOrdenPago : IDAOrdenPago
    {
        private DASucursal _daSucursal;
        private DASucursal DASucursal
        {
            get
            {
                _daSucursal = _daSucursal == null ? new DASucursal() : _daSucursal;
                return _daSucursal;
            }
        }
        readonly string pathToTheFile = AppDomain.CurrentDomain.BaseDirectory + @"\Dummy\OrdenPago.js";
        public OrdenPago Create(OrdenPago entity)
        {
            var listAll = ListAll();
            entity.Id = listAll.Count == 0 ? 1 : listAll.Max(x => x.Id) + 1;
            listAll.Add(entity);
            File.WriteAllText(pathToTheFile, JsonConvert.SerializeObject(listAll));
            return entity;
        }

        public void Delete(int id)
        {
            var listAll = ListAll();
            var entityToRemove = listAll.FirstOrDefault(x => x.Id == id);
            if (entityToRemove == null)
                return;
            listAll.Remove(entityToRemove);
            File.WriteAllText(pathToTheFile, JsonConvert.SerializeObject(listAll));
        }

        public OrdenPago Update(OrdenPago entity)
        {
            var listAll = ListAll();
            var entityToUpdate = listAll.FirstOrDefault(x => x.Id == entity.Id);
            listAll[listAll.IndexOf(entityToUpdate)] = entity;
            File.WriteAllText(pathToTheFile, JsonConvert.SerializeObject(listAll));
            return entity;
        }

        public OrdenPago Get(int id)
        {
            var listAll = ListAll();
            return listAll.FirstOrDefault(x => x.Id == id);
        }

        public List<OrdenPago> ListAll()
        {
            var json = File.ReadAllText(pathToTheFile);
            var listAll = JsonConvert.DeserializeObject<List<OrdenPago>>(json);
            var sucursales = DASucursal.ListAll();
            listAll.ForEach(x => x.Sucursal = sucursales.FirstOrDefault(y => y.Id == x.SucursalId));
            return listAll;
        }

        public List<OrdenPago> ListBySucursal(int sucursalId, string moneda = null)
        {
            var listAll = ListAll();
            var list = listAll.Where(x => x.Id == sucursalId);
            if (moneda != null)
                list.Where(y => y.Moneda == moneda);

            return list.ToList();
        }
    }
}
