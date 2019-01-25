<<<<<<< HEAD
using CoreWiki.ViewModels;
using CoreWiki.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using CoreWiki.Application.Articles.Reading.Commands;
using CoreWiki.Application.Articles.Reading.Queries;
using CoreWiki.Application.Common;
=======
using CoreWiki.Data.Data.Interfaces;
using CoreWiki.Data.Models;
using CoreWiki.Data.Security;
using CoreWiki.Helpers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using NodaTime;
using System;
using System.Threading.Tasks;
using CoreWiki.Core.Notifications;
>>>>>>> upstream/master

namespace CoreWiki.Pages
{
	public class DetailsModel : PageModel
	{
<<<<<<< HEAD
		private readonly IMediator _mediator;
		private readonly IMapper _mapper;

		public DetailsModel(IMediator mediator, IMapper mapper)
		{
			_mediator = mediator;
			_mapper = mapper;
=======
		private readonly IArticleRepository _articleRepo;
		private readonly ICommentRepository _commentRepo;
		private readonly ISlugHistoryRepository _slugHistoryRepo;
		private readonly IClock _clock;
		private readonly UserManager<CoreWikiUser> _UserManager;
		private readonly INotificationService _notificationService;

		public IConfiguration Configuration { get; }
		public IEmailSender Notifier { get; }

		public DetailsModel(
			IArticleRepository articleRepo,
			ICommentRepository commentRepo,
			ISlugHistoryRepository slugHistoryRepo,
			UserManager<CoreWikiUser> userManager,
			IConfiguration config,
			INotificationService notificationService,
			IClock clock)
		{
			_articleRepo = articleRepo;
			_commentRepo = commentRepo;
			_slugHistoryRepo = slugHistoryRepo;
			_clock = clock;
			_UserManager = userManager;
			_notificationService = notificationService;
			Configuration = config;
>>>>>>> upstream/master
		}

		public ArticleDetails Article { get; set; }

<<<<<<< HEAD
		[ViewData]
=======
		[ViewDataAttribute]
>>>>>>> upstream/master
		public string Slug { get; set; }

		public async Task<IActionResult> OnGetAsync(string slug)
		{
			slug = slug ?? Constants.HomePageSlug;
			var article = await _mediator.Send(new GetArticleQuery(slug));

			if (article == null)
			{
				var historical = await _mediator.Send(new GetSlugHistoryQuery(slug));

				if (historical != null)
				{
					return Redirect(historical.Article.Slug);
				}

				return new ArticleNotFoundResult(slug);
			}

<<<<<<< HEAD
			Article = _mapper.Map<ArticleDetails>(article); 

			ManageViewCount(slug);
=======
			slug = slug ?? "home-page";
			Article = await _articleRepo.GetArticleBySlug(slug);
>>>>>>> upstream/master

			return Page();
		}

		private void ManageViewCount(string slug)
		{
			var incrementViewCount = (Request.Cookies[slug] == null);
			if (!incrementViewCount)
			{
<<<<<<< HEAD
				return;
			}

			Article.ViewCount++;
			Response.Cookies.Append(slug, "foo", new Microsoft.AspNetCore.Http.CookieOptions
			{
				Expires = DateTime.UtcNow.AddMinutes(5)
			});

			_mediator.Send(new IncrementViewCountCommand(slug));
		}

		public async Task<IActionResult> OnPostAsync(Comment model)
		{
			TryValidateModel(model);

			if (!ModelState.IsValid)
				return Page();

			var article = await _mediator.Send(new GetArticleByIdQuery(model.ArticleId));

			if (article == null)
			{
				return new ArticleNotFoundResult();
			}

			var commentCmd = _mapper.Map<CreateNewCommentCommand>(model);
				commentCmd = _mapper.Map(User, commentCmd);

			await _mediator.Send(commentCmd);

			return Redirect(article.Slug);
=======
				Slug = slug;
				var historical = await _slugHistoryRepo.GetSlugHistoryWithArticle(slug);

				if (historical != null)
				{
					return new RedirectResult($"~/{historical.Article.Slug}");
				}
				else
				{
					return new ArticleNotFoundResult(slug);
				}
			}

			if (Request.Cookies[Article.Topic] == null)
			{
				Article.ViewCount++;
				Response.Cookies.Append(Article.Topic, "foo", new Microsoft.AspNetCore.Http.CookieOptions
				{
					Expires = DateTime.UtcNow.AddMinutes(5)
				});
			}

			return Page();
>>>>>>> upstream/master
		}

		public async Task<IActionResult> OnPostAsync(Comment comment)
		{
			TryValidateModel(comment);
			Article = await _articleRepo.GetArticleByComment(comment);
			if (Article == null)
				return new ArticleNotFoundResult();

			if (!ModelState.IsValid)
				return Page();

			comment.Article = Article;

			comment.Submitted = _clock.GetCurrentInstant();

			var author = await _UserManager.FindByIdAsync(Article.AuthorId.ToString());
			await _commentRepo.CreateComment(comment);

			// TODO: Also check for verified email if required
			await _notificationService.SendNewCommentEmail(author.Email, author.UserName, comment.DisplayName, Article.Topic, Article.Slug, () => author.CanNotify);

			return Redirect($"/{Article.Slug}");
		}
	}
}
