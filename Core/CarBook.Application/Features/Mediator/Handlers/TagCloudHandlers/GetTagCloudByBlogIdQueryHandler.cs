﻿using CarBook.Application.Features.Mediator.Queries.TagCloudQueries;
using CarBook.Application.Features.Mediator.Results.TagCloudResults;
using CarBook.Application.Interfaces.TagCloudInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace CarBook.Application.Features.Mediator.Handlers.TagCloudHandlers
{
	public class GetTagCloudByBlogIdQueryHandler : IRequestHandler<GetTagCloudByBlogIdQuery, List<GetTagCloudByBlogIdQueryResult>>
	{
		private readonly ITagCloudRepository _repository;

		public GetTagCloudByBlogIdQueryHandler(ITagCloudRepository repository)
		{
			_repository = repository;
		}

		public async Task<List<GetTagCloudByBlogIdQueryResult>> Handle(GetTagCloudByBlogIdQuery request, CancellationToken cancellationToken)
		{
			var value = _repository.GetTagCloudsByBlogID(request.Id);
			return value.Select(x => new GetTagCloudByBlogIdQueryResult
			{
				Title = x.Title,
				BlogID = x.BlogID,
				TagCloudID = x.TagCloudID
			}).ToList();
		}
	}
}
