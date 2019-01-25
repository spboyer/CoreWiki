using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

<<<<<<< HEAD
namespace CoreWiki.Data.EntityFramework.Security
=======
namespace CoreWiki.Data.Security
>>>>>>> upstream/master
{
	public class CoreWikiIdentityContext : IdentityDbContext<CoreWikiUser>
	{
		public CoreWikiIdentityContext(DbContextOptions<CoreWikiIdentityContext> options)
				: base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

<<<<<<< HEAD
			builder.Entity<IdentityRole>().HasData(new[]
			{
				new IdentityRole
				{
					Name = "Authors",
					NormalizedName = "Authors".ToUpper()
				},
				new IdentityRole
				{
					Name = "Editors",
					NormalizedName = "Editors".ToUpper()
=======
			builder.Entity<IdentityRole>().HasData(new[] {

				new IdentityRole
					{
						Name = "Authors",
						NormalizedName = "Authors"
					},
					new IdentityRole
				{
					Name = "Editors",
					NormalizedName = "Editors"
>>>>>>> upstream/master
				},
				new IdentityRole
				{
					Name = "Administrators",
<<<<<<< HEAD
					NormalizedName = "Administrators".ToUpper()
				}
			});
		}

=======
					NormalizedName = "Administrators"
				}

			});

		}
>>>>>>> upstream/master
		public static void SeedData(CoreWikiIdentityContext context)
		{

			context.Database.Migrate();

		}
<<<<<<< HEAD

		public override void Dispose()
		{
			base.Dispose();
		}

=======
>>>>>>> upstream/master
	}
}
