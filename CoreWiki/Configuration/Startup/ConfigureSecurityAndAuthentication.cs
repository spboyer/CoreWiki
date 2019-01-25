<<<<<<< HEAD
﻿using System.Threading.Tasks;
using CoreWiki.Data.EntityFramework.Security;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
=======
﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
>>>>>>> upstream/master
using Microsoft.Extensions.DependencyInjection;

namespace CoreWiki.Configuration.Startup
{
	public static partial class ConfigurationExtensions
	{
		public static IServiceCollection ConfigureSecurityAndAuthentication(this IServiceCollection services)
		{
			services.Configure<CookiePolicyOptions>(options =>
			{
				// This lambda determines whether user consent for non-essential cookies is needed for a given request.
				options.CheckConsentNeeded = context => true;
				options.MinimumSameSitePolicy = SameSiteMode.None;
			});
			return services;
		}

<<<<<<< HEAD
		public static IApplicationBuilder ConfigureSecurityHeaders(this IApplicationBuilder app, IHostingEnvironment env)
		{
			if (!env.IsDevelopment())
			{
				app.UseHsts(options => options.MaxAge(days: 365).IncludeSubdomains());
			}
=======
		public static IApplicationBuilder ConfigureSecurityHeaders(this IApplicationBuilder app)
		{
			app.UseHsts(options => options.MaxAge(days: 365).IncludeSubdomains());
>>>>>>> upstream/master
			app.UseXContentTypeOptions();
			app.UseReferrerPolicy(options => options.NoReferrer());
			app.UseXXssProtection(options => options.EnabledWithBlockMode());
			app.UseXfo(options => options.Deny());
			app.UseHttpsRedirection();
			return app;
		}

<<<<<<< HEAD
		public static async Task<IApplicationBuilder> ConfigureAuthentication(this IApplicationBuilder app, UserManager<CoreWikiUser> userManager, RoleManager<IdentityRole> roleManager)
=======
		public static IApplicationBuilder ConfigureAuthentication(this IApplicationBuilder app)
>>>>>>> upstream/master
		{
			app.UseCookiePolicy();
			app.UseAuthentication();
			return app;
		}
	}
}
