<<<<<<< HEAD
using CoreWiki.Configuration.Settings;
using CoreWiki.Configuration.Startup;
using CoreWiki.Data.EntityFramework.Security;
using CoreWiki.FirstStart;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
=======
using CoreWiki.Configuration;
using CoreWiki.Configuration.Startup;
using CoreWiki.Core.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
>>>>>>> upstream/master
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace CoreWiki
{
	public class Startup
	{
		public Startup(IConfiguration configuration, IHostingEnvironment hostingEnvironment)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
<<<<<<< HEAD
			services.ConfigureAutomapper();

=======
>>>>>>> upstream/master
			services.ConfigureRSSFeed();
			services.Configure<AppSettings>(Configuration);
			services.ConfigureSecurityAndAuthentication();
			services.ConfigureDatabase(Configuration);
<<<<<<< HEAD
			services.ConfigureScopedServices(Configuration);
			services.ConfigureHttpClients();
			services.ConfigureRouting();
			services.ConfigureLocalisation();
			services.ConfigureApplicationServices();
			services.AddMediator();

			services.AddFirstStartConfiguration(Configuration);

		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env, IOptionsSnapshot<AppSettings> settings, UserManager<CoreWikiUser> userManager, RoleManager<IdentityRole> roleManager)
		{
			app.ConfigureTelemetry();
			app.ConfigureExceptions(env);
			app.ConfigureSecurityHeaders(env);
			app.ConfigureRouting();
			app.InitializeData(Configuration);

			app.UseFirstStartConfiguration(env, Configuration, userManager, () => Program.Restart());

			var theTask = app.ConfigureAuthentication(userManager, roleManager);
			theTask.GetAwaiter().GetResult();
			app.ConfigureRSSFeed(settings);
			app.ConfigureLocalisation();

			app.UseStatusCodePagesWithReExecute("/HttpErrors/{0}");

=======
			services.ConfigureScopedServices();
			services.ConfigureRouting();
			services.ConfigureLocalisation();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env, IOptionsSnapshot<AppSettings> settings)
		{
			app.ConfigureTelemetry();
			app.ConfigureExceptions(env);
			app.ConfigureSecurityHeaders();
			app.ConfigureRouting();
			app.ConfigureAuthentication();
			app.ConfigureRSSFeed(settings);
			app.ConfigureLocalisation();
			app.ConfigureDatabase();

			app.UseStatusCodePagesWithReExecute("/HttpErrors/{0}");
>>>>>>> upstream/master
			app.UseMvc();
		}

	}
}
