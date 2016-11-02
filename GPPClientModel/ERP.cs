using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace GPPClientModel
{
    public class ERP : BaseModel
    {
        private string _erp;
        private string _suppId;
        private string _erpCountryLU;
        private string _user;

        [Display(Name="SDS Environment")]
        [Required]
        public string Erp
        {
            get { return _erp; }
            set { _erp = CleanString(value); }
        }

        [Display(Name = "Supplier")]
        public string SuppID
        {
            get { return _suppId; }
            set { _suppId = value; }
        }

        [Display(Name = "Country Code")]
        public string ErpCountryLU
        {
            get { return _erpCountryLU; }
            set { _erpCountryLU = value; }
        }

        public string User
        {
            get { return _user; }
            set { _user = CleanString(value); }
        }

    }
}
