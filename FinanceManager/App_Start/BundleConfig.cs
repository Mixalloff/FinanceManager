using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace FinanceManager.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/js").Include(
                        "~/Content/js/jquery.js",
                        "~/Content/js/angular.min.js",
                        "~/Content/js/angular-route.js",
                        "~/Content/js/angular-animate.js",
                        "~/Content/js/functions.js",
                        "~/Content/js/md5.js",
                        "~/Content/js/url.min.js",
                        "~/Content/js/parallax.js",
                        "~/Content/js/parallax.min.js",
                        "~/Content/js/animate-css.js",
                        "~/Content/js/waypoints.min.js",
                        "~/Content/js/jquery.magnific-popup.min.js",   
                        "~/Content/js/Modules/modules.js",
                        "~/Content/js/Controllers/CommonController.js",
                        "~/Content/js/Controllers/SignInController.js",
                        "~/Content/js/Controllers/PersonalPageController.js",
                        "~/Content/js/jqBootstrapValidation.js"
                        ));
            
            bundles.Add(new StyleBundle("~/bundles/css").Include(
                        "~/Content/css/style.css",
                        "~/Content/css/bootstrap.min.css",
                        "~/Content/css/animate.css",
                        "~/Content/css/font-awesome.min.css"
                        ));
        }
    }
}