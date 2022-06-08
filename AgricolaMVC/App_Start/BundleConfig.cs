using System.Web;
using System.Web.Optimization;

namespace AgricolaMVC
{
    public class BundleConfig
    {
        // Para obtener más información sobre las uniones, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información. De este modo, estará
            // para la producción, use la herramienta de compilación disponible en https://modernizr.com para seleccionar solo las pruebas que necesite.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            //bundles.Add(new ScriptBundle("~/bundles/SemanticJs").Include(
            //          "~/Content/Semantic/semantic.min.js"));
            

                  bundles.Add(new StyleBundle("~/bundles/SemanticCss").Include(
                     "~/Content/Semantic/semantic.min.css",
              "~/Content/Semantic/semantic.helpers.css",
              "~/Content/Libraries/BootstrapDatepicker/bootstrap-datepicker3.standalone.min.css"
              //"~/Content/Libraries/bootstrap-datepicker.standalone.min.css"
              ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/bundles/SemanticJs").Include(
                "~/Content/Semantic/semantic.min.js",
                "~/Content/Libraries/DataTables/jquery.dataTables.min.js",
                "~/Content/Libraries/DataTables/dataTables.buttons.min.js",
                "~/Content/Libraries/DataTables/buttons.html5.min.js",
                "~/Content/Libraries/DataTables/buttons.print.min.js",
                "~/Content/Libraries/DataTables/dataTables.semanticui.min.js",
                "~/Content/Libraries/DataTables/buttons.semanticui.min.js",
                "~/Content/Libraries/BootstrapDatepicker/bootstrap-datepicker.min.js",



                "~/Content/Libraries/BootstrapDatepicker/locales/bootstrap-datepicker.es.min.js",
                "~/Content/funcionesGlobales.js"
                ));
        }
    }
}
