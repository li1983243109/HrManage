using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HrManage.Models
{

    /// <summary>
    /// for 给前台动态展示menu信息
    /// </summary>
    public class MenuNav
    {
        /// <summary>
        /// 大类的名称
        /// </summary>
        public string text { get; set; }

        /// <summary>
        /// 该类别里有的菜单
        /// </summary>
        public List<MenuNavChild> items { get; set; }

    }

    /// <summary>
    /// 菜单a 标签
    /// </summary>
    public class MenuNavChild
    {
        /// <summary>
        /// 显示菜单名称
        /// </summary>
        public string text { get; set; }

        /// <summary>
        /// 页面地址，mvc风格的
        /// </summary>
        public string href { get; set; }

        public string id { get; set; }

        /// <summary>
        /// 不太确认那个前端框架是否一定需要 Id,并且Id还不能相同,先留一个属性
        /// </summary>
        //public string id
        //{
        //    get
        //    {
        //        return System.Guid.NewGuid().ToString();
        //    }
        //}
    }
}