using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace GPPClientModel
{
    public class ApplicationCode : BaseModel
    {
        private string _name;
        private string _code;

        public string Name
        {
            get { return _name; }
            set { _name = CleanString(value); }
        }

        public string Code
        {
            get { return _code; }
            set { _code = CleanString(value); }
        }


    }
}
