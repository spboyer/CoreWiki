<<<<<<< HEAD
﻿using AutoMapper;
using CoreWiki.Application.Articles.Reading.Queries;
using CoreWiki.Helpers;
using CoreWiki.ViewModels;
using DiffPlex.DiffBuilder;
using DiffPlex.DiffBuilder.Model;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
=======
﻿using CoreWiki.Data.Data.Interfaces;
using CoreWiki.Data.Models;
using CoreWiki.Helpers;
using DiffPlex.DiffBuilder;
using DiffPlex.DiffBuilder.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
>>>>>>> upstream/master
using System.Linq;
using System.Threading.Tasks;

namespace CoreWiki.Pages
{
	public class HistoryModel : PageModel
	{
<<<<<<< HEAD
		private readonly IMediator _mediator;
		private readonly IMapper _mapper;

		public HistoryModel(IMediator mediator, IMapper mapper)
		{
			_mediator = mediator;
			_mapper = mapper;
		}

		public ArticleHistory Article { get; private set; }

		[BindProperty()]
		public IEnumerable<string> Compare { get; set; }
=======

		private readonly IArticleRepository _articleRepo;

		public HistoryModel(IArticleRepository articleRepo)
		{
			_articleRepo = articleRepo;
		}


		public Article Article { get; private set; }

		[BindProperty()]
		public string[] Compare { get; set; }
>>>>>>> upstream/master

		public SideBySideDiffModel DiffModel { get; set; }

		public async Task<IActionResult> OnGet(string slug)
		{
<<<<<<< HEAD
=======

>>>>>>> upstream/master
			if (string.IsNullOrEmpty(slug))
			{
				return NotFound();
			}

<<<<<<< HEAD
			var qry = new GetArticleWithHistoriesBySlugQuery(slug);

			var article = await _mediator.Send(qry);

			if (article == null)
=======
			Article = await _articleRepo.GetArticleWithHistoriesBySlug(slug);

			if (Article == null)
>>>>>>> upstream/master
			{
				return new ArticleNotFoundResult();
			}

<<<<<<< HEAD
			Article = _mapper.Map<ArticleHistory>(article);

			return Page();
=======
			return Page();

>>>>>>> upstream/master
		}

		public async Task<IActionResult> OnPost(string slug)
		{
<<<<<<< HEAD
			if (Compare.Count() < 2)
			{
				return Page();
			}

			var qry = new GetArticleWithHistoriesBySlugQuery(slug);

			var article = await _mediator.Send(qry);

			var histories = article.History
=======

			Article = await _articleRepo.GetArticleWithHistoriesBySlug(slug);

			var histories = Article.History
>>>>>>> upstream/master
				.Where(h => Compare.Any(c => c == h.Version.ToString()))
				.OrderBy(h => h.Version)
				.ToArray();

<<<<<<< HEAD
			DiffModel = new SideBySideDiffBuilder(new DiffPlex.Differ())
				.BuildDiffModel(histories[0].Content ?? "", histories[1].Content ?? "");

			Article = _mapper.Map<ArticleHistory>(article);

			return Page();
		}
=======

			this.DiffModel = new SideBySideDiffBuilder(new DiffPlex.Differ())
				.BuildDiffModel(histories[0].Content, histories[1].Content);

			return Page();

		}

>>>>>>> upstream/master
	}
}
