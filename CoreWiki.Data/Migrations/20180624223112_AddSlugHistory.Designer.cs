﻿// <auto-generated />
using CoreWiki.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

<<<<<<< HEAD
namespace CoreWiki.Data.EntityFramework.Migrations
=======
namespace CoreWiki.Migrations
>>>>>>> upstream/master
{
	[DbContext(typeof(ApplicationDbContext))]
	[Migration("20180624223112_AddSlugHistory")]
	partial class AddSlugHistory
	{
		protected override void BuildTargetModel(ModelBuilder modelBuilder)
		{
#pragma warning disable 612, 618
			modelBuilder
					.HasAnnotation("ProductVersion", "2.1.0-rtm-30799");

			modelBuilder.Entity("CoreWiki.Models.Article", b =>
					{
						b.Property<int>("Id")
											.ValueGeneratedOnAdd();

						b.Property<string>("Content");

						b.Property<DateTime>("PublishedDateTime")
											.HasColumnName("Published");

						b.Property<string>("Slug");

						b.Property<string>("Topic")
											.IsRequired()
											.HasMaxLength(100);

						b.Property<int>("ViewCount");

						b.HasKey("Id");

						b.HasIndex("Slug")
											.IsUnique();

						b.ToTable("Articles");
					});

			modelBuilder.Entity("CoreWiki.Models.Comment", b =>
					{
						b.Property<int>("Id")
											.ValueGeneratedOnAdd();

						b.Property<int?>("ArticleId");

						b.Property<string>("Content")
											.IsRequired();

						b.Property<string>("DisplayName")
											.IsRequired()
											.HasMaxLength(100);

						b.Property<string>("Email")
											.IsRequired()
											.HasMaxLength(100);

						b.Property<int>("IdArticle");

						b.Property<DateTime>("SubmittedDateTime")
											.HasColumnName("Submitted");

						b.HasKey("Id");

						b.HasIndex("ArticleId");

						b.ToTable("Comments");
					});

			modelBuilder.Entity("CoreWiki.Models.SlugHistory", b =>
					{
						b.Property<int>("Id")
											.ValueGeneratedOnAdd();

						b.Property<DateTime>("AddedDateTime")
											.HasColumnName("Added");

						b.Property<int?>("ArticleId");

						b.Property<string>("OldSlug");

						b.HasKey("Id");

						b.HasIndex("ArticleId");

						b.HasIndex("OldSlug", "AddedDateTime");

						b.ToTable("SlugHistories");
					});

			modelBuilder.Entity("CoreWiki.Models.Comment", b =>
					{
						b.HasOne("CoreWiki.Models.Article", "Article")
											.WithMany("Comments")
											.HasForeignKey("ArticleId");
					});

			modelBuilder.Entity("CoreWiki.Models.SlugHistory", b =>
					{
						b.HasOne("CoreWiki.Models.Article", "Article")
											.WithMany()
											.HasForeignKey("ArticleId");
					});
#pragma warning restore 612, 618
		}
	}
}
