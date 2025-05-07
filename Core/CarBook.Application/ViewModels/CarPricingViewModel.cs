using CarBook.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.ViewModels
{
	public class CarPricingViewModel
	{
		public int CarID { get; set; }
		public string BrandName { get; set; }
		public string Model { get; set; }
		public string CoverImageUrl { get; set; }
		public List<PricingDetailDto> PricingDetails { get; set; }
	}
}
