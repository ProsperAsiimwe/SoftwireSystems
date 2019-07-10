using System.Web;
using System.Web.Optimization;

namespace Softwire.WebUI
{
    public class BundleConfig
    {
      
        public static void RegisterBundles(BundleCollection bundles)
        {
           
            bundles.Add(new StyleBundle("~/Content/styles/login").Include(
                     "~/Content/loginAssets/css/font-awesome.min.css",
                     "~/Content/loginAssets/css/style.css"));


            bundles.Add(new StyleBundle("~/Content/styles/core").Include(
                      "~/Content/assets/css/bootstrap.min.css",
                      "~/Content/assets/css/animate.css",
                      "~/Content/assets/css/meanmenu.css",
                      "~/Content/assets/css/magnific-popup.min.css",
                      "~/Content/assets/css/owl.carousel.min.css",
                      "~/Content/assets/css/odometer.css",
                      "~/Content/assets/css/slick.css",
                      "~/Content/assets/css/style.css",
                      "~/Content/assets/css/responsive.css"));

            bundles.Add(new ScriptBundle("~/bundles/sitescripts").Include(
                        "~/Content/assets/js/jquery.min.js",
                        "~/Content/assets/js/popper.min.js",
                        "~/Content/assets/js/bootstrap.min.js",
                        "~/Content/assets/js/jquery.meanmenu.min.js",
                        "~/Content/assets/js/wow.min.js",
                        "~/Content/assets/js/jquery.magnific-popup.min.js",
                        "~/Content/assets/js/jquery.appear.js",
                        "~/Content/assets/js/odometer.min.js",
                        "~/Content/assets/js/slick.js",
                        "~/Content/assets/js/owl.carousel.min.js",
                        "~/Content/assets/js/feather.min.js",
                        "~/Content/assets/js/form-validator.min.js",
                        "~/Content/assets/js/contact-form-script.js",
                        "~/Content/assets/js/startp-map.js",
                        "~/Content/assets/js/main.js",
                        "~/Content/assets/js/jquery.shorten.1.0.js",
                        "~/Scripts/TwitterBootstrapMvcJs.js",
                        "~/Scripts/bootstrap.js",
                        "~/Scripts/bootstrap-datepicker.js",
                        "~/Scripts/bootstrap-datepicker.min.js",                        
                        "~/Scripts/respond.js",
                        "~/Scripts/bootstrap-tabcollapse.js"));

          
        }
    }
}
