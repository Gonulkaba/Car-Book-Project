using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Dtos
{
	public class PricingDetailDto
	{
		public string TimePeriodName { get; set; } // Saatlik, Günlük, Aylık, Haftalık vs.
		public decimal Amount { get; set; }
	}
}
