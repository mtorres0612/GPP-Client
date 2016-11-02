using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPPClientBL
{
    public interface IMaintainableBL<T>
    {
        List<T> GetAll();
        int Insert(T item);
        int Update(T item);
        int Delete(object id);
    }
}
