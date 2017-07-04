using DemoBanco.DataAccess.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoBanco.Business.Entities;
using Newtonsoft.Json;
using System.IO;

namespace DemoBanco.DataAccess.Component
{
    public class DASucursal : IDASucursal
    {
        readonly string pathToTheFile = AppDomain.CurrentDomain.BaseDirectory + @"\Dummy\Sucursal.js";
        private DABanco _daBanco;
        private DABanco DABanco
        {
            get
            {
                _daBanco = _daBanco == null ? new DABanco() : _daBanco;
                return _daBanco;
            }
        }
        public Sucursal Create(Sucursal entity)
        {
            var listAll = ListAll();
            entity.Id = listAll.Count == 0 ? 1 : listAll.Max(x => x.Id) + 1;
            entity.FechaRegistro = DateTime.Now;
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

        public Sucursal Update(Sucursal entity)
        {
            var listAll = ListAll();
            var entityToUpdate = listAll.FirstOrDefault(x => x.Id == entity.Id);
            entity.FechaRegistro = entityToUpdate.FechaRegistro;
            listAll[listAll.IndexOf(entityToUpdate)] = entity;
            File.WriteAllText(pathToTheFile, JsonConvert.SerializeObject(listAll));
            return entity;
        }

        public Sucursal Get(int id)
        {
            var listAll = ListAll();
            return listAll.FirstOrDefault(x => x.Id == id);
        }

        public List<Sucursal> ListAll()
        {
            var json = File.ReadAllText(pathToTheFile);
            var listAll = JsonConvert.DeserializeObject<List<Sucursal>>(json);
            var bancos = DABanco.ListAll();
            listAll.ForEach(x => x.Banco = bancos.FirstOrDefault(y => y.Id == x.BancoId));
            return listAll;
        }

        public List<Sucursal> ListByBanco(int BancoId)
        {
            var listAll = ListAll();
            return listAll.Where(x => x.BancoId == BancoId).ToList();
        }
    }
}
