using CarBook.Application.Features.CQRS.Results.CarResults;
using CarBook.Application.Interfaces.CarInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandlers
{
	public class GetLast5CarsWithBrandQueryHandler
	{
		private readonly ICarRepository _carRepository;

		public GetLast5CarsWithBrandQueryHandler(ICarRepository carRepository)
		{
			_carRepository = carRepository;
		}

		public List<GetLast5CarsWithBrandQueryResult> Handle()
		{
			var values=_carRepository.GetLast5CarsWithBrands();
			return values.Select(x=> new GetLast5CarsWithBrandQueryResult
			{
                CarID = x.CarID,
                BrandName = x.Brand.Name,
				BrandID = x.BrandID,
				BigImageUrl = x.BigImageUrl,
				CoverImageUrl = x.CoverImageUrl,
				Fuel = x.Fuel,
				Km = x.Km,
				Luggage = x.Luggage,
				Model = x.Model,
				Seat = x.Seat,
				Transmission = x.Transmission
			}).ToList();
		}
	}
}
