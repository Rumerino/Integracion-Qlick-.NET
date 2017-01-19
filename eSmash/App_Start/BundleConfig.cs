using System.Web.Optimization;

namespace eSmash
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-2.2.3.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                        "~/Scripts/bootstrap.js",
                        "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                        "~/Content/bootstrap.css",
                        "~/Content/Css/bootstrap-switch.min.css",
                        "~/Content/font-awesome.css",
                        "~/Content/site.css",
                        "~/Content/Css/base.css"));

            bundles.Add(new StyleBundle("~/Content/css/intro").Include(
                        "~/Content/Css/intro.css"));

            // Qlik
            //
            // IMPORTANTE: los recursos CSS, el require.js y las fuentes de Qlik (~/fonts/qlik*)
            // se utilizan localmente a modo de ejemplo para poder trabajar con la versión "Desktop"
            // ya que ésta no permite la configuración de la cabecera CORS
            // (ver https://en.wikipedia.org/wiki/Cross-origin_resource_sharing).
            //
            // En caso de utilizar aplicaciones en un servidor de Qlik o ser una aplicación de producción
            // éstos recursos han de ser solicitados directamente al servidor.
            //
            // IMPORTANTE: el recurso "require.js" que hay que utilizar para los mashups con Qlik
            // contiene más librerías, entre ellas AngularJs, jQuery y jQuery.UI, esto puede llevar
            // a comportamientos inesperados, se pueden reducir los problemas cargando "require.js"
            // antes de cualquier otra librería, pero aún así algunas cosas pueden no funcionar
            // como se espera.
            //
            // Librerías con las que se sabe que hay problemas:
            //
            // -jQuery.UI: en principio se puede utilizar la que viene en "require.js" de Qlik sin
            //  ser necesario instalarla de modo específico.
            //
            bundles.Add(new StyleBundle("~/Content/qlik").Include(
                        "~/Content/Css/Qlik/qlik-styles.css"));

            bundles.Add(new ScriptBundle("~/bundles/qlik/require.js").Include(
                        "~/Scripts/Qlik/require.js"));

            bundles.Add(new ScriptBundle("~/bundles/qlik").Include(
                       //"~/Scripts/jquery-ui-{version}.js",
                       "~/Scripts/Qlik/on-error.js",
                       "~/Scripts/Qlik/qlik-server-config.js",
                       "~/Scripts/Qlik/Mashup/qlik-mashup-utils.js",
                       "~/Scripts/Qlik/Mashup/qlik-mashup-listeners.js",
                       "~/Scripts/Qlik/Mashup/qlik-mashup.js",
                       "~/Scripts/Qlik/Mashup/qlik-ui-listeners.js",
                       "~/Scripts/Qlik/Mashup/qlik-ui.js"));


            // Demo1
            bundles.Add(new StyleBundle("~/Content/css/demo1").Include(
                        "~/Content/Css/Qlik/qlik-ui.css"));

            // Demo2
            bundles.Add(new StyleBundle("~/Content/css/demo").Include(
                        "~/Content/Css/Qlik/qlik-ui.css",
                        "~/Content/jasny-bootstrap.css",
                        "~/Content/Css/offcanvas-menu.css",
                        "~/Content/Css/Demo/demo-custom-bootstrap.css",
                        "~/Content/Css/Demo/demo.css",
                        "~/Content/Css/Qlik/qlik-styles-custom.css"));

            bundles.Add(new ScriptBundle("~/bundles/demo").Include(
               "~/Scripts/jasny-bootstrap.js",
               "~/Scripts/Demo/glossary-search.js",
               "~/Scripts/Demo/offcanvas-backdrop.js",
               "~/Scripts/Demo/data-export-modal.js"));

            // list.js: IMPORTANTE: produce errores si se carga después del require.js de Qlik
            bundles.Add(new ScriptBundle("~/bundles/list.js").Include(
                "~/Scripts/list.js"));

            // theme 1
            bundles.Add(new StyleBundle("~/Content/css/theme1").Include(
                "~/Content/Css/Demo/theme1.css"));

            // theme 2
            bundles.Add(new StyleBundle("~/Content/css/theme2").Include(
                "~/Content/Css/Demo/theme2.css"));





            bundles.Add(new ScriptBundle("~/js/required").Include(
                           "~/Scripts/jquery-2.2.3.js"));

            bundles.Add(new ScriptBundle("~/bundles/js/libs").Include(
                           "~/Scripts/jquery-2.2.3.min.js",
                           "~/Scripts/jquery.unobtrusive-ajax.min.js",
                           "~/Scripts/jquery.validate.min.js",
                           "~/Scripts/lib/moment.min.js",
                           "~/Scripts/bootstrap.min.js",
                           "~/Scripts/bootstrap-select.min.js",
                           "~/Scripts/bootstrap-datepicker.min.js",
                           "~/Scripts/bootstrap-datepicker-locales/bootstrap-datepicker.es.min.js",
                           "~/Scripts/bootstrap-switch.min.js",
                           "~/Scripts/datatables.min.js",
                           "~/Scripts/select2.min.js",
                           "~/Scripts/inputTypeNumberPolyfill.min.js"
                           //"~/Scripts/respond.min.js"
                           ));

            // iframe-loader javascript
            bundles.Add(new ScriptBundle("~/bundles/iframeloader").Include(
                        "~/Scripts/ua-parser.min.js",
                        "~/Scripts/iframe-loader/iframe-loader.js",
                        "~/Scripts/iframe-loader/iframe-selector.js",
                        "~/Scripts/iframe-loader/qlik-fix.js"));

            // Clockpicker
            bundles.Add(new ScriptBundle("~/bundles/clockpicker").Include(
                        "~/Scripts/bootstrap-clockpicker.js"));


            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

 
        }
    }
    
}
