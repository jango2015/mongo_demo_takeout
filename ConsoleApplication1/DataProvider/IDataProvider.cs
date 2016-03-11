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
        void Add<T>(T model);
        void Update<T>(T model);
        void Delete<T>(T model);
        void Delete(string key);
    }
}
