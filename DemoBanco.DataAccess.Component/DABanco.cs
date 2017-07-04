using DemoBanco.DataAccess.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoBanco.Business.Entities;
using System.IO;
using Newtonsoft.Json;
using System.Reflection;

namespace DemoBanco.DataAccess.Component
{
    public class DABanco : IDABanco
    {
        readonly string pathToTheFile = AppDomain.CurrentDomain.BaseDirectory + @"\Dummy\Banco.js";
        public DABanco()
        {

        }
        public Banco Create(Banco entity)
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

        public Banco Update(Banco entity)
        {
            var listAll = ListAll();
            var entityToUpdate = listAll.FirstOrDefault(x => x.Id == entity.Id);
            entity.FechaRegistro = entityToUpdate.FechaRegistro;
            listAll[listAll.IndexOf(entityToUpdate)] = entity;
            File.WriteAllText(pathToTheFile, JsonConvert.SerializeObject(listAll));
            return entity;
        }

        public Banco Get(int id)
        {
            var listAll = ListAll();
            return listAll.FirstOrDefault(x => x.Id == id);
        }

        public List<Banco> ListAll()
        {
            var json = File.ReadAllText(pathToTheFile);
            var listAll = JsonConvert.DeserializeObject<List<Banco>>(json);
            return listAll;
        }
    }
}
