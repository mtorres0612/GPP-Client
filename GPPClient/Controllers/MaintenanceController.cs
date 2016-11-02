﻿using GPPClientBL;
using GPPClientModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using GPPUtilities;
using System.Text;
using System.Globalization;
using GPPClient.Utilities;

namespace GPPClient.Controllers
{
    public class MaintenanceController : Controller
    {
        #region [TradingPartner Modules]
        TradingPartnerBL oTradingPartnerBL = TradingPartnerBL.GetInstance();

        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            List<TradingPartner> list = new List<TradingPartner>();
            list = oTradingPartnerBL.GetAll().OrderBy(x => x.TradingPartnerCode).ToList();
            return View(list.ToPagedList(page, pageSize));
        }

        public ActionResult TradingPartnerDetails(int id)
        {
            TradingPartner item = oTradingPartnerBL.GetAll().Where(x => x.Id == id).FirstOrDefault();

            if (item == null)
            {
                return HttpNotFound();
            }

            return View(item);
        }

        public ActionResult CreateTradingPartner()
        {
            PopulateLOV();
            return View();
        }

        [HttpPost]
        public ActionResult CreateTradingPartner(TradingPartner item)
        {
            int result = 0;
            if (ModelState.IsValid)
            {
                if (IsUserNameExist(item.UserName, "CREATE", item.TradingPartnerCode))
                {
                    PopulateLOV();
                    ModelState.AddModelError("UserName", "UserName already exist, Please choose another Username.");
                    return View();
                }
                else if (!Utility.CheckForStrongPassword(item.Password))
                {
                    if (!string.IsNullOrEmpty(item.UserName))
                    {
                        StringBuilder _sb = new StringBuilder();
                        _sb.Append("Password does not match the correct format.<br />");
                        _sb.Append("Passwords will contain at least (1) upper case letter.<br />");
                        _sb.Append("Passwords will contain at least (1) lower case letter.<br />");
                        _sb.Append("Passwords will contain at least (1) number or special character.<br />");
                        _sb.Append("Passwords will contain at least (8) characters in length.<br />");
                        _sb.Append("Password maximum length should not be arbitrarily limited.<br />");

                        PopulateLOV();
                        ModelState.AddModelError("Password", _sb.ToString());
                        return View();
                    }
                }
                else
                {
                    item.Password = Utility.Encrypt(item.Password);
                    result = oTradingPartnerBL.Insert(item);
                }
            }
            else
            {
                PopulateLOV();
                return View();
            }

            if (result == -1)
            {
                return HttpNotFound();
            }

            return RedirectToAction("Index");
        }

        public ActionResult EditTradingPartner(long id)
        {
            TradingPartner item = oTradingPartnerBL.GetAll().Where(x => x.Id == id).FirstOrDefault();

            if (item == null)
            {
                return HttpNotFound();
            }

            item.Password = Utility.Decrypt(item.Password);

            PopulateLOV();
            return View(item);
        }

        [HttpPost]
        public ActionResult EditTradingPartner(TradingPartner item)
        {
            int result = 0;
            if (ModelState.IsValid)
            {
                if (IsUserNameExist(item.UserName, "EDIT", item.TradingPartnerCode))
                {
                    PopulateLOV();
                    ModelState.AddModelError("UserName", "UserName is already in use.");
                    return View(item);
                }
                else if (!Utility.CheckForStrongPassword(item.Password))
                {
                    if (!string.IsNullOrEmpty(item.UserName))
                    {
                        StringBuilder _sb = new StringBuilder();
                        _sb.Append("Password does not match the correct format.<br />");
                        _sb.Append("Passwords will contain at least (1) upper case letter.<br />");
                        _sb.Append("Passwords will contain at least (1) lower case letter.<br />");
                        _sb.Append("Passwords will contain at least (1) number or special character.<br />");
                        _sb.Append("Passwords will contain at least (8) characters in length.<br />");
                        _sb.Append("Password maximum length should not be arbitrarily limited.<br />");

                        PopulateLOV();
                        ModelState.AddModelError("Password", _sb.ToString());
                        return View(item);
                    }
                }
                else
                {
                    item.Password = Utility.Encrypt(item.Password);
                    result = oTradingPartnerBL.Update(item);
                }
            }
            else
            {
                PopulateLOV();
                return View(item);
            }

            if (result == -1)
            {
                return HttpNotFound();
            }

            return RedirectToAction("Index");
        }

        public ActionResult DeleteTradingPartner(long id)
        {
            TradingPartner item = oTradingPartnerBL.GetAll().Where(x => x.Id == id).FirstOrDefault();

            if (item == null)
            {
                return HttpNotFound();
            }

            return View(item);
        }

        [HttpPost]
        [ActionName("DeleteTradingPartner")]
        public ActionResult DeleteConfirmedTradingPartner(long id)
        {
            int result = 0;
            if (ModelState.IsValid)
            {
                result = oTradingPartnerBL.Delete(id);
            }
            if (result != 1)
            {
                return HttpNotFound();

            }
            return RedirectToAction("Index");
        }

        private void PopulateLOV()
        {
            IEnumerable<SelectListItem> countryList = new List<SelectListItem>();
            CountryBL oCountryBL                    = CountryBL.GetInstance();
            countryList                             = oCountryBL.GetAll().OrderBy(x => x.Name).Select(x => new SelectListItem { Text = x.Name, Value = x.Code });
            ViewBag.countryList                     = countryList;
        }

        private bool IsUserNameExist(string userName, string method, string tradingPartnerCode)
        {
            if (method == "CREATE")
            {
                List<TradingPartner> list = new List<TradingPartner>();
                list = oTradingPartnerBL.GetAll().Where(x => x.UserName.Equals(userName, StringComparison.CurrentCultureIgnoreCase)).ToList();
                if (list.Count > 0)
                {
                    return true;
                }
            }
            else if (method == "EDIT")
            {
                List<TradingPartner> list = new List<TradingPartner>();
                list = oTradingPartnerBL.GetAll().Where(x => x.UserName.Equals(userName, StringComparison.CurrentCultureIgnoreCase)).ToList();
                if (list.Count > 0)
                {
                    if (list[0].TradingPartnerCode != tradingPartnerCode)
                    {
                        if (!string.IsNullOrEmpty(list[0].TradingPartnerCode))
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }
        #endregion

        #region [Message Modules]

        MessagesBL oMessagesBL                       = new MessagesBL();
        MessageSettingsBL oMessageSettingsBL         = new MessageSettingsBL();
        FileTransferSettingBL oFileTransferSettingBL = new FileTransferSettingBL();

        public ActionResult GetMessagesPerTradingPartner(string trdpCode, string coluCode, int page = 1, int pageSize = 10)
        {
            List<Messages> list    = new List<Messages>();
            list                   = oMessagesBL.GetAllMessages(trdpCode).OrderBy(x => x.MsgCode).ToList();
            ViewBag.trdpCode       = trdpCode;
            ViewBag.coluCode       = coluCode;
            return PartialView("_Messages", list.ToPagedList(page, pageSize));
        }

        public ActionResult MessageDetails(string trdpCode, string msgCode)
        {
            Messages item = oMessagesBL.GetAllMessages(trdpCode, msgCode).FirstOrDefault();
 
            if (item == null)
            {
                return HttpNotFound();
            }

            return View(item);
        }

        public ActionResult CreateMessage(string trdpCode, string coluCode)
        {
            Messages model           = new Messages();
            model.TradingPartnercode = trdpCode;
            model.ColuCode           = coluCode;
            model.Counter            = 00001;
            PopulateMessageLOV();
            return View(model);
        }

        [HttpPost]
        public ActionResult CreateMessage(Messages item)
        {
            int result = 0;
            if (ModelState.IsValid)
            {
                item.User = HttpContext.User.Identity.Name;
                MessagesBL oMessagesBL = new MessagesBL();
                oMessagesBL.Insert(item);
            }
            else
            {
                List<ModelError> errors = new List<ModelError>();
                foreach (ModelState modelState in ViewData.ModelState.Values)
                {
                    foreach (ModelError error in modelState.Errors)
                    {
                        errors.Add(error);
                    }
                }
                return Json(new { result = "ERROR", message = "AN ERROR OCCURED. PLEASE TRY AGAIN LATER.", errorlist = errors }, JsonRequestBehavior.AllowGet);
            }

            if (result == -1)
            {
                return Json(new { result = "ERROR", message = "AN ERROR OCCURED. PLEASE TRY AGAIN LATER.", errorlist = new List<ModelError>() }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { result = "SUCCESS", message = "SUCCESSFUL TRANSACTION", errorlist = new List<ModelError>() }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult EditMessage(string trdpCode, string msgCode)
        {
            Messages item                             = new Messages();
            item                                      = oMessagesBL.GetAllMessages(trdpCode, msgCode).FirstOrDefault();
            List<MessageSettings> messageSettingsList = new List<MessageSettings>();
            messageSettingsList                       = oMessageSettingsBL.GetAll(msgCode).ToList();

            ViewBag.messageSettingsList = messageSettingsList;

            if (item == null)
            {
                return HttpNotFound();
            }

            PopulateMessageLOV();

            return View(item);
        }

        [HttpPost]
        public ActionResult EditMessage(Messages item)
        {
            int result = 0;
            if (ModelState.IsValid)
            {
                item.User = HttpContext.User.Identity.Name;
                MessagesBL oMessagesBL = new MessagesBL();
                oMessagesBL.Update(item);
            }
            else
            {
                List<ModelError> errors = new List<ModelError>();
                foreach (ModelState modelState in ViewData.ModelState.Values)
                {
                    foreach (ModelError error in modelState.Errors)
                    {
                        errors.Add(error);
                    }
                }
                return Json(new { result = "ERROR", message = "AN ERROR OCCURED. PLEASE TRY AGAIN LATER.", errorlist = errors }, JsonRequestBehavior.AllowGet);
            }

            if (result == -1)
            {
                return Json(new { result = "ERROR", message = "AN ERROR OCCURED. PLEASE TRY AGAIN LATER.", errorlist = new List<ModelError>() }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { result = "SUCCESS", message = "SUCCESSFUL TRANSACTION", errorlist = new List<ModelError>() }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DeleteMessage(string trdpCode, string msgCode)
        {
            Messages item = new Messages();
            item = oMessagesBL.GetAllMessages(trdpCode, msgCode).FirstOrDefault();

            if (item == null)
            {
                return HttpNotFound();
            }

            return View(item);
        }

        [HttpPost]
        [ActionName("DeleteMessage")]
        public ActionResult DeleteConfirmedMessage(Messages item)
        {
            int result = 0;

            result = oMessagesBL.Delete(item.MsgCode, item.TradingPartnercode);

            if (result != 1)
            {
                return Json(new { result = "ERROR", message = "AN ERROR OCCURED. PLEASE TRY AGAIN LATER.", errorlist = new List<ModelError>() }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { result = "SUCCESS", message = "SUCCESSFUL TRANSACTION", errorlist = new List<ModelError>() }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult CreateMessageSettings(string msgCode)
        {
            MessageSettings item = new MessageSettings();
            item.MsgCode         = msgCode;
            PopulateMessageSettingsLOV();

            return View(item);
        }

        [HttpPost]
        public ActionResult CreateMessageSettings(MessageSettings item, FormCollection fc)
        {
            if (ModelState.IsValid)
            {

            }
            else
            {
                List<ModelError> errors = new List<ModelError>();
                foreach (ModelState modelState in ViewData.ModelState.Values.Where(x => x.Errors.Count >= 1))
                {
                    foreach (ModelError error in modelState.Errors)
                    {
                        errors.Add(error);
                    }
                }
                return Json(new { result = "ERROR", message = "AN ERROR OCCURED. PLEASE TRY AGAIN LATER.", errorlist = errors }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { result = "SUCCESS", message = "SUCCESSFUL TRANSACTION", errorlist = new List<ModelError>() }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult EditMessageSettings(string msgCode)
        {
            MessageSettings item        = new MessageSettings();
            item                        = oMessageSettingsBL.GetAll(msgCode).FirstOrDefault();
            item.MessageFileSource      = oFileTransferSettingBL.GetAll(item.MessageFileSourceId).FirstOrDefault();
            item.MessageFileDestination = oFileTransferSettingBL.GetAll(item.MessageFileDestinationId).FirstOrDefault();
            PopulateMessageSettingsLOV();

            return View(item);
        }

        [HttpPost]
        public ActionResult EditMessageSettings(MessageSettings item, FormCollection fc)
        {
            int result = 0, sourceId = 0, destinationId = 0;

            if (ModelState.IsValid)
            {
                #region [Update Message Settings]
                    DateTime dtBatch   = DateTime.ParseExact(item.MsetBatchTimeString, "h:mm:ss tt", CultureInfo.InvariantCulture);
                    TimeSpan tsBatch   = dtBatch.TimeOfDay;
                    item.MsetBatchTime = item.MsetBatchTime.Date + tsBatch;

                    DateTime dtStart   = DateTime.ParseExact(item.MsetStartTimeString, "h:mm:ss tt", CultureInfo.InvariantCulture);
                    TimeSpan tsStart   = dtStart.TimeOfDay;
                    item.MsetStartTime = item.MsetStartTime.Date + tsStart;

                    DateTime dtEnd   = DateTime.ParseExact(item.MsetEndTimeString, "h:mm:ss tt", CultureInfo.InvariantCulture);
                    TimeSpan tsEnd   = dtEnd.TimeOfDay;
                    item.MsetEndTime = item.MsetEndTime.Date + tsEnd;

                    oMessageSettingsBL.Update(item);
                #endregion

                #region [Update FileTransferSetting]
                    FileTransferSetting source = new FileTransferSetting();
                    source.MsgCode             = item.MsgCode;
                    source.TransmissionTypeID  = item.MessageFileSource.TransmissionTypeID;

                    if (item.MessageFileSourceId <= 0)
                    {
                        sourceId = oFileTransferSettingBL.Insert(source);
                    }
                    else
                    {
                        source.FileTransferSettingID = item.MessageFileSourceId;
                        sourceId                     = item.MessageFileSourceId;
                        oFileTransferSettingBL.Update(source);
                    }

                    FileTransferSetting destination = new FileTransferSetting();
                    destination.MsgCode             = item.MsgCode;
                    destination.TransmissionTypeID  = item.MessageFileDestination.TransmissionTypeID;

                    if (item.MessageFileDestinationId <= 0)
                    {
                        destinationId = oFileTransferSettingBL.Insert(destination);
                    }
                    else
                    {
                        destination.FileTransferSettingID = item.MessageFileDestinationId;
                        destinationId                     = item.MessageFileDestinationId;
                        oFileTransferSettingBL.Update(destination);
                    }
                #endregion

                #region [Update TransmissionSetting]
                    SaveTransmissionSetting(item.MessageFileSource.TransmissionTypeID, sourceId, true, fc);
                    SaveTransmissionSetting(item.MessageFileDestination.TransmissionTypeID, destinationId, false, fc);

                #endregion
            }
            else
            {
                List<ModelError> errors = new List<ModelError>();
                foreach (ModelState modelState in ViewData.ModelState.Values)
                {
                    foreach (ModelError error in modelState.Errors)
                    {
                        errors.Add(error);
                    }
                }
                return Json(new { result = "ERROR", message = "AN ERROR OCCURED. PLEASE TRY AGAIN LATER.", errorlist = errors }, JsonRequestBehavior.AllowGet);
            }

            if (result == -1)
            {
                return Json(new { result = "ERROR", message = "AN ERROR OCCURED. PLEASE TRY AGAIN LATER.", errorlist = new List<ModelError>() }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { result = "SUCCESS", message = "SUCCESSFUL TRANSACTION", errorlist = new List<ModelError>() }, JsonRequestBehavior.AllowGet);
        }

        private void SaveTransmissionSetting(int transmissionTypeId, int fileTransferSettingId, bool isSource, FormCollection fc)
        {
            TransmissionTypes transType = (TransmissionTypes) transmissionTypeId;

            switch (transType)
            {
                case TransmissionTypes.FTP:
                    if (isSource)
                        SaveSourceFTPSetting(fileTransferSettingId, fc);
                    else
                        SaveDestFTPSetting(fileTransferSettingId, fc);
                    break;
                case TransmissionTypes.SFTP:
                    if (isSource)
                        SaveSourceSFTPSetting(fileTransferSettingId, fc);
                    else
                        SaveDestSFTPSetting(fileTransferSettingId, fc);
                    break;
                case TransmissionTypes.NETWORK:
                    if (isSource)
                        SaveSourceNetworkSetting(fileTransferSettingId, fc);
                    else
                        SaveDestNetworkSetting(fileTransferSettingId, fc);
                    break;
                case TransmissionTypes.EMAIL:
                    if (isSource)
                        SaveSourceSMTPSetting(fileTransferSettingId, fc);
                    else
                        SaveDestSMTPSetting(fileTransferSettingId, fc);
                    break;
                case TransmissionTypes.HTTP:
                    if (isSource)
                        SaveSourceHTTPSetting(fileTransferSettingId, fc);
                    else
                        SaveDestHTTPSetting(fileTransferSettingId, fc);
                    break;
                default:
                    break;
            }
        }

        public ActionResult EditEmailDistributionList(string msgCode, string erp)
        {
            EmailDistributionListBL oEmailDistributionListBL = EmailDistributionListBL.GetInstance();
            EmailDistributionList item                       = new EmailDistributionList();
            item                                             = oEmailDistributionListBL.GetAll().Where(x => x.MsgCode == msgCode && x.ERP == erp).FirstOrDefault();

            if (item == null)
            {
                item          = new EmailDistributionList();
                item.MsgCode  = msgCode;
                item.ERP      = erp;
                item.XsltPath = @"C:\Program Files\IAPL\XSLT";
            }

            return View("~/Views/Shared/_EmailDistributionList.cshtml", item);
        }

        private void PopulateMessageSettingsLOV()
        {
            IEnumerable<SelectListItem> erpList = new List<SelectListItem>();
            ERPBL oERPBL                        = ERPBL.GetInstance();
            erpList                             = oERPBL.GetAll().OrderBy(x => x.Erp).Select(x => new SelectListItem { Text = x.Erp, Value = x.Erp });
            ViewBag.erpList                     = erpList;

            IEnumerable<SelectListItem> retentionList = new List<SelectListItem>();
            Dictionary<string, string> dRetention = new Dictionary<string, string>();
            for (int i = 0; i <= 12; i++)
            {
                dRetention.Add(i.ToString(), i.ToString());
            }
            retentionList = dRetention.Select(x => new SelectListItem { Text = x.Value, Value = x.Key });
            ViewBag.retentionList = retentionList;

            IEnumerable<SelectListItem> delayList = new List<SelectListItem>();
            Dictionary<string, string> dDelay = new Dictionary<string, string>();
            dDelay.Add("0", "0");
            dDelay.Add("1", "1");
            dDelay.Add("3", "3");
            dDelay.Add("5", "5");
            dDelay.Add("10", "10");
            dDelay.Add("15", "15");
            dDelay.Add("20", "20");
            delayList = dDelay.Select(x => new SelectListItem { Text = x.Value, Value = x.Key });
            ViewBag.delayList = delayList;

            IEnumerable<SelectListItem> transTypeSourceList = new List<SelectListItem>();
            TransmissionTypeBL oTransmissionTypeBL          = TransmissionTypeBL.GetInstance();
            transTypeSourceList                             = oTransmissionTypeBL.GetAll().Where(x => x.TransmissionTypeCode != "EMAIL").OrderBy(x => x.TransmissionTypeCode).Select(x => new SelectListItem { Text = x.TransmissionTypeCode, Value = x.TransmissionTypeID.ToString() });
            ViewBag.transTypeSourceList                     = transTypeSourceList;

            IEnumerable<SelectListItem> transTypeDestinationList = new List<SelectListItem>();
            transTypeDestinationList                             = oTransmissionTypeBL.GetAll().OrderBy(x => x.TransmissionTypeCode).Select(x => new SelectListItem { Text = x.TransmissionTypeCode, Value = x.TransmissionTypeID.ToString() });
            ViewBag.transTypeDestinationList                     = transTypeDestinationList;

            IEnumerable<SelectListItem> fileEncodingList = new List<SelectListItem>();
            FileEncodingBL oFileEncodingBL               = FileEncodingBL.GetInstance();
            fileEncodingList                             = oFileEncodingBL.GetAll().OrderBy(x => x.DisplayName).Select(x => new SelectListItem { Text = x.DisplayName, Value = Convert.ToString(x.CodePageNum) });
            ViewBag.fileEncodingList                     = fileEncodingList;
        }

        public ActionResult PopulatePrincipal(string erp)
        {
            IEnumerable<SelectListItem> principalList = new List<SelectListItem>();
            PrincipalBL oPrincipalBL                  = PrincipalBL.GetInstance();
            principalList                             = oPrincipalBL.GetAll(erp).OrderBy(x => x.Display).Select(x => new SelectListItem { Text = x.Display, Value = x.PRNCPL });
            
            return Json(principalList, JsonRequestBehavior.AllowGet);
        }

        #region [FTP Operations]
        public ActionResult GetFTPSetting(int fileTransferSettingId)
        {
            FTPSettingBL oFTPSettingBL = FTPSettingBL.GetInstance();

            FTPSetting item = oFTPSettingBL.GetAll(fileTransferSettingId).FirstOrDefault();

            return Json(new { result = "SUCCESS", ftpSettingItem = item }, JsonRequestBehavior.AllowGet);
        }

        private void SaveDestFTPSetting(int fileTransferSettingId, FormCollection fc)
        {
            FTPSettingBL oFTPSettingBL = FTPSettingBL.GetInstance();
            FTPSetting item            = new FTPSetting();
            item.FileTransferSettingID = fileTransferSettingId;
            item.UserName              = fc["DestinationUsername"];
            item.Password              = fc["DestinationPassword"];
            item.IPAddress             = fc["DestinationAddress"];
            item.Folder                = fc["DestinationFolder"];
            int thisPort               = 0;
            int.TryParse(fc["DestinationPort"], out thisPort);
            item.PortNumber            = thisPort;

            oFTPSettingBL.Update(item);
        }

        private void SaveSourceFTPSetting(int fileTransferSettingId, FormCollection fc)
        {
            FTPSettingBL oFTPSettingBL = FTPSettingBL.GetInstance();
            FTPSetting item            = new FTPSetting();
            item.FileTransferSettingID = fileTransferSettingId;
            item.UserName              = fc["SourceUsername"];
            item.Password              = fc["SourcePassword"];
            item.IPAddress             = fc["SourceAddress"];
            item.Folder                = fc["SourceFolder"];

            oFTPSettingBL.Update(item);
        }
        #endregion

        #region [SFTP Operations]
        public ActionResult GetSFTPSetting(int fileTransferSettingId)
        {
            SFTPSettingBL oSFTPSettingBL = SFTPSettingBL.GetInstance();

            SFTPSetting item = oSFTPSettingBL.GetAll(fileTransferSettingId).FirstOrDefault();

            return Json(new { result = "SUCCESS", sftpSettingItem = item }, JsonRequestBehavior.AllowGet);
        }

        private void SaveDestSFTPSetting(int fileTransferSettingId, FormCollection fc)
        {
            SFTPSettingBL oSFTPSettingBL = SFTPSettingBL.GetInstance();
            SFTPSetting item             = new SFTPSetting();
            item.FileTransferSettingID   = fileTransferSettingId;
            item.UserName                = fc["DestinationUsername"];
            item.Password                = fc["DestinationPassword"];
            item.IPAddress               = fc["DestinationAddress"];
            item.Folder                  = fc["DestinationFolder"];
            int thisPort                 = 0;
            int.TryParse(fc["DestinationPort"], out thisPort);
            item.PortNumber              = thisPort;

            oSFTPSettingBL.Update(item);
        }

        private void SaveSourceSFTPSetting(int fileTransferSettingId, FormCollection fc)
        {
            SFTPSettingBL oSFTPSettingBL = SFTPSettingBL.GetInstance();
            SFTPSetting item             = new SFTPSetting();
            item.FileTransferSettingID   = fileTransferSettingId;
            item.UserName                = fc["SourceUsername"];
            item.Password                = fc["SourcePassword"];
            item.IPAddress               = fc["SourceAddress"];
            item.Folder                  = fc["SourceFolder"];

            oSFTPSettingBL.Update(item);
        }
        #endregion

        #region [SMTP Operations]
        public ActionResult GetSMTPSetting(int fileTransferSettingId)
        {
            SMTPSettingBL oSMTPSettingBL = SMTPSettingBL.GetInstance();
            SMTPSetting item = oSMTPSettingBL.GetAll(fileTransferSettingId).FirstOrDefault();

            if (item == null)
            {
                item = new SMTPSetting();
            }

            return Json(new { result = "SUCCESS", smtpSettingItem = item }, JsonRequestBehavior.AllowGet);
        }

        private void SaveDestSMTPSetting(int fileTransferSettingId, FormCollection fc)
        {
            SMTPSettingBL oSMTPSettingBL = SMTPSettingBL.GetInstance();
            SMTPSetting item             = new SMTPSetting();
            item.FileTransferSettingID   = fileTransferSettingId;
            item.UserName                = fc["DestinationUsername"];
            item.Password                = fc["DestinationPassword"];
            item.SMTPServer              = fc["DestinationAddress"];

            oSMTPSettingBL.Update(item);
        }

        private void SaveSourceSMTPSetting(int fileTransferSettingId, FormCollection fc)
        {
            SMTPSettingBL oSMTPSettingBL = SMTPSettingBL.GetInstance();
            SMTPSetting item             = new SMTPSetting();
            item.FileTransferSettingID   = fileTransferSettingId;
            item.UserName                = fc["SourceUsername"];
            item.Password                = fc["SourcePassword"];
            item.SMTPServer              = fc["SourceAddress"];

            oSMTPSettingBL.Update(item);
        }
        #endregion

        #region [Network Operations]
        public ActionResult GetNetworkSetting(int fileTransferSettingId)
        {
            NetworkSettingBL oNetworkSettingBL = NetworkSettingBL.GetInstance();
            NetworkSetting item = oNetworkSettingBL.GetAll(fileTransferSettingId).FirstOrDefault();

            if (item == null)
            {
                item = new NetworkSetting();
            }

            return Json(new { result = "SUCCESS", networkSettingItem = item }, JsonRequestBehavior.AllowGet);
        }

        private void SaveDestNetworkSetting(int fileTransferSettingId, FormCollection fc)
        {
            NetworkSettingBL oNetworkSettingBL = NetworkSettingBL.GetInstance();
            NetworkSetting item                = new NetworkSetting();
            item.FileTransferSettingID         = fileTransferSettingId;
            item.MessageFileID                 = 0;
            item.UserName                      = fc["DestinationUsername"];
            item.Password                      = fc["DestinationPassword"];
            item.Path                          = fc["DestinationAddress"];

            oNetworkSettingBL.Update(item);
        }

        private void SaveSourceNetworkSetting(int fileTransferSettingId, FormCollection fc)
        {
            NetworkSettingBL oNetworkSettingBL = NetworkSettingBL.GetInstance();
            NetworkSetting item                = new NetworkSetting();
            item.FileTransferSettingID         = fileTransferSettingId;
            item.MessageFileID                 = 0;
            item.UserName                      = fc["SourceUsername"];
            item.Password                      = fc["SourcePassword"];
            item.Path                          = fc["SourceAddress"];

            oNetworkSettingBL.Update(item);
        }
        #endregion

        #region [HTTP Operations]
        public ActionResult GetHTTPSetting(int fileTransferSettingId)
        {
            HTTPSettingBL oHTTPSettingBL = HTTPSettingBL.GetInstance();
            HTTPSetting item = oHTTPSettingBL.GetAll(fileTransferSettingId).FirstOrDefault();

            if (item == null)
            {
                item = new HTTPSetting();
            }

            return Json(new { result = "SUCCESS", httpSettingItem = item }, JsonRequestBehavior.AllowGet);
        }

        private void SaveDestHTTPSetting(int fileTransferSettingId, FormCollection fc)
        {
            HTTPSettingBL oHTTPSettingBL = HTTPSettingBL.GetInstance();
            HTTPSetting item             = new HTTPSetting();
            item.FileTransferSettingID   = fileTransferSettingId;
            item.UserName                = fc["DestinationUsername"];
            item.Password                = fc["DestinationPassword"];
            item.URL                     = fc["DestinationAddress"];

            oHTTPSettingBL.Update(item);
        }

        private void SaveSourceHTTPSetting(int fileTransferSettingId, FormCollection fc)
        {
            HTTPSettingBL oHTTPSettingBL = HTTPSettingBL.GetInstance();
            HTTPSetting item             = new HTTPSetting();
            item.FileTransferSettingID   = fileTransferSettingId;
            item.UserName                = fc["SourceUsername"];
            item.Password                = fc["SourcePassword"];
            item.URL                     = fc["SourceAddress"];

            //Source HTTP is not yet implemented, settings will not be saved
            //oHTTPSettingBL.Update(item);
        }
        #endregion

        private void PopulateMessageLOV()
        {
            IEnumerable<SelectListItem> appCodeList = new List<SelectListItem>();
            ApplicationCodeBL oApplicationCodeBL    = ApplicationCodeBL.GetInstance();
            appCodeList                             = oApplicationCodeBL.GetAll().OrderBy(x => x.Name).Select(x => new SelectListItem { Text = x.Name, Value = x.Code });
            ViewBag.appCodeList                     = appCodeList;

            IEnumerable<SelectListItem> fileTypeList = new List<SelectListItem>();
            FileTypeBL oFileTypeBL                   = FileTypeBL.GetInstance();
            fileTypeList                             = oFileTypeBL.GetAll().OrderBy(x => x.FileTypeName).Select(x => new SelectListItem { Text = x.FileTypeName, Value = x.FileTypeCode });
            ViewBag.fileTypeList                     = fileTypeList;

            IEnumerable<SelectListItem> fileDirectionList = new List<SelectListItem>();
            FileDirectionBL oFileDirectionBL              = FileDirectionBL.GetInstance();
            fileDirectionList                             = oFileDirectionBL.GetAll().OrderBy(x => x.FileDirectionName).Select(x => new SelectListItem { Text = x.FileDirectionName, Value = x.FileDirectionCode });
            ViewBag.fileDirectionList                     = fileDirectionList;

            IEnumerable<SelectListItem> countryList = new List<SelectListItem>();
            CountryBL oCountryBL                    = CountryBL.GetInstance();
            countryList                             = oCountryBL.GetAll().OrderBy(x => x.Name).Select(x => new SelectListItem { Text = x.Name, Value = x.Code });
            ViewBag.countryList                     = countryList;

            IEnumerable<SelectListItem> dateTypeList = new List<SelectListItem>();
            DateTypeBL oDateTypeBL                   = DateTypeBL.GetInstance();
            dateTypeList                             = oDateTypeBL.GetAll().OrderBy(x => x.DateTypeCode).Select(x => new SelectListItem { Text = x.DateTypeCode, Value = x.DateTypeCode });
            ViewBag.dateTypeList                     = dateTypeList;

            IEnumerable<SelectListItem> codePageList = new List<SelectListItem>();
            CodePageBL oCodePageBL                   = CodePageBL.GetInstance();
            codePageList                             = oCodePageBL.GetAll().OrderBy(x => x.CodePageName).Select(x => new SelectListItem { Text = x.CodePageName, Value = Convert.ToString(x.CodePageId) });
            ViewBag.codePageList                     = codePageList;
        }

        #endregion

    }
}