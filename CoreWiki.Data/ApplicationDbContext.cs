<<<<<<< HEAD
﻿using CoreWiki.Data.EntityFramework.Models;
=======
﻿using CoreWiki.Data.Models;
>>>>>>> upstream/master
using Microsoft.EntityFrameworkCore;
using NodaTime;
using System;
using System.Threading;
using System.Threading.Tasks;

<<<<<<< HEAD
namespace CoreWiki.Data.EntityFramework
=======
namespace CoreWiki.Data
>>>>>>> upstream/master
{

	public class ApplicationDbContext : DbContext
	{

		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
<<<<<<< HEAD
			var homePage = new ArticleDAO
			{
				Id = 1,
				Topic = "Home Page",
				Slug = "home-page",
				Content = "This is the default home page. Please change me!",
=======
			var homePage = new Article
			{
				Id = 1,
				Topic = "HomePage",
				Slug = "home-page",
				Content = "This is the default home page.  Please change me!",
>>>>>>> upstream/master
				Published = Instant.FromDateTimeUtc(new DateTime(2018, 6, 19, 14, 31, 2, 265, DateTimeKind.Utc)),
				AuthorId = Guid.Empty
			};

<<<<<<< HEAD
			var homePageHistory = ArticleHistoryDAO.FromArticle(homePage);
			homePageHistory.Id = 1;
			homePageHistory.Article = null;

			modelBuilder.Entity<ArticleDAO>(entity =>
=======
			var homePageHistory = ArticleHistory.FromArticle(homePage);
			homePageHistory.Id = 1;
			homePageHistory.Article = null;

			modelBuilder.Entity<Article>(entity =>
>>>>>>> upstream/master
			{
				entity.HasIndex(a => a.Slug).IsUnique();
				entity.HasData(homePage);
			});

<<<<<<< HEAD
			modelBuilder.Entity<ArticleHistoryDAO>(entity =>
=======
			modelBuilder.Entity<ArticleHistory>(entity =>
>>>>>>> upstream/master
			{
				entity.HasData(homePageHistory);
			});

<<<<<<< HEAD
			modelBuilder.Entity<SlugHistoryDAO>(entity =>
=======
			modelBuilder.Entity<SlugHistory>(entity =>
>>>>>>> upstream/master
			{
				entity.HasIndex(a => new { a.OldSlug, a.AddedDateTime });
			});
		}

<<<<<<< HEAD
		public DbSet<ArticleDAO> Articles { get; set; }
		public DbSet<CommentDAO> Comments { get; set; }
		public DbSet<SlugHistoryDAO> SlugHistories { get; set; }

		public DbSet<ArticleHistoryDAO> ArticleHistories { get; set; }
=======
		public DbSet<Article> Articles { get; set; }
		public DbSet<Comment> Comments { get; set; }
		public DbSet<SlugHistory> SlugHistories { get; set; }

		public DbSet<ArticleHistory> ArticleHistories { get; set; }
>>>>>>> upstream/master


		public override Task<int> SaveChangesAsync(
			CancellationToken cancellationToken = default(CancellationToken))
		{
			return base.SaveChangesAsync(cancellationToken);
		}


		public static void SeedData(ApplicationDbContext context)
		{

			context.Database.Migrate();

		}

	}
}
