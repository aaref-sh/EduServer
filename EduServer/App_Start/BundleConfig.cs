using System.Web;
using System.Web.Optimization;

namespace EduServer
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*",
                        "~/Scripts/theme.js",
                        "~/Scripts/popper.js",
                        "~/Scripts/bootstrap.min.js",
                        "~/vendors/nice-select/js/jquery.nice-select.min.js",
                        "~/Scripts/owl-carousel-thumb.min.js",
                        "~/Scripts/jquery.ajaxchimp.min.js",
                        "~/Scripts/mail-script.js",
                        "~/vendors/owl-carousel/owl.carousel.min.js"
                        
                        ));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/flaticon.css",
                      "~/Content/themify-icons.css",
                      "~/vendors/owl-carousel/owl.carousel.min.css",
                      "~/vendors/nice-select/css/nice-select.cs",
                      "~/Content/style.css",
                      "~/Content/my.css"
                      ));
        }
    }
}
