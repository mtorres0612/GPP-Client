using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace GPPClientModel
{
    public class User : BaseModel
    {
        private int _id;
        private string _userName;
        private string _password;
        private string _email;

        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _lastName;

        [Display(Name = "Last Name")]
        [Required]
        public string LastName
        {
            get { return _lastName; }
            set { _lastName = CleanString(value); }
        }

        private string _firstName;

        [Display(Name = "First Name")]
        [Required]
        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = CleanString(value); }
        }

        private string _middleName;

        [Display(Name = "Middle Name")]
        [Required]
        public string MiddleName
        {
            get { return _middleName; }
            set { _middleName = CleanString(value); }
        }

        private string _address;

        [Display(Name = "Address")]
        [Required]
        public string Address
        {
            get { return _address; }
            set { _address = CleanString(value); }
        }

        private string _phone;

        [Display(Name = "Phone")]
        [Required]
        public string Phone
        {
            get { return _phone; }
            set { _phone = CleanString(value); }
        }

        [Display(Name = "Email")]
        [Required]
        public string Email
        {
            get { return _email; }
            set { _email = CleanString(value); }
        }

        [Display(Name="User Name")]
        [Required]
        public string UserName
        {
            get { return _userName; }
            set { _userName = CleanString(value); }
        }

        [DataType(DataType.Password)]
        [Required]
        public string Password
        {
            get { return _password; }
            set { _password = CleanString(value); }
        }

        private DateTime? _regDate;

        public DateTime? RegDate
        {
            get { return _regDate; }
            set { _regDate = value; }
        }

        private DateTime? _modifiedDate;

        public DateTime? ModifiedDate
        {
            get { return _modifiedDate; }
            set { _modifiedDate = value; }
        }


    }
}
