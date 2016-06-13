using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCGoogle.Controllers
{
    using Sitecore.Data;
    using Sitecore.Links;
    using Sitecore.Mvc.Configuration;
    using Sitecore.Mvc.Presentation;
    using Sitecore.StringExtensions;

    public class SearchController : Controller
    {
        //
        // GET: /Search/

        public ActionResult Index()
        {
            return this.View();
        }

        [HttpPost]
        public ActionResult Search(string query, string dataSource, string ifl)
        {
            var options = new UrlOptions
            {
                AddAspxExtension = false,
                LanguageEmbedding = LanguageEmbedding.Never
            };

            var pathInfo = LinkManager.GetItemUrl(Sitecore.Context.Database.GetItem(new ID(dataSource)), options);

            object args;
            if (!ifl.IsNullOrEmpty())
            {
                args = new { pathInfo = pathInfo.TrimStart(new char[] { '/' }), q = query, ifl = true };
            }
            else
            {
                args = new { pathInfo = pathInfo.TrimStart(new char[] { '/' }), q = query };
            }

            return RedirectToRoute(MvcSettings.SitecoreRouteName, args);
        }
    }
}