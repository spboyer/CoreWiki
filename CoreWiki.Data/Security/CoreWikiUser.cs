using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

<<<<<<< HEAD
namespace CoreWiki.Data.EntityFramework.Security
{
	// Add profile data for application users by adding properties to the CoreWikiUser class
	public class CoreWikiUser : IdentityUser
	{

		public string DisplayName { get; set; }

		public bool CanNotify { get; set; }
	}
=======
namespace CoreWiki.Data.Security
{
    // Add profile data for application users by adding properties to the CoreWikiUser class
    public class CoreWikiUser : IdentityUser
    {
		public bool CanNotify { get; set; }
    }
>>>>>>> upstream/master
}
