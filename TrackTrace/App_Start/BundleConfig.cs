using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Optimization;

namespace TrackTrace.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {

            // bundle all css files
            bundles.Add(new StyleBundle("~/bundle/css")

             .Include("~/static/css/custom.css")
             .IncludeDirectory( "~/static", ".css"));
        }
     }
}