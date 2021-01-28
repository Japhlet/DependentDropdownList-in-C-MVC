using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DependentDropdownList.ViewModels
{
    public class CombinedVM
    {
		[Required(ErrorMessage = "Please enter a project name")]
		[Display(Name = "Project")]
		public string ProjectName { get; set; }
		[Required(ErrorMessage = "Please enter a developer name")]
		[Display(Name = "Developer")]
		public string DeveloperName { get; set; }

		[Required(ErrorMessage = "Please select a county")]
		[Display(Name = "County")]
		public int? selectedCounty { get; set; }
		[Required(ErrorMessage = "Please select a sub-county")]
		[Display(Name = "Sub County")]
		public int? selectedSubCounty { get; set; }
		[Required(ErrorMessage = "Please select a ward")]
		[Display(Name = "Ward")]
		public int? selectedWard { get; set; }
		public SelectList countyList { get; set; }
		public SelectList subCountyList { get; set; }
		public SelectList wardList { get; set; }
	}
}