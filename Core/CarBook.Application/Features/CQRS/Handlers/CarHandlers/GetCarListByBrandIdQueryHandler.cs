using CarBook.Application.Features.CQRS.Queries.CarQueries;
using CarBook.Application.Features.CQRS.Results.CarResults;
using CarBook.Application.Interfaces.CarInterfaces;
using CarBook.Domain.Entities;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetCarListByBrandIdQueryHandler
    {
        private readonly ICarRepository _repository;

    public GetCarListByBrandIdQueryHandler(ICarRepository brandRepository)
    {
            _repository = brandRepository;
    }
        public async Task<List<GetCarListByBrandIdQueryResult>> Handle(GetCarListByBrandIdQuery query)
        {
            var values = _repository.GetCarListByBrandId(query.Id);
            return values.Select(x => new GetCarListByBrandIdQueryResult
            {
                BrandId = x.BrandID,
                BrandName = x.Brand.Name,
                CarId = x.CarID,
                Model = x.Model,
                CoverImageUrl = x.CoverImageUrl,
                Km = x.Km,
                Transmission = x.Transmission,
                Seat = x.Seat,
                Luggage = x.Luggage,
                Fuel = x.Fuel
            }).ToList();
        }
    }
}
