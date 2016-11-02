using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace GPPClientModel
{
    public class Messages : BaseModel
    {
        private string _msgCode;
        private string _tradingPartnerCode;
        private string _coluCode;
        private bool _isDebug;
        private bool _isUseTemporaryExtension;
        private int? _counter;
        private string _name;
        private string _temporaryFileExtension;
        private string _fileType;
        private int? _startReadWrite;
        private string _delLinePattern;
        private int? _codePageId;
        private string _fileNameConvention;
        private string _fileNameExtension;
        private string _fileNameDateFormat;
        private string _excelTemplatePath;
        private int? _excelRowOffset;
        private int? _excelXMLTableNo;
        private string _fileDirectionCode;
        private string _user;
        private int? _result;
        private string _applicationType;
        private bool _mondayFlag;
        private bool _tuesdayFlag;
        private bool _wednesdayFlag;
        private bool _thursdayFlag;
        private bool _fridayFlag;
        private bool _saturdayFlag;
        private bool _sundayFlag;
        private bool _manualRunFlag;
        private DateTime? _startRuntime;
        private DateTime? _endRuntime;

        [Display(Name="Message Code")]
        [Required]
        public string MsgCode
        {
            get { return _msgCode; }
            set { _msgCode = CleanString(value); }
        }

        [Display(Name = "Trading Partner")]
        public string TradingPartnercode
        {
            get { return _tradingPartnerCode; }
            set { _tradingPartnerCode = CleanString(value); }
        }

        [Display(Name = "Country")]
        public string ColuCode
        {
            get { return _coluCode; }
            set { _coluCode = CleanString(value); }
        }

        [Display(Name = "Is Debug")]
        public bool IsDebug
        {
            get { return _isDebug; }
            set { _isDebug = value; }
        }

        [Display(Name = "Enable")]
        public bool IsUseTemporaryExtension
        {
            get { return _isUseTemporaryExtension; }
            set { _isUseTemporaryExtension = value; }
        }

        [Display(Name = "Counter")]
        public int? Counter
        {
            get { return _counter; }
            set { _counter = value.HasValue ? value : 0; }
        }

        [Display(Name = "Message Name")]
        public string Name
        {
            get { return _name; }
            set { _name = CleanString(value); }
        }

        [Display(Name = "Temporary Extension")]
        public string TemporaryFileExtension
        {
            get { return _temporaryFileExtension; }
            set { _temporaryFileExtension = CleanString(value); }
        }

        [Display(Name = "File Type")]
        [Required]
        public string FileType
        {
            get { return _fileType; }
            set { _fileType = CleanString(value); }
        }

        [Display(Name = "Start Read Write")]
        public int? StartReadWrite
        {
            get { return _startReadWrite; }
            set { _startReadWrite = value.HasValue ? value : 0; }
        }

        [Display(Name = "Delete Line Pattern")]
        public string DelLinePattern
        {
            get { return _delLinePattern; }
            set { _delLinePattern = CleanString(value); }
        }

        [Display(Name = "Code Page")]
        public int? CodePageId
        {
            get { return _codePageId; }
            set { _codePageId = value.HasValue ? value : 0; }
        }

        [Display(Name = "FileName Convention")]
        public string FileNameConvention
        {
            get { return _fileNameConvention; }
            set { _fileNameConvention = CleanString(value); }
        }

        [Display(Name = "FileName Extension")]
        public string FileNameExtension
        {
            get { return _fileNameExtension; }
            set { _fileNameExtension = CleanString(value); }
        }

        [Display(Name = "FileName Date Format")]
        public string FileNameDateFormat
        {
            get { return _fileNameDateFormat; }
            set { _fileNameDateFormat = CleanString(value); }
        }
        
        [Display(Name = "Excel Template Path")]
        public string ExcelTemplatePath
        {
            get { return _excelTemplatePath; }
            set { _excelTemplatePath = CleanString(value); }
        }

        [Display(Name = "Excel Row Offset")]
        public int? ExcelRowOffset
        {
            get { return _excelRowOffset; }
            set { _excelRowOffset = value.HasValue ? value : 0; }
        }

        [Display(Name = "Excel XML Table No")]
        public int? ExcelXMLTableNo
        {
            get { return _excelXMLTableNo; }
            set { _excelXMLTableNo = value.HasValue ? value : 0; }
        }

        [Display(Name = "File Direction")]
        [Required]
        public string FileDirectionCode
        {
            get { return _fileDirectionCode; }
            set { _fileDirectionCode = CleanString(value); }
        }

        public string User
        {
            get { return _user; }
            set { _user = CleanString(value); }
        }

        public int? Result
        {
            get { return _result; }
            set { _result = value.HasValue ? value : 0; }
        }

        [Display(Name = "XML Identity Node")]
        public int? XmlNode
        {
            get { return _result; }
            set { _result = value.HasValue ? value : 0; ; }
        }

        [Display(Name = "Application Type")]
        [Required]
        public string ApplicationType
        {
            get { return _applicationType; }
            set { _applicationType = CleanString(value); }
        }

        [Display(Name = "Monday")]
        public bool MondayFlag
        {
            get { return _mondayFlag; }
            set { _mondayFlag = value; }
        }

        [Display(Name = "Tuesday")]
        public bool TuesdayFlag
        {
            get { return _tuesdayFlag; }
            set { _tuesdayFlag = value; }
        }

        [Display(Name = "Wednesday")]
        public bool WednesdayFlag
        {
            get { return _wednesdayFlag; }
            set { _wednesdayFlag = value; }
        }

        [Display(Name = "Thursday")]
        public bool ThursdayFlag
        {
            get { return _thursdayFlag; }
            set { _thursdayFlag = value; }
        }

        [Display(Name = "Friday")]
        public bool FridayFlag
        {
            get { return _fridayFlag; }
            set { _fridayFlag = value; }
        }

        [Display(Name = "Saturday")]
        public bool SaturdayFlag
        {
            get { return _saturdayFlag; }
            set { _saturdayFlag = value; }
        }

        [Display(Name = "Sunday")]
        public bool SundayFlag
        {
            get { return _sundayFlag; }
            set { _sundayFlag = value; }
        }

        [Display(Name = "Run Time")]
        public bool ManualRunFlag
        {
            get { return _manualRunFlag; }
            set { _manualRunFlag = value; }
        }

        [Display(Name = "Start Time")]
        public DateTime? StartRuntime
        {
            get { return _startRuntime; }
            set { _startRuntime = value.HasValue ? value : Convert.ToDateTime("1/1/2008"); }
        }

        [Display(Name = "End Time")]
        public DateTime? EndRuntime
        {
            get { return _endRuntime; }
            set { _endRuntime = value.HasValue ? value : Convert.ToDateTime("1/1/2008"); }
        }

    }
}
