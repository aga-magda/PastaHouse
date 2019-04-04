using System.Web.Optimization;

namespace PastaHouse
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            // Scripts

            bundles.Add(new ScriptBundle("~/Scripts/jquery").Include(
                "~/Scripts/libs/jquery-{version}.js",
                "~/Scripts/libs/jquery.backgroundMove.js",
                "~/Scripts/libs/jquery.unobtrusive-ajax.js"));

            bundles.Add(new ScriptBundle("~/Scripts/jqueryval").Include(
                "~/Scripts/libs/jquery.validate.js",
                "~/Scripts/libs/jquery.validate.unobtrusive.js"));

            bundles.Add(new ScriptBundle("~/Scripts/bootstrap").Include(
                "~/Scripts/libs/bootstrap.js",
                "~/Scripts/libs/respond.min.js"));

            // Stylesheets

            bundles.Add(new StyleBundle("~/Stylesheets/libraries").Include(
                "~/Stylesheets/libs/animate.css",
                "~/Stylesheets/libs/ionicons.min.css",
                "~/Stylesheets/libs/bootstrap.css"));
        }
    }
}
