﻿using CarBook.Application.Features.Mediator.Queries.RentACarQueries;
using CarBook.Application.Features.Mediator.Results.RentACarResults;
using CarBook.Application.Interfaces.RentACarInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.RentACarHandlers
{
	public class GetRentACarQueryHandler : IRequestHandler<GetRentACarQuery, List<GetRentACarQueryResult>>
	{
		private readonly IRentACarRepository _repository;

		public GetRentACarQueryHandler(IRentACarRepository repository)
		{
			_repository = repository;
		}

		public async Task<List<GetRentACarQueryResult>> Handle(GetRentACarQuery request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetByFilterAsync(x => x.LocationID == request.LocationID && x.Available == true);
			var results =  values.Select(x => new GetRentACarQueryResult
			{
				CarId = x.CarID,
                Brand = x.Car.Brand.Name,
                Model = x.Car.Model,
                CoverImageUrl = x.Car.CoverImageUrl
            }).ToList();
			return results;
		}
	}
}
