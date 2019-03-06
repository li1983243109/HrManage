using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HrManage.Models
{
    public class ReturnToClient
    {
        /// <summary>
        /// 0表示成功
        /// </summary>
        public int Result { get; set; }

        public string ErrorDesc { get; set; }

        
    }
}