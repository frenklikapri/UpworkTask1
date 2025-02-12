﻿using System.Web;
using System.Web.Optimization;

namespace UpworkTask
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Content/sweetalert/sweetalert2@10.js",
                        "~/Content/toastify/toastify.js",
                        "~/Scripts/utils.js",
                        "~/Content/blockUI/jquery.blockUI.js",
                        "~/Content/datatable/jquery.dataTables.min.js"));

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
                      "~/Content/fw/all.min.css",
                      "~/Content/toastify/toastify.css",
                      "~/Content/sweetalert/sweetalert2.min.css",
                      "~/Content/datatable/jquery.dataTables.min.css",
                      "~/Content/site.css"));
        }
    }
}
