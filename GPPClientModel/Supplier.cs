using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace GPPClientModel
{
    public class Supplier : BaseModel
    {
        private string _suppId;
        private string _name;
        private string _addr1;
        private string _addr2;
        private string _city;
        private string _state;
        private string _postCode;
        private string _countryLu;
        private string _email;
        private string _fax;
        private string _phone;
        private string _homePageUrl;
        private string _erpType;
        private string _user;

        [Display(Name = "Supplier ID")]
        [Required]
        public string SuppID
        {
            get { return _suppId; }
            set { _suppId = CleanString(value); }
        }

        [Display(Name = "Supplier Name")]
        public string Name
        {
            get { return _name; }
            set { _name = CleanString(value); }
        }

        [Display(Name = "Address 1")]
        public string Addr1
        {
            get { return _addr1; }
            set { _addr1 = CleanString(value); }
        }

        [Display(Name = "Address 2")]
        public string Addr2
        {
            get { return _addr2; }
            set { _addr2 = CleanString(value); }
        }

        public string City
        {
            get { return _city; }
            set { _city = CleanString(value); }
        }

        public string State
        {
            get { return _state; }
            set { _state = CleanString(value); }
        }

        [Display(Name = "Postal Code")]
        public string PostCode
        {
            get { return _postCode; }
            set { _postCode = CleanString(value); }
        }

        [Display(Name = "Country Code")]
        public string CountryLU
        {
            get { return _countryLu; }
            set { _countryLu = CleanString(value); }
        }

        public string Email
        {
            get { return _email; }
            set { _email = CleanString(value); }
        }

        public string Fax
        {
            get { return _fax; }
            set { _fax = CleanString(value); }
        }


        public string Phone
        {
            get { return _phone; }
            set { _phone = CleanString(value); }
        }

        [Display(Name = "Homepage URL")]
        public string HomePageURL
        {
            get { return _homePageUrl; }
            set { _homePageUrl = CleanString(value); }
        }


        [Display(Name = "ERP Type")]
        public string ERPType
        {
            get { return _erpType; }
            set { _erpType = CleanString(value); }
        }

        public string User
        {
            get { return _user; }
            set { _user = CleanString(value); }
        }

    }
}
