using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DependentDropdownList.Models
{
    public class Repository
    {
		public static List<County> fetchCounties()
		{
			List<County> counties = new List<County>();
			counties.Add(new County() { ID = 040, name = "Busia" });
			counties.Add(new County() { ID = 047, name = "Nairobi" });
			return counties;
		}
		public static List<SubCounty> fetchSubCounties()
		{
			List<SubCounty> subCounties = new List<SubCounty>();
			subCounties.Add(new SubCounty() { ID = 1, countyId = 040, name = "Teso North" });
			subCounties.Add(new SubCounty() { ID = 2, countyId = 040, name = "Teso South" });
			subCounties.Add(new SubCounty() { ID = 3, countyId = 047, name = "Kasarani" });
			subCounties.Add(new SubCounty() { ID = 4, countyId = 047, name = "Rwaraka" });
			return subCounties;
		}
		public static List<Ward> fetchWards()
		{
			List<Ward> wards = new List<Ward>();
			wards.Add(new Ward() { ID = 1, subCountyId = 1, name = "Angurai East" });
			wards.Add(new Ward() { ID = 2, subCountyId = 1, name = "Angurai North" });
			wards.Add(new Ward() { ID = 3, subCountyId = 2, name = "Aterait" });
			wards.Add(new Ward() { ID = 4, subCountyId = 2, name = "Lukolis" });
			wards.Add(new Ward() { ID = 5, subCountyId = 3, name = "Clay City" });
			wards.Add(new Ward() { ID = 6, subCountyId = 3, name = "Roysambu" });
			wards.Add(new Ward() { ID = 7, subCountyId = 4, name = "Allsops" });
			wards.Add(new Ward() { ID = 8, subCountyId = 4, name = "NYS" });
			return wards;
		}
	}
}