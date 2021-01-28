using DependentDropdownList.Models;
using DependentDropdownList.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DependentDropdownList.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

		[HttpGet]
		public ActionResult Index()
		{
			CombinedVM model = new CombinedVM();
			//model.SelectedCity = 2;
			//model.SelectedLocality = 3;
			//model.SelectedSubLocality = 6;
			ConfigureViewModel(model);
			return View(model);
		}

		[HttpPost]
		public ActionResult Index(CombinedVM model)
		{
			if (!ModelState.IsValid)
			{
				ConfigureViewModel(model);
				return View(model);
			}
			// save and redirect
			return RedirectToAction("Somewhere");
		}

		[HttpGet]
		public JsonResult FetchSubCounties(int ID)
		{
			var data = Repository.fetchSubCounties()
				.Where(l => l.countyId == ID)
				.Select(l => new { Value = l.ID, Text = l.name });
			return Json(data, JsonRequestBehavior.AllowGet);
		}

		[HttpGet]
		public JsonResult FetchWards(int ID)
		{
			//int subCountyID = Repository.fetchSubCounties().Where(l => l.ID == ID).Select(l => l.LocalityID).First();
			var data = Repository.fetchWards()
				.Where(l => l.subCountyId == ID)
				.Select(l => new { Value = l.ID, Text = l.name });
			return Json(data, JsonRequestBehavior.AllowGet);
		}

		private void ConfigureViewModel(CombinedVM model)
		{
			List<County> counties = Repository.fetchCounties();
			model.countyList = new SelectList(counties, "ID", "name");
			if (model.selectedCounty.HasValue)
			{
				IEnumerable<SubCounty> localities = Repository.fetchSubCounties().Where(l => l.countyId == model.selectedCounty.Value);
				model.subCountyList = new SelectList(localities, "ID", "name");
			}
			else
			{
				model.subCountyList = new SelectList(Enumerable.Empty<SelectListItem>());
			}
			if (model.selectedSubCounty.HasValue)
			{
				IEnumerable<Ward> subLocalities = Repository.fetchWards().Where(l => l.subCountyId == model.selectedSubCounty.Value);
				model.wardList = new SelectList(subLocalities, "ID", "name");
			}
			else
			{
				model.wardList = new SelectList(Enumerable.Empty<SelectListItem>());
			}
		}
	}
}
