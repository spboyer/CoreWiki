<<<<<<< HEAD
using CoreWiki.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using CoreWiki.Application.Articles.Reading.Queries;
using CoreWiki.Application.Articles.Search.Dto;
using CoreWiki.Application.Articles.Search.Queries;
using MediatR;
using AutoMapper;
=======
using CoreWiki.Data.Models;
using CoreWiki.SearchEngines;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;
using System.Threading.Tasks;
>>>>>>> upstream/master

namespace CoreWiki.Pages
{
	public class SearchModel : PageModel
	{
<<<<<<< HEAD
		private readonly IMediator _mediator;
		private readonly IMapper _mapper;
		public SearchResultDto<ArticleSummary> SearchResult;
		private const int ResultsPerPage = 10;

		public SearchModel(IMediator mediator, IMapper mapper)
		{
			_mediator = mediator;
			_mapper = mapper;
		}

		public string RequestedPage => Request.Path.Value.ToLowerInvariant().Substring(1);

		public async Task<IActionResult> OnGetAsync([FromQuery(Name = "Query")]string query = "", [FromQuery(Name ="PageNumber")]int pageNumber = 1)
		{
			if (string.IsNullOrEmpty(query))
			{
				return Page();
			}
			var qry = new SearchArticlesQuery(query, pageNumber, ResultsPerPage);
			var result = await _mediator.Send(qry);

			SearchResult = _mapper.Map<SearchResultDto<ArticleSummary>>(result);
=======
		public SearchResult<Article> SearchResult;
		private readonly IArticlesSearchEngine _articlesSearchEngine;
		private const int ResultsPerPage = 10;

		public SearchModel(IArticlesSearchEngine articlesSearchEngine)
		{
			_articlesSearchEngine = articlesSearchEngine;
		}

		public async Task<IActionResult> OnGetAsync()
		{
			var isQueryPresent = TryGetSearchQuery(out var query);

			if (isQueryPresent)
			{
				SearchResult = await _articlesSearchEngine.SearchAsync(
					query,
					GetPageNumberOrDefault(),
					ResultsPerPage
				);
			}
>>>>>>> upstream/master

			return Page();
		}

<<<<<<< HEAD
		public async Task<IActionResult> OnGetLatestChangesAsync()
		{
			var qry = new GetLatestArticlesQuery(10);
			var results = await _mediator.Send(qry);

			SearchResult = _mapper.Map<SearchResultDto<ArticleSummary>>(results);
			SearchResult.ResultsPerPage = 11;
			SearchResult.CurrentPage = 1;

			return Page();
		}
	}
=======
		private bool TryGetSearchQuery(out string query)
		{
			var isQueryParamPresent = Request.Query.TryGetValue("Query", out var queryParams);

			if (isQueryParamPresent && !string.IsNullOrEmpty(queryParams.First()))
			{
				query = queryParams.First();
				return true;
			}

			query = "";
			return false;
		}

		private int GetPageNumberOrDefault()
		{
			var isPageParamPresent = Request.Query.TryGetValue("PageNumber", out var pageParams);

			if (isPageParamPresent && !string.IsNullOrEmpty(pageParams.First()))
			{
				var isValidNumber = int.TryParse(pageParams.First(), out var pageNumber);
				return isValidNumber ? pageNumber : 1;
			}

			return 1;
		}
	}

>>>>>>> upstream/master
}
