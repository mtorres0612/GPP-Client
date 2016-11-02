using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPPClientModel
{
    public class MessageSettings : BaseModel, IValidatableObject
    {
        private bool _sendSuccessNotification;

        [Display(Name="Send Success Notification")]
        public bool SendSuccessNotification
        {
            get { return _sendSuccessNotification; }
            set { _sendSuccessNotification = value; }
        }

        private string _sourceFileMask;

        [Display(Name = "File Mask")]
        [Required]
        public string SourceFileMask
        {
            get { return _sourceFileMask; }
            set { _sourceFileMask = value; }
        }

        private int _messageFileSourceId;

        public int MessageFileSourceId
        {
            get { return _messageFileSourceId; }
            set { _messageFileSourceId = value; }
        }

        private int _messageFileDestinationId;

        public int MessageFileDestinationId
        {
            get { return _messageFileDestinationId; }
            set { _messageFileDestinationId = value; }
        }

        private FileTransferSetting _messageFileSource;

        public FileTransferSetting MessageFileSource
        {
            get { return _messageFileSource; }
            set { _messageFileSource = value; }
        }

        private FileTransferSetting _messageFileDestination;

        public FileTransferSetting MessageFileDestination
        {
            get { return _messageFileDestination; }
            set { _messageFileDestination = value; }
        }

        private int _msetID;

        public int MsetID
        {
            get { return _msetID; }
            set { _msetID = value; }
        }

        private string _msgCode;

        [Display(Name = "Message Code")]
        public string MsgCode
        {
            get { return _msgCode; }
            set { _msgCode = value; }
        }

        private string _erp;

        [Display(Name = "SDS Environment")]
        public string ERP
        {
            get { return _erp; }
            set { _erp = value; }
        }

        private string _prncpl;

        [Display(Name = "Principal")]
        public string PRNCPL
        {
            get { return _prncpl; }
            set { _prncpl = value; }
        }

        private string _fileType;

        public string FileType
        {
            get { return _fileType; }
            set { _fileType = value; }
        }

        private string _ftpServerIP;

        [Display(Name = "FTP Server IP")]
        public string FtpServerIP
        {
            get { return _ftpServerIP; }
            set { _ftpServerIP = CleanString(value); }
        }

        private string _ftpPort;

        [Display(Name = "FTP Server Port")]
        public string FtpPort
        {
            get { return _ftpPort; }
            set { _ftpPort = CleanString(value); }
        }

        private string _ftpFolder;

        [Display(Name = "FTP Folder")]
        public string FtpFolder
        {
            get { return _ftpFolder; }
            set { _ftpFolder = CleanString(value); }
        }

        private string _ftpUserName;

        [Display(Name = "FTP Username")]
        public string FtpUserName
        {
            get { return _ftpUserName; }
            set { _ftpUserName = CleanString(value); }
        }

        private string _ftpPassword;

        [Display(Name = "FTP Password")]
        public string FtpPassword
        {
            get { return _ftpPassword; }
            set { _ftpPassword = CleanString(value); }
        }

        private string _ftpBeforePutCmd;

        [Display(Name = "FTP Before Put Cmd")]
        public string FtpBeforePutCmd
        {
            get { return _ftpBeforePutCmd; }
            set { _ftpBeforePutCmd = CleanString(value); }
        }

        private string _backUpFolder;

        [Display(Name = "Backup Folder")]
        public string BackUpFolder
        {
            get { return _backUpFolder; }
            set { _backUpFolder = value; }
        }

        private string _backUpFolderOut;

        [Display(Name = "Backup Folder Out")]
        public string BackUpFolderOut
        {
            get { return _backUpFolderOut; }
            set { _backUpFolderOut = CleanString(value); }
        }

        private string _noMappingFolder;

        [Display(Name = "No Mapping Folder")]
        public string NoMappingFolder
        {
            get { return _noMappingFolder; }
            set { _noMappingFolder = CleanString(value); }
        }

        private string _noFTPSettingsFolder;

        [Display(Name = "No FTP Setting Folder")]
        public string NoFTPSettingsFolder
        {
            get { return _noFTPSettingsFolder; }
            set { _noFTPSettingsFolder = CleanString(value); }
        }

        private string _notValidFolder;

        [Display(Name = "Not Valid Folder")]
        public string NotValidFolder
        {
            get { return _notValidFolder; }
            set { _notValidFolder = CleanString(value); }
        }

        private string _user;

        public string User
        {
            get { return _user; }
            set { _user = CleanString(value); }
        }

        private string _fiteMask;

        [Display(Name = "File Terminator Mask")]
        public string FITEMask
        {
            get { return _fiteMask; }
            set { _fiteMask = value; }
        }

        private bool _isZip;

        [Display(Name = "Zip Facility")]
        public bool IsZip
        {
            get { return _isZip; }
            set { _isZip = value; }
        }

        private string _zipPassword;

        [Display(Name = "Password")]
        public string ZipPassword
        {
            get { return _zipPassword; }
            set { _zipPassword = CleanString(value); }
        }

        private int _retention;

        [Display(Name = "Retention (mos)")]
        public int Retention
        {
            get { return _retention; }
            set { _retention = value; }
        }

        private int _msetMaxThreadCount;

        [Display(Name = "Max Thread Count")]
        public int MsetMaxThreadCount
        {
            get { return _msetMaxThreadCount; }
            set { _msetMaxThreadCount = value; }
        }

        private bool iIsZipSource;

        [Display(Name = "Zip Source")]
        public bool IsZipSource
        {
            get { return iIsZipSource; }
            set { iIsZipSource = value; }
        }

        private bool _filesSentStatusSingle;

        [Display(Name = "Single")]
        public bool FilesSentStatusSingle
        {
            get { return _filesSentStatusSingle; }
            set { _filesSentStatusSingle = value; }
        }

        private bool _filesSentStatusBatch;

        [Display(Name = "Batch")]
        public bool FilesSentStatusBatch
        {
            get { return _filesSentStatusBatch; }
            set { _filesSentStatusBatch = value; }
        }

        private bool _fileConvertionFlag;

        [Display(Name = "File Conversion")]
        public bool FileConvertionFlag
        {
            get { return _fileConvertionFlag; }
            set { _fileConvertionFlag = value; }
        }

        private int _sourceCodePage;

        [Display(Name = "Source")]
        public int SourceCodePage
        {
            get { return _sourceCodePage; }
            set { _sourceCodePage = value; }
        }

        private int _destinationCodePage;

        [Display(Name = "Destination")]
        public int DestinationCodePage
        {
            get { return _destinationCodePage; }
            set { _destinationCodePage = value; }
        }

        private int _msetFilePickupDelay;

        [Display(Name = "Delay")]
        public int MsetFilePickupDelay
        {
            get { return _msetFilePickupDelay; }
            set { _msetFilePickupDelay = value; }
        }

        private bool _msetBatchRun;

        [Display(Name = "Batch")]
        public bool MsetBatchRun
        {
            get { return _msetBatchRun; }
            set { _msetBatchRun = value; }
        }

        private DateTime _msetBatchTime;

        [Display(Name = "Begin")]
        public DateTime MsetBatchTime
        {
            get { return _msetBatchTime; }
            set { _msetBatchTime = value; }
        }

        private string _msetBatchTimeString;

        public string MsetBatchTimeString
        {
            get { return _msetBatchTimeString; }
            set { _msetBatchTimeString = value; }
        }


        private bool _msetRunTime;

        [Display(Name = "Run Time")]
        public bool MsetRunTime
        {
            get { return _msetRunTime; }
            set { _msetRunTime = value; }
        }

        private DateTime _msetStartTime;

        [Display(Name = "Start Time")]
        public DateTime MsetStartTime
        {
            get { return _msetStartTime; }
            set { _msetStartTime = value; }
        }

        private string _msetStartTimeString;

        public string MsetStartTimeString
        {
            get { return _msetStartTimeString; }
            set { _msetStartTimeString = value; }
        }

        private DateTime _msetEndTime;

        [Display(Name = "End Time")]
        public DateTime MsetEndTime
        {
            get { return _msetEndTime; }
            set { _msetEndTime = value; }
        }

        private string _msetEndTimeString;

        public string MsetEndTimeString
        {
            get { return _msetEndTimeString; }
            set { _msetEndTimeString = value; }
        }

        private int _msetInterval;

        [Display(Name = "Interval")]
        public int MsetInterval
        {
            get { return _msetInterval; }
            set { _msetInterval = value; }
        }

        private string _sourceUserName;

        public string SourceUserName
        {
            get { return _sourceUserName; }
            set { _sourceUserName = value; }
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (MessageFileSource.TransmissionTypeID == 1)
            {
                if (string.IsNullOrEmpty(SourceUserName))
                {
                    yield return new ValidationResult("Username is required in FTP!");
                }
            }
        }
    }
}
