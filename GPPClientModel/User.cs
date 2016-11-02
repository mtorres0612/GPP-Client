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

        [Required]
        [Display(Name="User Name")]
        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }

        [Required]
        [DataType(DataType.Password)]
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

    }
}
