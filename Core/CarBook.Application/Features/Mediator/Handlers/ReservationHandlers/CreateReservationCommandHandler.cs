using CarBook.Application.Features.Mediator.Commands.ReservationCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.ReservationHandlers
{
	public class CreateReservationCommandHandler : IRequestHandler<CreateReservationCommand>
	{
		private readonly IRepository<Reservation> _repository;

		public CreateReservationCommandHandler(IRepository<Reservation> repository)
		{
			_repository = repository;
		}

		public async Task Handle(CreateReservationCommand request, CancellationToken cancellationToken)
		{
			await _repository.CreateAsync(new Reservation
			{
				Name = request.Name,
				Surname = request.Surname,
				Age = request.Age,
				Phone = request.Phone,
				CarID = request.CarID,
				Email = request.Email,
				DriverLicenseYear = request.DriverLicenseYear,
				DropOffLocationID = request.DropOffLocationID,
				PickUpLocationID = request.PickUpLocationID,
				Description = request.Description,
				Status = "Rezervasyon Alındı"
			}); ;
		}
	}
}
