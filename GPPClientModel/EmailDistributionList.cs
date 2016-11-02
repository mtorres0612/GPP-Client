using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace GPPClientModel
{
    public class EmailDistributionList : BaseModel
    {
        private int _emldkey;
        private string _msgCode;
        private string _erp;
        private int _reportCode;
        private string _emailSubject;
        private string _emailAddrFrom;
        private string _emailAddrTo;
        private string _emailAddrCC;
        private string _emailAddrBCC;
        private string _extEmailAddrTo;
        private string _extEmailAddrCC;
        private string _xsltPath;
        private string _user;
        private DateTime? _lastEmailDate;
        private string _lastEmailShortDate;

        [Display(Name="ID")]
        public int Emldkey
        {
            get { return _emldkey; }
            set { _emldkey = value; }
        }

        [Display(Name = "Message Code")]
        [Required]
        public string MsgCode
        {
            get { return _msgCode; }
            set { _msgCode = CleanString(value); }
        }

        [Display(Name = "SDS Environment")]
        [Required]
        public string ERP
        {
            get { return _erp; }
            set { _erp = CleanString(value); }
        }

        public int ReportCode
        {
            get { return _reportCode; }
            set { _reportCode = value; }
        }

        [Display(Name = "Email Subject")]
        [Required]
        public string EmailSubject
        {
            get { return _emailSubject; }
            set { _emailSubject = CleanString(value); }
        }

        [Display(Name = "Email Address From")]
        [Required]
        public string EmailAddrFrom
        {
            get { return _emailAddrFrom; }
            set { _emailAddrFrom = CleanString(value); }
        }

        [Display(Name = "Email Address To")]
        [Required]
        public string EmailAddrTo
        {
            get { return _emailAddrTo; }
            set { _emailAddrTo = CleanString(value); }
        }

        [Display(Name = "Email Address CC")]
        [Required]
        public string EmailAddrCC
        {
            get { return _emailAddrCC; }
            set { _emailAddrCC = CleanString(value); }
        }

        [Display(Name = "Email Address BCC")]
        public string EmailAddrBCC
        {
            get { return _emailAddrBCC; }
            set { _emailAddrBCC = CleanString(value); }
        }

        [Display(Name = "External Email Address To")]
        [Required]
        public string ExtEmailAddrTo
        {
            get { return _extEmailAddrTo; }
            set { _extEmailAddrTo = CleanString(value); }
        }

        [Display(Name = "External Email Address CC")]
        public string ExtEmailAddrCC
        {
            get { return _extEmailAddrCC; }
            set { _extEmailAddrCC = CleanString(value); }
        }

        [Display(Name = "XSLT Path")]
        public string XsltPath
        {
            get { return _xsltPath; }
            set { _xsltPath = CleanString(value); }
        }

        public string User
        {
            get { return _user; }
            set { _user = CleanString(value); }
        }

        [Display(Name = "Last Email Date")]
        public DateTime? LastEmailDate
        {
            get { return _lastEmailDate; }
            set { _lastEmailDate = value; }
        }

        [Display(Name = "Last Email Date")]
        public string LastEmailShortDate
        {
            get { return _lastEmailShortDate; }
            set { _lastEmailShortDate = value; }
        }

    }
}
