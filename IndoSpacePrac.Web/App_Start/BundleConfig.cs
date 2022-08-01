using System.Web;
using System.Web.Optimization;

namespace IndoSpacePrac.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));


            // Custom StyleSheet

            bundles.Add(new StyleBundle("~/Content/Custom").IncludeDirectory("~/Content/Custom", "*.css"));

            //Custom Javascripts

            bundles.Add(new ScriptBundle("~/Scripts/Custom")
            .Include(
                     "~/Scripts/Custom/EmployeeMaster.js"
            )); 
            
            bundles.Add(new ScriptBundle("~/Scripts/jquery")
            .Include("~/Scripts/jquery-3.4.1.min.js"
            ));

            bundles.Add(new ScriptBundle("~/Scripts/DataTables")
                .Include(
                    "~/Scripts/DataTables/jquery.dataTables.min.js"
                ));

            bundles.Add(new StyleBundle("~/Custom/DataTables")
                .IncludeDirectory(
                    "~/Content/DataTables/css","*.css"
                ));

        }
        

    }
}
