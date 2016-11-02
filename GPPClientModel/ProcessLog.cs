using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPPClientModel
{
    public class ProcessLog : BaseModel
    {
        private string _msgCode;
        private string _processSource;
        private string _techErrDesc;
        private string _description;
        private int _id;
        private DateTime? _startDate;
        private DateTime? _endDate;
        private string _status;
        private string _applicationCode;
        private string _erp;

        public string MsgCode
        {
            get { return _msgCode; }
            set { _msgCode = CleanString(value); }
        }

        public string ProcessSource
        {
            get { return _processSource; }
            set { _processSource = CleanString(value); }
        }

        public string TechErrDesc
        {
            get { return _techErrDesc; }
            set { _techErrDesc = CleanString(value); }
        }

        public string Description
        {
            get { return _description; }
            set { _description = CleanString(value); }
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public DateTime? StartDate
        {
            get { return _startDate; }
            set { _startDate = value; }
        }

        public DateTime? EndDate
        {
            get { return _endDate; }
            set { _endDate = value; }
        }
    }
}
