using HrManage.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CommonHelper.Extension;

using HrManage.Models;
using CommonHelper.Excel;
using System.Data;
using System.Text;
using System.IO;
using CommonHeler.Extension;
using System.Text.RegularExpressions;

namespace HrManage.Controllers
{
    public class HomeController : Controller
    {
        private static List<SenderAddrInfo> senderAddrInfoList = null;
        public ActionResult Index()
        {
            var list = ConfigDataResourceLoad.GetMenuNavList();
            string strMenu = JsonHelper.ToJson(list);
            ViewBag.MenuInfo = strMenu;
            return View();
        }
        [HttpGet]
        public ActionResult SendEmail()
        {
            senderAddrInfoList = ConfigDataResourceLoad.GetSenderAddrInfoList();
            ViewBag.senderAddrInfoList = senderAddrInfoList;
            return View();

        }
        [HttpPost]
        public ActionResult SendEmail(SendEmailModel model)
        {
            ReturnToClient returnToClient = new ReturnToClient();
            string strEndToAddr = string.Empty;
            try
            {
                if (model.SenderAddr.IsNullOrEmpty() || model.SenderDisplayName.IsNullOrEmpty()
                    || model.ToAddr.IsNullOrEmpty() || model.Subuject.IsNullOrEmpty())
                {
                    throw new Exception("数据参数错误,确保发件人信息,主题,收件人邮箱 信息完整");
                }

                //根据发件人和发件人邮箱获取 密码和host
                var senderInfo = senderAddrInfoList.FirstOrDefault(a => a.SenderAddr == model.SenderAddr && a.SenderDisplayName == model.SenderDisplayName);
                if (senderInfo == null)
                {
                    throw new Exception("数据参数错误");
                }

                Regex r = new Regex(@"^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$");

                model.EmailBody = model.EmailBody.Replace("data-custom=\"actionCol\"", " style=\"display:none;\" ");                
                model.ColNames = model.ColNames.Replace("data-custom=\"actionCol\"", " style=\"display:none;\" ");

                var emailBodyArr = model.EmailBody.Split(new string[] { "$$$" }, StringSplitOptions.RemoveEmptyEntries);
                var emailToAddrArr = model.ToAddr.Split(new string[] { "$$$" }, StringSplitOptions.RemoveEmptyEntries);               

                for (int i = 0; i < emailBodyArr.Length; i++)
                {
                    strEndToAddr = emailToAddrArr[i];
                    if (!r.IsMatch(emailToAddrArr[i]))
                    {
                        throw new Exception("邮箱地址错误");
                    }
                    string body = "<table border=\"1\" align=\"left\" cellpadding=\"3\" cellspacing=\"0\">" +
                                    model.ColNames + emailBodyArr[i] +
                                  "</table>";


                    EmailHelper.SendPrivateMail(model.SenderAddr, senderInfo.Password, model.SenderDisplayName, senderInfo.Host, model.Subuject, emailToAddrArr[i], body);
                }
            }
            catch (Exception ex)
            {
                returnToClient.Result = -1;
                strEndToAddr = strEndToAddr.IsNullOrEmpty() ? strEndToAddr: "在给" + strEndToAddr + "发送时";
                returnToClient.ErrorDesc = strEndToAddr + "[" + ex.Message + "]";
            }
            string data = JsonHelper.ToJson(returnToClient);
            return Json(data);
        }

        [HttpPost]
        public ActionResult LoadExcelFile()
        {
            var file = Request.Files[0];

            var strFileName = Path.GetFileName(file.FileName);
            //定义服务器的文件夹，用来保存文件
            var strServerFilePath = Server.MapPath("/docs/");
            //将接收到文件保存在服务器指定上当

            if (!Directory.Exists(strServerFilePath))
            {
                Directory.CreateDirectory(strServerFilePath);
            }
            string strSrvFileName = Path.Combine(strServerFilePath, strFileName);
            file.SaveAs(strSrvFileName);

            DataTable dt = ExcelHelper.ExcelToDataTable(strSrvFileName, "Sheet1", true);
            string strMenu = JsonHelper.ToJson(dt);

            System.IO.File.Delete(strSrvFileName);

            return Json(strMenu);
        }

        public ActionResult Recruit()
        {
            return View();
        }





    }
}