using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace GPPClientModel
{
    public class TransmissionType : BaseModel
    {
        private int _transmissionTypeId;
        private string _transmissionTypeCode;
        private string _transmissionTypeDescription;

        public int TransmissionTypeID
        {
            get { return _transmissionTypeId; }
            set { _transmissionTypeId = value; }
        }

        [Display(Name = "Transmission Type Code")]
        [Required]
        public string TransmissionTypeCode
        {
            get { return _transmissionTypeCode; }
            set { _transmissionTypeCode = CleanString(value); }
        }

        [Display(Name = "Description")]
        [Required]
        public string TransmissionTypeDescription
        {
            get { return _transmissionTypeDescription; }
            set { _transmissionTypeDescription = CleanString(value); }
        }

    }
}
