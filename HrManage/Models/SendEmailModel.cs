using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HrManage.Models
{
    /// <summary>
    /// 比较spcical,一个人给多个人发送不同人,不同内容的邮件
    /// </summary>
    public class SendEmailModel
    {
        
        public string SenderAddr { get; set; }

        public string SenderDisplayName { get; set; }

        public string Subuject { get; set; }

        public string ColNames { get; set; }

        /// <summary>
        /// 如果是群发多个私密的,client一起打包过来,用$$$分割
        /// </summary>
        public string EmailBody { get; set; }

        /// <summary>
        /// 如果是群发多个私密的,client一起打包过来,用$$$分割
        /// </summary>
        public string ToAddr { get; set; }
    }

    /// <summary>
    /// 发件人信息(显示名字和邮箱地址)
    /// </summary>
    public class SenderAddrInfo
    {
        public string SenderAddr { get; set; }
        public string SenderDisplayName { get; set; }
        public string Password { get; set; }
        public string Host { get; set; }
    }
}