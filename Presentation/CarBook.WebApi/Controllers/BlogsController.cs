﻿using CarBook.Application.Features.Mediator.Commands.BlogCommands;
using CarBook.Application.Features.Mediator.Queries.BlogQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BlogsController : ControllerBase
	{
		private readonly IMediator _mediator;

		public BlogsController(IMediator mediator)
		{
			_mediator = mediator;
		}
		[HttpGet]
		public async Task<IActionResult> BlogList()
		{
			var values = await _mediator.Send(new GetBlogQuery());
			return Ok(values);
		}
		[HttpGet("{id}")]
		public async Task<IActionResult> GetBlog(int id)
		{
			var value = await _mediator.Send(new GetBlogByIdQuery(id));
			return Ok(value);
		}
		[HttpPost]
		public async Task<IActionResult> CreateBlog(CreateBlogCommand command)
		{
			await _mediator.Send(command);
			return Ok();
		}
		[HttpDelete("{id}")]
		public async Task<IActionResult> RemoveBlog(int id)
		{
			await _mediator.Send(new RemoveBlogCommand(id));
			return Ok();
		}
		[HttpPut]
		public async Task<IActionResult> UpdateBlog(UpdateBlogCommand command)
		{
			await _mediator.Send(command);
			return Ok();
		}

        [HttpGet("GetLast3BlogWithAuthorsList")]
        public async Task<IActionResult> GetLast3BlogWithAuthorsList()
        {
            var value = await _mediator.Send(new GetLast3BlogsWithAuthorsQuery());
            return Ok(value);
        }

        [HttpGet("GetAllBlogsWithAuthorList")]
        public async Task<IActionResult> GetAllBlogsWithAuthorList()
        {
            var value = await _mediator.Send(new GetAllBlogsWithAuthorQuery());
            return Ok(value);
        }

        [HttpGet("GetBlogByAuthorId")]
        public async Task<IActionResult> GetBlogByAuthorId(int id)
        {
            var value = await _mediator.Send(new GetBlogByAuthorIdQuery(id));
            return Ok(value);
        }
    }
}
