﻿using CarBook.Application.Features.Mediator.Queries.BlogQueries;
using CarBook.Application.Features.Mediator.Results.BlogResults;
using CarBook.Application.Interfaces.BlogInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.BlogHandlers
{
	public class GetBlogByAuthorIdQueryHandler : IRequestHandler<GetBlogByAuthorIdQuery, List<GetBlogByAuthorIdQueryResult>>
	{
		private readonly IBlogRepository _repository;

		public GetBlogByAuthorIdQueryHandler(IBlogRepository repository)
		{
			_repository = repository;
		}

		public async Task<List<GetBlogByAuthorIdQueryResult>> Handle(GetBlogByAuthorIdQuery request, CancellationToken cancellationToken)
		{
			var value = _repository.GetBlogByAuthorId(request.Id);
			return value.Select(x => new GetBlogByAuthorIdQueryResult
			{
				AuthorID = x.AuthorID,
				AuthorName = x.Author.Name,
				AuthorDescription = x.Author.Description,
				AuthorImageUrl = x.Author.ImageUrl,
				BlogID = x.BlogID
			}).ToList();
		}
	}
}
