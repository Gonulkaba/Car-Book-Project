using CarBook.Application.Interfaces.StatisticsInterfaces;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace CarBook.Persistence.Repositories.StatisticRepositories
{
	public class StatisticRepository : IStatisticRepository
	{
		private readonly CarBookContext _context;

		public StatisticRepository(CarBookContext context)
		{
			_context = context;
		}

        public int GetCarCount()
        {
            var value = _context.Cars.Count();
            return value;
        }
        public int GetLocationCount()
        {
            var value = _context.Locations.Count();
            return value;
        }
        public int GetAuthorCount()
        {
            var value = _context.Authors.Count();
            return value;
        }
        public int GetBlogCount()
        {
            var value = _context.Blogs.Count();
            return value;
        }
        public int GetBrandCount()
        {
            var value = _context.Brands.Count();
            return value;
        }
        public decimal GetAvgRentPriceForDaily()
        {
			//Select Avg(Amount) from CarPricings where PricingID= (Select PricingID From Pricings Where Name = 'Günlük')
            int id = _context.Pricings.Where(y => y.Name == "Günlük").Select(z => z.PricingID).FirstOrDefault();
            var value = _context.CarPricings.Where(w => w.PricingID == id).Average(x => x.Amount);
            return value;
        }
        public decimal GetAvgRentPriceForMonthly()
        {
            int id = _context.Pricings.Where(y => y.Name == "Aylık").Select(z => z.PricingID).FirstOrDefault();
            var value = _context.CarPricings.Where(w => w.PricingID == id).Average(x => x.Amount);
            return value;
        }

        public decimal GetAvgRentPriceForWeekly()
        {
            int id = _context.Pricings.Where(y => y.Name == "Haftalık").Select(z => z.PricingID).FirstOrDefault();
            var value = _context.CarPricings.Where(w => w.PricingID == id).Average(x => x.Amount);
            return value;
        }
        public int GetCarCountByTransmissionIsAuto()
        {
            var value = _context.Cars.Where(x => x.Transmission == "Otomatik").Count();
            return value;
        }
        public int GetCarCountByKmSmallerThan1000()
        {
            var value = _context.Cars.Where(x => x.Km < 1000).Count();
            return value;
        }
        public int GetCarCountByFuelGasolineOrDiesel()
        {
            var value = _context.Cars.Where(x => x.Fuel == "Benzin" || x.Fuel == "Dizel").Count();
            return value;
        }
        public int GetCarCountByFuelElectric()
        {
            var value = _context.Cars.Where(x => x.Fuel == "Elektrik").Count();
            return value;
        }

        public string GetBrandNameByMaxCar()
        {
            //SELECT TOP 1 Brand.Name, COUNT(*) AS AracSayisi FROM Cars JOIN Brand ON Cars.BrandID = Brand.BrandID GROUP BY Brand.Name ORDER BY AracSayisi DESC;
            var values = _context.Cars.GroupBy(x => x.BrandID).Select(y => new { BrandId = y.Key, Count = y.Count() })
                                    .OrderByDescending(z => z.Count).Take(1).FirstOrDefault();
            string brandName = _context.Brands.Where(x => x.BrandID == values.BrandId).Select(y => y.Name).FirstOrDefault();
            return brandName;
        }

        public string GetBlogTitleByMaxBlogComment()
		{
            /*SELECT TOP 1 b.BlogID, b.Title, COUNT(c.CommentID) AS YorumSayisi FROM Blogs b
              LEFT JOIN Comments c ON b.BlogID = c.BlogId
              GROUP BY b.BlogID, b.Title
              ORDER BY YorumSayisi DESC;*/
            var values = _context.Comments.GroupBy(x => x.BlogId).Select(y => new { BlogId = y.Key, Count = y.Count() })
                                    .OrderByDescending(z => z.Count).Take(1).FirstOrDefault();
            string blogName = _context.Blogs.Where(x => x.BlogID == values.BlogId).Select(y => y.Title).FirstOrDefault();
            return blogName;
        }
		public string GetCarBrandAndModelByRentPriceDailyMax()
		{
            /*  SELECT Model, CarPricings.CarID, Amount
                FROM CarPricings Inner Join Cars On CarPricings.CarId = Cars.CarID
                WHERE PricingID = (SELECT PricingID FROM Pricings WHERE Name = 'Günlük')
                AND Amount = (
                  SELECT MAX(Amount)
                  FROM CarPricings
                  WHERE PricingID = (SELECT PricingID FROM Pricings WHERE Name = 'Günlük'));*/

            int pricingId = _context.Pricings.Where(x => x.Name == "Günlük").Select(y => y.PricingID).FirstOrDefault();
            decimal amount = _context.CarPricings.Where(y => y.PricingID == pricingId).Max(x => x.Amount);
            var brandModel = _context.CarPricings.Where(cp => cp.PricingID == pricingId && cp.Amount == amount)
                 .Include(cp => cp.Car).ThenInclude(c => c.Brand).Select(cp => cp.Car.Brand.Name + " " + cp.Car.Model).FirstOrDefault();
            return brandModel;
        }

		public string GetCarBrandAndModelByRentPriceDailyMin()
		{
            int pricingId = _context.Pricings.Where(x => x.Name == "Günlük").Select(y => y.PricingID).FirstOrDefault();
            decimal amount = _context.CarPricings.Where(y => y.PricingID == pricingId).Min(x => x.Amount);
            var brandModel = _context.CarPricings.Where(cp => cp.PricingID == pricingId && cp.Amount == amount)
                 .Include(cp => cp.Car).ThenInclude(c => c.Brand).Select(cp => cp.Car.Brand.Name + " " + cp.Car.Model).FirstOrDefault();
            return brandModel;
        }
	}
}
