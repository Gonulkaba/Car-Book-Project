using CarBook.Application.Dtos;
using CarBook.Application.Features.Mediator.Queries.CarPricingQueries;
using CarBook.Application.Features.Mediator.Results.CarPricingResults;
using CarBook.Application.Interfaces;
using CarBook.Application.Interfaces.CarPricingInterfaces;
using CarBook.Application.ViewModels;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.CarPricingHandlers
{
	public class GetCarPricingWithTimePeriodHandler : IRequestHandler<GetCarPricingWithTimePeriodQuery, List<GetCarPricingWithTimePeriodQueryResult>>
	{
		private readonly ICarPricingRepository _repository;

		public GetCarPricingWithTimePeriodHandler(ICarPricingRepository repository)
		{
			_repository = repository;
		}

		public async Task<List<GetCarPricingWithTimePeriodQueryResult>> Handle(GetCarPricingWithTimePeriodQuery request, CancellationToken cancellationToken)
		{
			var pricingViewModels = _repository.GetCarPricingWithTimePeriod();

			var result = pricingViewModels.Select(x => new GetCarPricingWithTimePeriodQueryResult
			{
				CarID = x.CarID,
				BrandName = x.BrandName,
				Model = x.Model,
				CoverImageUrl = x.CoverImageUrl,
				PricingDetails = x.PricingDetails
					.Select(d => new PricingDetailDto
					{
						TimePeriodName = d.TimePeriodName,
						Amount = d.Amount
					}).ToList()
			}).ToList();

			return result;
		}
	}
}
