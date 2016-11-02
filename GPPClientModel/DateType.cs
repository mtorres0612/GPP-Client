using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPPClientModel
{
    public class DateType : BaseModel
    {
        private string _dateTypeCode;

        public string DateTypeCode
        {
            get { return _dateTypeCode; }
            set { _dateTypeCode = value; }
        }

    }
}
