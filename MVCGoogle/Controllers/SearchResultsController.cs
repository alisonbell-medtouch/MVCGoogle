using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCGoogle.Controllers
{
    using Models;

    using Sitecore.Data.Items;

    public class SearchResultsController : Controller
    {
        //
        // GET: /Search/

        public ActionResult Index(string q, bool? ifl)
        {
            var results = new List<SearchResult>();

            foreach (Item item in Sitecore.Context.Database.GetItem("{06952217-C11F-441C-AF72-70CB5A289D3C}").Children)
            {
                results.Add(new SearchResult
                                {
                                    Title = item.Fields["Title"].Value,
                                    URL = item.Fields["URL"].Value
                                });
            }

            if (ifl.HasValue) return Redirect(results.FirstOrDefault().URL);
            else return this.View(results);
        }
    }
}