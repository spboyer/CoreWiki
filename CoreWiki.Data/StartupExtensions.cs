<<<<<<< HEAD
﻿using CoreWiki.Data.EntityFramework.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CoreWiki.Data.Abstractions.Interfaces;
using System;

namespace CoreWiki.Data.EntityFramework
=======
﻿using CoreWiki.Data.Data.Interfaces;
using CoreWiki.Data.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreWiki.Data
>>>>>>> upstream/master
{

	public static class StartupExtensions
	{

		/// <summary>
		/// Configure the SQLite repositories and EntityFramework context to support it
		/// </summary>
		/// <param name="services"></param>
		/// <param name="config"></param>
		/// <returns></returns>
<<<<<<< HEAD
		public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration config) {

			Action<DbContextOptionsBuilder> optionsBuilder;
			var connectionString = config.GetConnectionString("CoreWikiData");

			switch (config["DataProvider"].ToLowerInvariant()) {
				case "postgres":
					services.AddEntityFrameworkNpgsql();
					optionsBuilder = options => options.UseNpgsql(connectionString);
					break;
				default:
					services.AddEntityFrameworkSqlite();
					connectionString = !string.IsNullOrEmpty(connectionString) ? connectionString : "DataSource=./App_Data/wikiContent.db";
					optionsBuilder = options => options.UseSqlite(connectionString);
					break;
			}

			services.AddDbContextPool<ApplicationDbContext>(options => {
				optionsBuilder(options);
				options.EnableSensitiveDataLogging();
			});

			// db repos
			services.AddTransient<IArticleRepository, ArticleRepository>();
			services.AddTransient<ICommentRepository, CommentRepository>();
			services.AddTransient<ISlugHistoryRepository, SlugHistoryRepository>();
=======
		public static IServiceCollection AddSqliteRepositories(this IServiceCollection services, IConfiguration config) {

			services.AddEntityFrameworkSqlite()
			.AddDbContextPool<ApplicationDbContext>(options =>
				options.UseSqlite(config.GetConnectionString("CoreWikiData"))
					.EnableSensitiveDataLogging(true)
			);

			// db repos
			services.AddTransient<IArticleRepository, ArticleSqliteRepository>();
			services.AddTransient<ICommentRepository, CommentSqliteRepository>();
			services.AddTransient<ISlugHistoryRepository, SlugHistorySqliteRepository>();

>>>>>>> upstream/master
			return services;

		}

		public static IServiceScope SeedData(this IServiceScope serviceScope) {

			var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

			ApplicationDbContext.SeedData(context);

			return serviceScope;

		}

	}

}
