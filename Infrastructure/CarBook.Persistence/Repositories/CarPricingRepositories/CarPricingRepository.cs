using CarBook.Application.Dtos;
using CarBook.Application.Interfaces.CarPricingInterfaces;
using CarBook.Application.ViewModels;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories.CarPricingRepositories
{
	public class CarPricingRepository : ICarPricingRepository
	{
		private readonly CarBookContext _context;

		public CarPricingRepository(CarBookContext context)
		{
			_context = context;
		}

		public List<CarPricing> GetCarPricingWithCars()
		{
			var values = _context.CarPricings.Include(x => x.Car).ThenInclude(y => y.Brand).Include(z => z.Pricing).Where(x=>x.PricingID==1).ToList();
			return values;
		}

		public List<CarPricingViewModel> GetCarPricingWithTimePeriod()
		{
			var carPricings = _context.CarPricings
		       .Include(cp => cp.Car)
			   .ThenInclude(c => c.Brand)
		       .Include(cp => cp.Pricing)
		       .ToList();

			var grouped = carPricings
				.GroupBy(cp => cp.CarID)
				.Select(g => new CarPricingViewModel
				{
					CarID = g.Key,
					BrandName = g.First().Car.Brand.Name,
					Model = g.First().Car.Model,
					CoverImageUrl = g.First().Car.CoverImageUrl,
					PricingDetails = g.Select(p => new PricingDetailDto
					{
						TimePeriodName = p.Pricing.Name,
						Amount = p.Amount
					}).ToList()
				}).ToList();

			return grouped;
		}
	}
}
