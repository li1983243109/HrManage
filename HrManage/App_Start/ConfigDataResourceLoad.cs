using CommonHeler.File;
using CommonHelper.Extension;
using HrManage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HrManage.App_Start
{
    /// <summary>
    /// 获取本地静态资源
    /// </summary>
    public class ConfigDataResourceLoad
    {
        #region 左侧menu菜单项

        /// <summary>
        /// 获取左侧menu菜单项
        /// </summary>
        /// <returns></returns>
        public static List<MenuNav> GetMenuNavList()
        {
            List<MenuNav> menuNavs = new List<MenuNav>();
            try
            {
                //读menuNav.config文件
                menuNavs = XmlHelper.ToObject<List<MenuNav>>("menuConfig.xml");
            }
            catch (Exception ex)
            {
                //设置默认的
                menuNavs = GetDefaultMenuNavList();
            }
            finally
            {
                if (menuNavs.Count == 0)
                {
                    menuNavs = GetDefaultMenuNavList();
                }
            }

            return menuNavs;
        }

        /// <summary>
        /// 获取默认的menu节点（hardcode,为了防止user忘记或者不会配置menu，让程序基本功能也能work）
        /// </summary>
        /// <returns></returns>
        private static List<MenuNav> GetDefaultMenuNavList()
        {
            List<MenuNav> menuNavs = new List<MenuNav>();
            menuNavs.Add(
                       new MenuNav()
                       {
                           text = "发送邮件",
                           items = new List<MenuNavChild>()
                           {
                               new MenuNavChild (){ text="单独私密邮件", href="Home/SendEmail",id="sendEmail"}
                           }
                       }

                   );
            return menuNavs;
        }

        #endregion

        #region 发件人信息

        /// <summary>
        /// 获取左侧menu菜单项
        /// </summary>
        /// <returns></returns>
        public static List<SenderAddrInfo> GetSenderAddrInfoList()
        {
            List<SenderAddrInfo> senderAddrInfos = new List<SenderAddrInfo>();
            try
            {
                //读menuNav.config文件
                senderAddrInfos = XmlHelper.ToObject<List<SenderAddrInfo>>("senderConfig.xml");
            }
            catch (Exception ex)
            {
                //设置默认的
                senderAddrInfos = GetDefaultSenderAddrInfoList();
            }
            finally
            {
                if (senderAddrInfos.Count == 0)
                {
                    senderAddrInfos = GetDefaultSenderAddrInfoList();
                }
            }

            return senderAddrInfos;
        }

        /// <summary>
        /// 获取默认的menu节点（hardcode,为了防止user忘记或者不会配置menu，让程序基本功能也能work）
        /// </summary>
        /// <returns></returns>
        private static List<SenderAddrInfo> GetDefaultSenderAddrInfoList()
        {
            List<SenderAddrInfo> senderAddrInfos = new List<SenderAddrInfo>();
            senderAddrInfos.Add(
                       new SenderAddrInfo()
                       {
                           SenderAddr = "susan.zeng@fa-software.com",
                           SenderDisplayName = "曾姗姗"
                       }

                   );
            return senderAddrInfos;
        }

        #endregion
    }

}