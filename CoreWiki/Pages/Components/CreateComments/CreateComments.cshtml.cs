<<<<<<< HEAD
﻿using CoreWiki.ViewModels;
=======
﻿using CoreWiki.Data;
using CoreWiki.Data.Data.Interfaces;
using CoreWiki.Data.Models;
>>>>>>> upstream/master
using Microsoft.AspNetCore.Mvc;

namespace CoreWiki.Pages.Components.CreateComments
{
	[ViewComponent(Name = "CreateComments")]
	public class CreateComments : ViewComponent
	{
		public IViewComponentResult Invoke(Comment comment)
		{
			return View("CreateComments", comment);
		}
	}
}
