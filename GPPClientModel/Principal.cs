using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPPClientModel
{
    public class Principal : BaseModel
    {
        private string _prncpl;

        public string PRNCPL
        {
            get { return _prncpl; }
            set { _prncpl = CleanString(value); }
        }

        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = CleanString(value); }
        }

        public string Display
        {
            get 
            {
                if (_prncpl == "")
                    return _name;
                else
                    return _prncpl + " - " + _name; 
            }
            set { _name = value; }
        }

    }
}
