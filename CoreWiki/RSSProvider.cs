<<<<<<< HEAD
﻿using Microsoft.EntityFrameworkCore;
=======
﻿using CoreWiki.Data;
using Microsoft.EntityFrameworkCore;
>>>>>>> upstream/master
using Microsoft.Extensions.Options;
using Snickler.RSSCore.Models;
using Snickler.RSSCore.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
<<<<<<< HEAD
using CoreWiki.Application.Articles.Reading.Queries;
using CoreWiki.Configuration.Settings;
using MediatR;
=======
using CoreWiki.Core.Configuration;
>>>>>>> upstream/master

namespace CoreWiki
{
	public class RSSProvider : IRSSProvider
	{
<<<<<<< HEAD
		private readonly IMediator _mediator;
		private readonly Uri baseURL;

		public RSSProvider(IMediator mediator, IOptionsSnapshot<AppSettings> settings)
		{
			_mediator = mediator;
=======
		private readonly ApplicationDbContext _context;
		private readonly Uri baseURL;

		public RSSProvider(ApplicationDbContext context, IOptionsSnapshot<AppSettings> settings)
		{
			_context = context;
>>>>>>> upstream/master
			baseURL = settings.Value.Url;
		}

		public async Task<IList<RSSItem>> RetrieveSyndicationItems()
		{
<<<<<<< HEAD
			var articles = await _mediator.Send(new GetLatestArticlesQuery(10));
=======
			var articles = await _context.Articles.OrderByDescending(a => a.Published).Take(10).ToListAsync();
>>>>>>> upstream/master
			return articles.Select(rssItem =>
			{
				var absoluteURL = new Uri(baseURL, $"/{rssItem.Slug}");

				var wikiItem = new RSSItem
				{
					Content = rssItem.Content,
					PermaLink = absoluteURL,
					LinkUri = absoluteURL,
					PublishDate = rssItem.Published.ToDateTimeUtc(),
					LastUpdated = rssItem.Published.ToDateTimeUtc(),
					Title = rssItem.Topic,
				};

				wikiItem.Authors.Add("Jeff Fritz"); // TODO: Grab from user who saved record... not this guy
				return wikiItem;
			}).ToList();
		}

	}
}
