using System.Web.Optimization;
using WebHelpers.Mvc5;

namespace Blog.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Bundles/Default/css")
                .Include("~/Content/css/bootstrap.min.css", new CssRewriteUrlTransformAbsolute())
                .Include("~/Content/css/font-awesome.min.css")
                .Include("~/Content/css/modern-business.css", new CssRewriteUrlTransformAbsolute()));

            bundles.Add(new ScriptBundle("~/Bundles/Default/js")
                .Include("~/Content/js/jquery.js")
                .Include("~/Content/js/bootstrap.min.js"));

            bundles.Add(new StyleBundle("~/Bundles/Admin/css")
                .Include("~/Areas/Admin/Content/css/bootstrap.min.css", new CssRewriteUrlTransformAbsolute())
                .Include("~/Areas/Admin/Content/css/select2.min.css")
                .Include("~/Areas/Admin/Content/css/bootstrap-datepicker3.min.css")
                .Include("~/Areas/Admin/Content/css/font-awesome.min.css", new CssRewriteUrlTransformAbsolute())
                .Include("~/Areas/Admin/Content/css/icheck/blue.min.css", new CssRewriteUrlTransformAbsolute())
                .Include("~/Areas/Admin/Content/css/AdminLTE.css", new CssRewriteUrlTransformAbsolute())
                .Include("~/Areas/Admin/Content/css/skins/skin-blue.css")
                .Include("~/Areas/Admin/Content/css/dataTables.bootstrap.min.css"));

            bundles.Add(new ScriptBundle("~/Bundles/Admin/js")
                .Include("~/Areas/Admin/Content/js/plugins/jquery/jquery-2.2.4.js")
                .Include("~/Areas/Admin/Content/js/plugins/bootstrap/bootstrap.js")
                .Include("~/Areas/Admin/Content/js/plugins/fastclick/fastclick.js")
                .Include("~/Areas/Admin/Content/js/plugins/slimscroll/jquery.slimscroll.js")
                .Include("~/Areas/Admin/Content/js/plugins/select2/select2.full.js")
                .Include("~/Areas/Admin/Content/js/plugins/moment/moment.js")
                .Include("~/Areas/Admin/Content/js/plugins/datepicker/bootstrap-datepicker.js")
                .Include("~/Areas/Admin/Content/js/plugins/icheck/icheck.js")
                .Include("~/Areas/Admin/Content/js/plugins/validator.js")
                .Include("~/Areas/Admin/Content/js/plugins/inputmask/jquery.inputmask.bundle.js")
                .Include("~/Areas/Admin/Content/js/adminlte.js")
                .Include("~/Areas/Admin/Content/js/init.js")
                .Include("~/Areas/Admin/Content/js/jquery.dataTables.min.js")
                .Include("~/Areas/Admin/Content/js/dataTables.bootstrap.min.js"));

#if DEBUG
            BundleTable.EnableOptimizations = false;
#else
            BundleTable.EnableOptimizations = true;
#endif
        }
    }
}
