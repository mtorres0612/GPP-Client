using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace GPPClientModel
{
    public class FileDirection : BaseModel
    {
        private string _fileDirectionCode;
        private string _fileDirectionName;


        [Required]
        [Display(Name = "File Direction Code")]
        public string FileDirectionCode
        {
            get { return _fileDirectionCode; }
            set { _fileDirectionCode = CleanString(value); }
        }

        [Display(Name = "File Direction Name")]
        public string FileDirectionName
        {
            get { return _fileDirectionName; }
            set { _fileDirectionName = CleanString(value); }
        }

    }
}
