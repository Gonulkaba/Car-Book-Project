﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Dto.CarPricingDtos
{
	public class ResultCarPricingListWithTimePeriodDto
	{
		public int CarID { get; set; }
		public string Model { get; set; }
		public string BrandName { get; set; }
		public string CoverImageUrl { get; set; }
		public List<PricingDetailDto> pricingDetails { get; set; }
	}
}
