<<<<<<< HEAD
﻿using CoreWiki.ViewModels;
using CoreWiki.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
=======
﻿using CoreWiki.Data;
using CoreWiki.Data.Data.Interfaces;
using CoreWiki.Data.Data.Repositories;
using CoreWiki.Data.Models;
using CoreWiki.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NodaTime;
>>>>>>> upstream/master
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
<<<<<<< HEAD
using MediatR;
using AutoMapper;
using CoreWiki.Application.Articles.Managing.Commands;
using CoreWiki.Application.Articles.Managing.Exceptions;
using CoreWiki.Application.Articles.Managing.Queries;
using CoreWiki.Application.Common;
using Microsoft.AspNetCore.Authorization;
using CoreWiki.Areas.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity;
using CoreWiki.Data.EntityFramework.Security;
=======
>>>>>>> upstream/master

namespace CoreWiki.Pages
{

<<<<<<< HEAD
	[Authorize(Policy = PolicyConstants.CanEditArticles)]
	public class EditModel : PageModel
	{

		private readonly IMediator _mediator;
		private readonly IMapper _mapper;
		private readonly ILogger _Logger;
		private readonly UserManager<CoreWikiUser> _UserManager;

		public EditModel(IMediator mediator, IMapper mapper, ILoggerFactory loggerFactory, UserManager<CoreWikiUser> userManager)
		{
			_mediator = mediator;
			_mapper = mapper;
			_Logger = loggerFactory.CreateLogger("EditPage");
			_UserManager = userManager;
		}

		[BindProperty]
		public ArticleEdit Article { get; set; }
=======
	public class EditModel : PageModel
	{

		private readonly IArticleRepository _Repo;
		private readonly ISlugHistoryRepository _SlugRepo;
		private readonly IClock _clock;

		public EditModel(IArticleRepository articleRepo, ISlugHistoryRepository slugHistoryRepository, IClock clock)
		{
			_Repo = articleRepo;
			_SlugRepo = slugHistoryRepository;
			_clock = clock;
		}

		[BindProperty]
		public Article Article { get; set; }
>>>>>>> upstream/master

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
				return new ArticleNotFoundResult();
			}

			Article = _mapper.Map<ArticleEdit>(article);

			return Page();

=======
			Article = await _Repo.GetArticleBySlug(slug);

			if (Article == null)
			{
				return new ArticleNotFoundResult();
			}
			return Page();
>>>>>>> upstream/master
		}

		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid)
			{
				return Page();
			}

<<<<<<< HEAD
			var cmd = _mapper.Map<EditArticleCommand>(Article);
			var cwUser = await _UserManager.GetUserAsync(User);
			cmd = _mapper.Map(cwUser, cmd);

			var result = await _mediator.Send(cmd);

			if (result.Exception is InvalidTopicException)
			{
				ModelState.AddModelError("Article.Topic", result.Exception.Message);
				return Page();
			}
			else if (result.Exception is ArticleNotFoundException)
			{
				return new ArticleNotFoundResult();
			}

			// var query = new GetArticlesToCreateFromArticleQuery(Article.Id);
			// var listOfSlugs = await _mediator.Send(query);

			// _Logger.LogWarning($"Found the following links to create: {string.Join(',', listOfSlugs.Item2) }");
			// _Logger.LogWarning($"Routing for slug: {listOfSlugs.Item1}");

			// if (listOfSlugs.Item2.Any())
			// {
			// 	return RedirectToPage("CreateArticleFromLink", new { id = listOfSlugs.Item1 });
			// }

			_Logger.LogWarning($"Routing for the slug: {result.ObjectId}");

			return RedirectToPage("Details", new { Slug = (result.ObjectId == Constants.HomePageSlug ? "" : result.ObjectId) });

		}


=======
			var existingArticle = await _Repo.GetArticleById(Article.Id);
			Article.ViewCount = existingArticle.ViewCount;
			Article.Version = existingArticle.Version + 1;

			//check if the slug already exists in the database.
			var slug = UrlHelpers.URLFriendly(Article.Topic);
			if (String.IsNullOrWhiteSpace(slug))
			{
				ModelState.AddModelError("Article.Topic", "The Topic must contain at least one alphanumeric character.");
				return Page();
			}

			if (!await _Repo.IsTopicAvailable(slug, Article.Id))
			{
				ModelState.AddModelError("Article.Topic", "This Title already exists.");
				return Page();
			}

			var articlesToCreateFromLinks = (await ArticleHelpers.GetArticlesToCreate(_Repo, Article, createSlug: true))
				.ToList();

			Article.Published = _clock.GetCurrentInstant();
			Article.Slug = slug;
			Article.AuthorId = Guid.Parse(this.User.FindFirstValue(ClaimTypes.NameIdentifier));
			Article.AuthorName = User.Identity.Name;

			if (!string.Equals(Article.Slug, existingArticle.Slug, StringComparison.InvariantCulture))
			{
				await _SlugRepo.AddToHistory(existingArticle.Slug, Article);
			}

			//AddNewArticleVersion();

			try {
				await _Repo.Update(Article);
			} catch (ArticleNotFoundException) {
				return new ArticleNotFoundResult();
			}

			if (articlesToCreateFromLinks.Count > 0)
			{
				return RedirectToPage("CreateArticleFromLink", new { id = slug });
			}

			return Redirect($"/{(Article.Slug == "home-page" ? "" : Article.Slug)}");
		}

	
>>>>>>> upstream/master
	}

}
