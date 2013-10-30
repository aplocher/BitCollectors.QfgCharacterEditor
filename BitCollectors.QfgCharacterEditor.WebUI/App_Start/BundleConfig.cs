using System.Web;
using System.Web.Optimization;

namespace BitCollectors.QfgCharacterEditor.WebUI
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/script").Include(
                "~/Scripts/jquery-1.9.1.min.js",
                "~/Scripts/jquery.validate.min.js",
                "~/Scripts/BitCollectors.QfgCharacterEditor.js"
                ));

            bundles.Add(new StyleBundle("~/bundles/css").Include(
                "~/Content/site.css"));

            BundleTable.EnableOptimizations = true;
        }
    }
}