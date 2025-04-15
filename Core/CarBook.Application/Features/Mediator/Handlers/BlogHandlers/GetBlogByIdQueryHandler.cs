﻿using CarBook.Application.Features.Mediator.Queries.BlogQueries;
using CarBook.Application.Features.Mediator.Results.BlogResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.BlogHandlers
{
	public class GetBlogByIdQueryHandler : IRequestHandler<GetBlogByIdQuery, GetBlogByIdQueryResult>
	{
		private readonly IRepository<Blog> _repository;

		public GetBlogByIdQueryHandler(IRepository<Blog> repository)
		{
			_repository = repository;
		}

		public async Task<GetBlogByIdQueryResult> Handle(GetBlogByIdQuery request, CancellationToken cancellationToken)
		{
			var value = await _repository.GetByIdAsync(request.Id);
			return new GetBlogByIdQueryResult
			{
                BlogID = value.BlogID,
                AuthorID = value.AuthorID,
				CategoryID = value.CategoryID,
				CoverImageUrl = value.CoverImageUrl,
				CreatedDate = value.CreatedDate,
				Title = value.Title,
			};
		}
	}
}
