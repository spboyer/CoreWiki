<<<<<<< HEAD
﻿using CoreWiki.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using CoreWiki.Application.Articles.Managing.Commands;
using CoreWiki.Application.Articles.Managing.Events;
using CoreWiki.Application.Articles.Managing.Queries;
using CoreWiki.Application.Common;
=======
﻿using CoreWiki.Data;
using CoreWiki.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
>>>>>>> upstream/master

namespace CoreWiki.Pages
{
	[Authorize("CanDeleteArticles")]

	public class DeleteModel : PageModel
	{
<<<<<<< HEAD
		private readonly IMediator _mediator;
		private readonly IMapper _mapper;

		public DeleteModel(IMediator mediator, IMapper mapper)
		{
			_mediator = mediator;
			_mapper = mapper;
		}

		[BindProperty]
		public ArticleDelete Article { get; set; }
=======
		private readonly ApplicationDbContext _context;

		public DeleteModel(ApplicationDbContext context)
		{
			_context = context;
		}

		[BindProperty]
		public Article Article { get; set; }
>>>>>>> upstream/master

		///  TODO: Make it so you cannot delete the home page (deleting the home page will cause a 404)
		///  or re-factor to make the home page dynamic or configurable.
		public async Task<IActionResult> OnGetAsync(string slug)
		{
			if (slug == null)
			{
				return NotFound();
			}

<<<<<<< HEAD
			var article = await _mediator.Send(new GetArticleQuery(slug));

			if (article == null)
			{
				return NotFound();
			}

			if (article.IsHomePage)
			{
				await _mediator.Publish(new DeleteHomePageAttemptNotification());
				return Forbid();
			}

			Article = _mapper.Map<ArticleDelete>(article);

=======
			Article = await _context.Articles.SingleOrDefaultAsync(m => m.Slug == slug);

			if (Article == null)
			{
				return NotFound();
			}
>>>>>>> upstream/master
			return Page();
		}

		public async Task<IActionResult> OnPostAsync(string slug)
		{
			if (slug == null)
			{
				return NotFound();
			}

<<<<<<< HEAD
			var result = await _mediator.Send(new DeleteArticleCommand(slug));
			return RedirectToPage("Details", new {slug=Constants.HomePageSlug });
=======
			Article = await _context.Articles.SingleOrDefaultAsync(m => m.Slug == slug);

			if (Article != null)
			{
				_context.Articles.Remove(Article);
				await _context.SaveChangesAsync();
			}

			return RedirectToPage("/All");
>>>>>>> upstream/master
		}
	}
}
