using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;

namespace DataProvider
{
    public class MongoDataProvider : IDataProvider
    {
        private MongoClient client = new MongoClient("mongodb://localhost:27017");
        private IMongoDatabase db;
        public MongoDataProvider()
        {
            db = client.GetDatabase("TakeOut");
        }


        public void Insert<T>(T model)
        {
            var collection = db.GetCollection<T>(model.GetType().Name);
            collection.InsertOne(model);

        }
        public Task InsertAsync<T>(T model)
        {
            var collection = db.GetCollection<T>(model.GetType().Name);
            return collection.InsertOneAsync(model);
        }


        public void InsertMany<T>(IEnumerable<T> models)
        {
            var collection = db.GetCollection<T>(typeof(T).Name);
            collection.InsertMany(models);
        }
        public void InsertManyAsync<T>(IEnumerable<T> models)
        {
            throw new NotImplementedException();
        }


        public void CreateTable(string TbName)
        {
            var collection = db.GetCollection<object>(TbName);
            if (collection == null)
            {
                db.CreateCollection(TbName);
            }
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
            return db.GetCollection<T>(typeof(T).Name).AsQueryable().ToArray();
        }

        public T GetById<T>(long id)
        {
            //var collection = db.GetCollection<T>(typeof(T).Name).Find(a=>a.Id = id)
            throw new NotImplementedException();
        }

        public void Update<T>(T model)
        {
            throw new NotImplementedException();
        }


    }
}
