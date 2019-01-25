<<<<<<< HEAD
﻿using CoreWiki.Application.Articles.Search;
using CoreWiki.Application.Articles.Search.Impl;
using CoreWiki.Notifications;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
=======
﻿using CoreWiki.Core.Notifications;
using CoreWiki.Notifications;
using CoreWiki.SearchEngines;
using Microsoft.AspNetCore.Http;
>>>>>>> upstream/master
using Microsoft.Extensions.DependencyInjection;
using NodaTime;
using WebEssentials.AspNetCore.Pwa;

namespace CoreWiki.Configuration.Startup
{
	public static partial class ConfigurationExtensions
	{
<<<<<<< HEAD
		public static IServiceCollection ConfigureScopedServices(this IServiceCollection services, IConfiguration configuration)
=======
		public static IServiceCollection ConfigureScopedServices(this IServiceCollection services)
>>>>>>> upstream/master
		{
			services.AddSingleton<IClock>(SystemClock.Instance);

			services.AddHttpContextAccessor();
			services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

<<<<<<< HEAD
			services.AddEmailNotifications(configuration);
			services.AddScoped<IArticlesSearchEngine, ArticlesDbSearchEngine>();

			services.AddProgressiveWebApp(new PwaOptions {
				EnableCspNonce = true,
				RegisterServiceWorker = false
			});
=======
			services.AddEmailNotifications();
			services.AddScoped<IArticlesSearchEngine, ArticlesDbSearchEngine>();

			services.AddProgressiveWebApp(new PwaOptions { EnableCspNonce = true });
>>>>>>> upstream/master

			return services;
		}
	}
}
