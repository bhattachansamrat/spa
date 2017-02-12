using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace Spa.Web.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundle(BundleCollection bundle)
        {
            bundle.Add(new StyleBundle("~/Content").Include("~/Content/bootstrap.css",
                "~/Content/bootstrap-theme.css",
                "~/Content/loading-bar.css",
                "~/Content/toastr.css", "~/Content/font-awesome.css"));

            bundle.Add(new ScriptBundle("~/script/modernizr").Include("~/scripts/vendor/modernizr.js"));

            bundle.Add(new ScriptBundle("~/script/vendor").Include("~/scripts/jquery-{version}.js",
                "~/scripts/bootstrap.js",
                "~/scripts/vendor/angular.js", 
                "~/scripts/vendor/angular-route.js",
                "~/scripts/vendor/angular-cookies.js",
                "~/scripts/vendor/angular-validator.js",
                "~/scripts/vendor/angular-base64.js",
                "~/scripts/vendor/loading-bar.js",
                "~/scripts/vendor/toastr.js",
                "~/scripts/vendor/ui-bootstrap-tpls-0.13.1.js"
                ));

            bundle.Add(new ScriptBundle("~/script/spa").Include("~/scripts/spa/modules/*.js", 
                "~/scripts/spa/app.js",
                "~/scripts/spa/services/apiService.js",
                "~/scripts/spa/services/notificationService.js"));
        }
    }
}