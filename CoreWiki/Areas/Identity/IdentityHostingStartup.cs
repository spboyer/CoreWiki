<<<<<<< HEAD
﻿using CoreWiki.Data.EntityFramework.Security;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
=======
﻿using System;
using CoreWiki.Data.Security;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
>>>>>>> upstream/master

[assembly: HostingStartup(typeof(CoreWiki.Areas.Identity.IdentityHostingStartup))]
namespace CoreWiki.Areas.Identity
{
	public class IdentityHostingStartup : IHostingStartup
	{
		public void Configure(IWebHostBuilder builder)
		{
			builder.ConfigureServices((context, services) =>
			{
				bool.TryParse(context.Configuration["Authentication:RequireConfirmedEmail"],
					out var requireConfirmedEmail);

<<<<<<< HEAD
				ConfigureDb(context, services);

				services.AddIdentity<CoreWikiUser, IdentityRole>(options =>
				{
					options.SignIn.RequireConfirmedEmail = requireConfirmedEmail;
					options.User.RequireUniqueEmail = true;
					options.User.AllowedUserNameCharacters = options.User.AllowedUserNameCharacters.Replace("@","");
				})
					.AddRoles<IdentityRole>()
					.AddRoleManager<RoleManager<IdentityRole>>()
					.AddDefaultUI()
					.AddDefaultTokenProviders()
					.AddEntityFrameworkStores<CoreWikiIdentityContext>();

=======
				services.AddDbContext<CoreWikiIdentityContext>(options =>
																	options.UseSqlite(
																					context.Configuration.GetConnectionString("CoreWikiIdentityContextConnection")));

				services.AddDefaultIdentity<CoreWikiUser>(options =>
						options.SignIn.RequireConfirmedEmail = requireConfirmedEmail)
																	.AddEntityFrameworkStores<CoreWikiIdentityContext>();
>>>>>>> upstream/master
				var authBuilder = services.AddAuthentication();

				if (!string.IsNullOrEmpty(context.Configuration["Authentication:Microsoft:ApplicationId"]))
				{
<<<<<<< HEAD
=======

>>>>>>> upstream/master
					authBuilder.AddMicrosoftAccount(microsoftOptions =>
					{
						microsoftOptions.ClientId = context.Configuration["Authentication:Microsoft:ApplicationId"];
						microsoftOptions.ClientSecret = context.Configuration["Authentication:Microsoft:Password"];
					});
<<<<<<< HEAD
=======

>>>>>>> upstream/master
				}

				if (!string.IsNullOrEmpty(context.Configuration["Authentication:Twitter:ConsumerKey"]))
				{
<<<<<<< HEAD
=======

>>>>>>> upstream/master
					authBuilder.AddTwitter(twitterOptions =>
					{
						twitterOptions.ConsumerKey = context.Configuration["Authentication:Twitter:ConsumerKey"];
						twitterOptions.ConsumerSecret = context.Configuration["Authentication:Twitter:ConsumerSecret"];
					});
<<<<<<< HEAD
				}

				services.AddAuthorization(AuthPolicy.Execute);
			});
		}

		private static void ConfigureDb(WebHostBuilderContext context, IServiceCollection services)
		{

			Action<DbContextOptionsBuilder> optionsBuilder;
			var connectionString = context.Configuration.GetConnectionString("CoreWikiIdentityContextConnection");

			switch (context.Configuration["DataProvider"].ToLowerInvariant())
			{
				case "postgres":
					optionsBuilder = options => options.UseNpgsql(connectionString);
					break;
				default:
					connectionString = !string.IsNullOrEmpty(connectionString) ? connectionString : "DataSource =./App_Data/wikiIdentity.db";
					optionsBuilder = options => options.UseSqlite(connectionString, o =>
					{
						o.MigrationsAssembly("CoreWiki.Data.EntityFramework");
					});
					break;
			}

			services.AddDbContext<CoreWikiIdentityContext>(optionsBuilder);

=======

				}

				services.AddAuthorization(AuthPolicy.Execute);


			});
>>>>>>> upstream/master
		}
	}
}
