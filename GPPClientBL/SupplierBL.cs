using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GPPClientModel;
using GPPClientDAL;
namespace GPPClientBL
{
    public class SupplierBL : IMaintainableBL<Supplier>
    {
        static SupplierBL _instance;

        public static SupplierBL GetInstance()
        {
            if (null == _instance)
            {
                _instance = new SupplierBL();
            }
            return _instance;
        }

        SupplierDAL oSupplierDAL = SupplierDAL.GetInstance(); 

        public List<Supplier> GetAll()
        {
            List<Supplier> list      = new List<Supplier>();
            list                     = oSupplierDAL.GetAll();

            return list;
        }

        public int Insert(Supplier item)
        {
            int result               = 0;
            result                   = oSupplierDAL.Insert(item);
            return result;
        }

        public int Update(Supplier item)
        {
            int result               = 0;
            result                   = oSupplierDAL.Update(item);
            return result;
        }

        public int Delete(object id)
        {
            int result               = 0;
            result                   = oSupplierDAL.Delete(id);
            return result;
        }
    }
}
