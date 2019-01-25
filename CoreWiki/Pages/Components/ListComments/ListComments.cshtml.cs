<<<<<<< HEAD
﻿using CoreWiki.ViewModels;
=======
﻿using CoreWiki.Data.Models;
>>>>>>> upstream/master
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CoreWiki.Pages.Components.ListComments
{
	[ViewComponent(Name = "ListComments")]
	public class ListComments : ViewComponent
	{


		public ListComments()
		{

		}

		public IViewComponentResult Invoke(ICollection<Comment> comments)
		{
			return View("ListComments", comments);
		}
	}
}
