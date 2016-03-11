using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProvider
{
    public interface IDataProvider
    {
        T[] GetAll<T>();
        T GetById<T>(long id);
        void Insert<T>(T model);
        Task InsertAsync<T>(T model);
        void InsertMany<T>(IEnumerable<T> models);
        void InsertManyAsync<T>(IEnumerable<T> models);
        void Update<T>(T model);
        void Delete<T>(T model);
        void Delete(string key);

        void CreateTable(string TbName);
    }
}
