using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProvider
{
    public interface ITakeOutDataProvider
    {
        void Add<TModel>(TModel model);

        void Update<TModel>(TModel model);

        void Delete<TModel>(TModel model);
    }
}
