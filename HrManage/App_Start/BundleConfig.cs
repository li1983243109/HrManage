using System.Web;
using System.Web.Optimization;

namespace HrManage
{
    public class BundleConfig
    {
        // 有关捆绑的详细信息，请访问 https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                         "~/Scripts/jquery-{version}.js"));

            //1.menu需要的前端框架引用
            bundles.Add(new StyleBundle("~/assets/css/menu").Include(
                       "~/assets/css/dpl-min.css",
                       "~/assets/css/bui-min.css",
                       "~/assets/css/main-min.css"
                       ));
            bundles.Add(new ScriptBundle("~/assets/js/menu").Include(                        
                        "~/assets/js/bui-min.js",
                        "~/assets/js/config.js"
                       ));

            //2.bootstrap
            bundles.Add(new StyleBundle("~/Content/css/bootstrap").Include(
                        "~/Content/bootstrap/bootstrap.min.css"));
            bundles.Add(new ScriptBundle("~/Content/js/bootstrap").Include(
                        "~/Content/bootstrap/bootstrap.min.js"));

            //3.bootstrap-table
            bundles.Add(new StyleBundle("~/Content/bootstrap-table/css").Include(
                        "~/Content/bootstrap-table/bootstrap-table.min.css"));
            bundles.Add(new ScriptBundle("~/Content/bootstrap-table/js").Include(
                        "~/Content/bootstrap-table/bootstrap-table.min.js"));


            //for sendEmail 加载数据列表
            bundles.Add(new ScriptBundle("~/Script/Home/Index").Include(
                        "~/Scripts/Home/Index.js"));

            //bundles.Add(new ScriptBundle("~/Script/Role/Index").Include(
            //            "~/Scripts/Role/Index.js"));

        }
    }
}
