<<<<<<< HEAD
using CoreWiki.Areas.Identity;
using CoreWiki.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
=======
﻿using CoreWiki.Data;
using CoreWiki.Data.Data.Interfaces;
using CoreWiki.Data.Models;
using CoreWiki.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using NodaTime;
>>>>>>> upstream/master
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
<<<<<<< HEAD
using AutoMapper;
using CoreWiki.Application.Articles.Managing.Commands;
using CoreWiki.Application.Articles.Managing.Queries;
using CoreWiki.Application.Common;
using CoreWiki.Helpers;
using Microsoft.AspNetCore.Identity;
using CoreWiki.Data.EntityFramework.Security;

namespace CoreWiki.Pages
{

	[Authorize(Policy = PolicyConstants.CanWriteArticles)]
	public class CreateModel : PageModel
	{
		private readonly IMediator _mediator;
		private readonly IMapper _mapper;
		private readonly ILogger _logger;
		private readonly UserManager<CoreWikiUser> _userManager;

		public CreateModel(IMediator mediator, IMapper mapper, ILoggerFactory loggerFactory, UserManager<CoreWikiUser> userManager)
		{
			_mediator = mediator;
			_mapper = mapper;
			_logger = loggerFactory.CreateLogger("CreatePage");
			_userManager = userManager;
		}

		public async Task<IActionResult> OnGetAsync(string slug = "")
=======

namespace CoreWiki.Pages
{
	public class CreateModel : PageModel
	{

		private readonly IArticleRepository _articleRepo;
		private readonly IClock _clock;

		public ILogger Logger { get; private set; }

		public CreateModel(IArticleRepository articleRepo, IClock clock, ILoggerFactory loggerFactory)
		{
			_articleRepo = articleRepo;
			_clock = clock;
			this.Logger = loggerFactory.CreateLogger("CreatePage");
		}

		public async Task<IActionResult> OnGetAsync(string slug)
>>>>>>> upstream/master
		{
			if (string.IsNullOrEmpty(slug))
			{
				return Page();
			}

<<<<<<< HEAD
			var request = new GetArticleQuery(slug);
			var result = await _mediator.Send(request);
			if (result == null)
			{
				Article = new ArticleCreate
				{
					Topic = UrlHelpers.SlugToTopic(slug)
				};
			}
			else
			{
				// TODO: Convert this to use a PageRoute
				return Redirect($"/{slug}/Edit");
			}

=======
			if (await _articleRepo.GetArticleBySlug(slug) != null)
			{
				return Redirect($"/{slug}/Edit");
			}

			Article = new Article()
			{
				Topic = UrlHelpers.SlugToTopic(slug)
			};

>>>>>>> upstream/master
			return Page();
		}

		[BindProperty]
<<<<<<< HEAD
		public ArticleCreate Article { get; set; }

		public async Task<IActionResult> OnPostAsync()
		{
			//var slug = UrlHelpers.URLFriendly(Article.Topic);
			if (string.IsNullOrWhiteSpace(Article.Topic))
=======
		public Article Article { get; set; }

		public async Task<IActionResult> OnPostAsync()
		{

			var slug = UrlHelpers.URLFriendly(Article.Topic);
			if (string.IsNullOrWhiteSpace(slug))
>>>>>>> upstream/master
			{
				ModelState.AddModelError("Article.Topic", "The Topic must contain at least one alphanumeric character.");
				return Page();
			}

<<<<<<< HEAD
			if (!ModelState.IsValid) { return Page(); }

			_logger.LogWarning($"Creating page with topic: {Article.Topic}");

			var isTopicAvailable = new GetIsTopicAvailableQuery {Topic = Article.Topic, ArticleId = 0};
			if (await _mediator.Send(isTopicAvailable))
=======
			Article.Slug = slug;
			Article.AuthorId = Guid.Parse(this.User.FindFirstValue(ClaimTypes.NameIdentifier));

			if (!ModelState.IsValid)
			{
				return Page();
			}

			//check if the slug already exists in the database.
			Logger.LogWarning($"Creating page with slug: {slug}");

			if (await _articleRepo.IsTopicAvailable(slug, 0))
>>>>>>> upstream/master
			{
				ModelState.AddModelError("Article.Topic", "This Title already exists.");
				return Page();
			}

<<<<<<< HEAD
			var cmd = _mapper.Map<CreateNewArticleCommand>(Article);
			var cwUser = await _userManager.GetUserAsync(User);
			cmd = _mapper.Map(cwUser, cmd);

			var cmdResult = await _mediator.Send(cmd);

			// TODO: Inspect result to ensure it ran properly

			// var query = new GetArticlesToCreateFromArticleQuery(cmdResult.ObjectId);
			// var listOfSlugs = await _mediator.Send(query);

			// if (listOfSlugs.Item2.Any())
			// {
			// 	return RedirectToPage("CreateArticleFromLink", new { id = listOfSlugs.Item1 });
			// }

			return RedirectToPage("Details", new {slug=cmdResult.ObjectId.ToString()});

=======
			Article.Published = _clock.GetCurrentInstant();
			// Article.Slug = slug;

			Article = await _articleRepo.CreateArticleAndHistory(Article);


			var articlesToCreateFromLinks = (await ArticleHelpers.GetArticlesToCreate(_articleRepo, Article, createSlug: true))
				.ToList();

			if (articlesToCreateFromLinks.Count > 0)
			{
				return RedirectToPage("CreateArticleFromLink", new { id = slug });
			}

			return Redirect($"/{Article.Slug}");
>>>>>>> upstream/master
		}
	}
}
