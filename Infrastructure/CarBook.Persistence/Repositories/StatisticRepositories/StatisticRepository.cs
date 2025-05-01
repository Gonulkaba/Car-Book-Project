using CarBook.Application.Interfaces.StatisticsInterfaces;
using CarBook.Persistence.Context;

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
            throw new NotImplementedException();
        }

        public string GetBlogTitleByMaxBlogComment()
		{
            throw new NotImplementedException();
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

            throw new NotImplementedException();
		}

		public string GetCarBrandAndModelByRentPriceDailyMin()
		{
            throw new NotImplementedException();
        }
	}
}
