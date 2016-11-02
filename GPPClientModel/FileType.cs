using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace GPPClientModel
{
    public class FileType : BaseModel
    {
        private string _fileTypeCode;
        private string _fileTypeName;

        [Display(Name = "File Type Code")]
        [Required]
        public string FileTypeCode
        {
            get { return _fileTypeCode; }
            set { _fileTypeCode = CleanString(value); }
        }

        [Display(Name = "File Type Name")]
        public string FileTypeName
        {
            get { return _fileTypeName; }
            set { _fileTypeName = CleanString(value); }
        }

    }
}
