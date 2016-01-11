using System.Web;
using System.Web.Optimization;

namespace Seguricel3
{
    public class BundleConfig
    {
        // Para obtener más información sobre Bundles, visite http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/DataTables/jquery.dataTables.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery-unobtrusive*",
                        "~/Scripts/jquery.validate*"));

            // Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información. De este modo, estará
            // preparado para la producción y podrá utilizar la herramienta de compilación disponible en http://modernizr.com para seleccionar solo las pruebas que necesite.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/bootstrap-datepicker.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/seguricel").Include(
                        "~/Scripts/Seguricel-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/bootstrap-datepicker.css",
                      "~/Content/Seguricel-*",
                      "~/Content/Seguricel.css"));

            bundles.Add(new StyleBundle("~/Content/metroUI/css").Include(
                      "~/Content/metroUI/metro.css",
                      "~/Content/metroUI/metro.min.css",
                      "~/Content/metro-*"));


            bundles.Add(new ScriptBundle("~/bundles/metroUI").Include(
                      "~/Scripts/metroUI/global.js",
                      "~/Scripts/metroUI/initiator.js",
                      "~/Scripts/metro.js",
                      "~/Scripts/metro.min.js",
                      "~/Scripts/metroUI/requirements.js",
                      "~/Scripts/metroUI/widget.js",
                      "~/Scripts/metroUI/utils/easing.js",
                      "~/Scripts/metroUI/utils/hotkeys.js",
                      "~/Scripts/metroUI/utils/mousewheel.js",
                      "~/Scripts/metroUI/utils/pre-code.js",
                      "~/Scripts/metroUI/utils/touch-handler.js",
                      "~/Scripts/metroUI/widgets/*.js"));


            // Covalidar Acta de Matrimonio por Registro Principal de Los Teques
            // Legalizar por el SAREN
        }
    }
}
