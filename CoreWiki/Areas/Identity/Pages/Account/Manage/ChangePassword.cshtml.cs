﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
<<<<<<< HEAD
using CoreWiki.Areas.Identity.Services;
using CoreWiki.Data.EntityFramework.Security;
=======
using CoreWiki.Data.Security;
>>>>>>> upstream/master
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
namespace CoreWiki.Areas.Identity.Pages.Account.Manage
{
    public class ChangePasswordModel : PageModel
    {
        private readonly UserManager<CoreWikiUser> _userManager;
        private readonly SignInManager<CoreWikiUser> _signInManager;
        private readonly ILogger<ChangePasswordModel> _logger;
<<<<<<< HEAD
		private readonly HIBPClient _HIBPClient;

		public ChangePasswordModel(
            UserManager<CoreWikiUser> userManager,
            SignInManager<CoreWikiUser> signInManager,
            ILogger<ChangePasswordModel> logger,
			HIBPClient HIBPClient)
=======

        public ChangePasswordModel(
            UserManager<CoreWikiUser> userManager,
            SignInManager<CoreWikiUser> signInManager,
            ILogger<ChangePasswordModel> logger)
>>>>>>> upstream/master
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
<<<<<<< HEAD
			_HIBPClient = HIBPClient;
		}
=======
        }
>>>>>>> upstream/master

        [BindProperty]
        public InputModel Input { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        public class InputModel
        {
            [Required]
            [DataType(DataType.Password)]
            [Display(Name = "Current password")]
            public string OldPassword { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "New password")]
            public string NewPassword { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm new password")]
            [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            var hasPassword = await _userManager.HasPasswordAsync(user);
            if (!hasPassword)
            {
                return RedirectToPage("./SetPassword");
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

<<<<<<< HEAD
			var passwordCheck = await _HIBPClient.GetHitsPlainAsync(Input.NewPassword);
			if (passwordCheck > 0)
			{
				ModelState.AddModelError(nameof(Input.NewPassword), "This password is known to hackers, and can lead to your account being compromised, please try another password. For more info goto https://haveibeenpwned.com/passwords");
				return Page();
			}

			var changePasswordResult = await _userManager.ChangePasswordAsync(user, Input.OldPassword, Input.NewPassword);
=======
            var changePasswordResult = await _userManager.ChangePasswordAsync(user, Input.OldPassword, Input.NewPassword);
>>>>>>> upstream/master
            if (!changePasswordResult.Succeeded)
            {
                foreach (var error in changePasswordResult.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return Page();
            }

            await _signInManager.RefreshSignInAsync(user);
            _logger.LogInformation("User changed their password successfully.");
            StatusMessage = "Your password has been changed.";

            return RedirectToPage();
        }
    }
}
