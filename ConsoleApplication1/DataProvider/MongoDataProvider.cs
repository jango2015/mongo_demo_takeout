using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace DataProvider
{
    public class MongoDataProvider : IDataProvider
    {
        private 
        public MongoDataProvider()
        {

        }
        public void Add<T>(T model)
        {
            throw new NotImplementedException();
        }

        public void Delete(string key)
        {
            throw new NotImplementedException();
        }

        public void Delete<T>(T model)
        {
            throw new NotImplementedException();
        }

        public T[] GetAll<T>()
        {
            throw new NotImplementedException();
        }

        public T GetById<T>(long id)
        {
            throw new NotImplementedException();
        }

        public void Update<T>(T model)
        {
            throw new NotImplementedException();
        }
    }
}
