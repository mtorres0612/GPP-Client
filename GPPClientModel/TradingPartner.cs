using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace GPPClientModel
{
    public class TradingPartner : BaseModel
    {

        private string _tradingPartnerCode;
        private string _principal;
        private string _name;
        private string _coluCode;
        private string _user;
        private string _userName;
        private string _password;
        private int? _xmlIdentityNode;
        private int _xmlEncodingType;
        private bool _indented;
        private string _erp;

        public Int64 Id { get; set; }

        [Display(Name = "Trading Partner Code")]
        [Required]
        public string TradingPartnerCode
        {
            get { return _tradingPartnerCode; }
            set { _tradingPartnerCode = value; }
        }

        [Display(Name = "ERP")]
        [Required]
        public string ERP
        {
            get { return _erp; }
            set { _erp = value; }
        }

        [Display(Name = "Principal Code")]
        [Required]
        public string Principal
        {
            get { return _principal; }
            set { _principal = CleanString(value); }
        }

        [Display(Name = "Trading Partner Name")]
        public string Name
        {
            get { return _name; }
            set { _name = CleanString(value); }
        }

        [Display(Name = "Country Code")]
        public string ColuCode
        {
            get { return _coluCode; }
            set { _coluCode = value; }
        }

        public string User
        {
            get { return _user; }
            set { _user = CleanString(value); }
        }

        [Display(Name = "User Name")]
        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }

        public string Password
        {
            get { return _password; }
            set { _password = CleanString(value); }
        }

        [Display(Name = "Xml Identity Node")]
        public int? XmlIdentityNode
        {
            get { return _xmlIdentityNode; }
            set { _xmlIdentityNode = _xmlIdentityNode.HasValue ? value : 0; }
        }

        [Display(Name = "Xml Indentation")]
        public bool Indented
        {
            get { return _indented; }
            set { _indented = value; }
        }

        [Display(Name = "Xml Encoding")]
        public int XmlEncodingType
        {
            get { return _xmlEncodingType; }
            set { _xmlEncodingType = value; }
        }

        public List<Messages> Messages { get; set; }

    }
}
