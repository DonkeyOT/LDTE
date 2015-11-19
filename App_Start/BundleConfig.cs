using System.Web;
using System.Web.Optimization;

namespace LDTE_Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {

            bundles.Add(new ScriptBundle("~/bundles/LDTEjquery").Include(
                        "~/bower_components/jquery/dist/jquery.min.js",
                        "~/ bower_components/bootstrap/dist/js/bootstrap.min.js",
                       
                        "~/bower_components/raphael/raphael-min.js",
                        "~/bower_components/morrisjs/morris.min.js",
                        "~/dist/js/sb-admin-2.js",
                        "~/bower_components/datatables/media/js/jquery.dataTables.min.js",
                        "~/bower_components/datatables-plugins/integration/bootstrap/3/dataTables.bootstrap.min.js",
                         "~/bower_components/metisMenu/dist/metisMenu.min.js"
                        ));

            bundles.Add(new StyleBundle("~/Content/LDTEcss").Include(
                      "~/bower_components/bootstrap/dist/css/bootstrap.min.css",
                      "~/bower_components/metisMenu/dist/metisMenu.min.css",
                      "~/dist/css/sb-admin-2.css",
                      "~/bower_components/font-awesome/css/font-awesome.min.css"
                      ));
            //bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            //            "~/Scripts/jquery-{version}.js"));

            //bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
            //            "~/Scripts/jquery.validate*"));

            //// Use the development version of Modernizr to develop with and learn from. Then, when you're
            //// ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //            "~/Scripts/modernizr-*"));

            //bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
            //          "~/Scripts/bootstrap.js",
            //          "~/Scripts/respond.js"));

            //bundles.Add(new StyleBundle("~/Content/css").Include(
            //          "~/Content/bootstrap.css",
            //          "~/Content/site.css"));
        }
    }
}
