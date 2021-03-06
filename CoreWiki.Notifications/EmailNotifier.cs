<<<<<<< HEAD
﻿using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Net;
using System.Threading.Tasks;
using CoreWiki.Notifications.Abstractions.Configuration;
using CoreWiki.Notifications.Abstractions.Notifications;
=======
﻿using CoreWiki.Core.Configuration;
using CoreWiki.Core.Notifications;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Net;
using System.Threading.Tasks;
>>>>>>> upstream/master

namespace CoreWiki.Notifications
{
	public class EmailNotifier : IEmailNotifier
	{
		private readonly EmailNotifications _configuration;
		private readonly ILogger _logger;

<<<<<<< HEAD
		public EmailNotifier(IOptionsSnapshot<EmailNotifications> appSettings, ILoggerFactory loggerFactory)
		{
			_configuration = appSettings.Value;
=======
		public EmailNotifier(IOptionsSnapshot<AppSettings> appSettings, ILoggerFactory loggerFactory)
		{
			_configuration = appSettings.Value.EmailNotifications;
>>>>>>> upstream/master
			_logger = loggerFactory.CreateLogger<EmailNotifier>();
		}

		public async Task<bool> SendEmailAsync(string recipientEmail, string subject, string body)
		{
			return await SendEmailAsync(recipientEmail, string.Empty, subject, body);
		}

		public async Task<bool> SendEmailAsync(string recipientEmail, string recipientName, string subject, string body)
		{
<<<<<<< HEAD
			_logger.LogInformation("Sending email message");
=======
            _logger.LogInformation("Sending email message");
>>>>>>> upstream/master

			if (string.IsNullOrWhiteSpace(_configuration.SendGridApiKey))
			{
				_logger.LogWarning($"Missing SendGridApiKey setting in {nameof(EmailNotifications)}");

				return false;
			}

			if (string.IsNullOrWhiteSpace(_configuration.FromEmailAddress))
			{
				_logger.LogWarning($"Missing from FromEmailAddress setting in {nameof(EmailNotifications)}");

				return false;
			}

			if (string.IsNullOrWhiteSpace(recipientEmail))
			{
<<<<<<< HEAD
				_logger.LogWarning("Missing recipient email, email message not sent");

				return false;
			}

			//if (string.IsNullOrWhiteSpace(recipientName))
			//{
			//    _logger.LogWarning("Missing recipient name, email message not sent");

			//    return false;
			//}

			var message = new SendGridMessage();
=======
			    _logger.LogWarning("Missing recipient email, email message not sent");

			    return false;
            }

		    //if (string.IsNullOrWhiteSpace(recipientName))
		    //{
		    //    _logger.LogWarning("Missing recipient name, email message not sent");

		    //    return false;
		    //}

            var message = new SendGridMessage();
>>>>>>> upstream/master
			var from = new EmailAddress(_configuration.FromEmailAddress, _configuration.FromName);
			var to = new EmailAddress(recipientEmail, recipientName);

			message.SetFrom(from);
			message.AddTo(to);
			message.SetSubject(subject);
			message.AddContent(MimeType.Html, body);

			var client = new SendGridClient(_configuration.SendGridApiKey);

			var response = await client.SendEmailAsync(message);

			_logger.LogInformation($"Sent email form {from.Email} to {to.Email} response {response.StatusCode}");

			return response.StatusCode == HttpStatusCode.OK;
		}
	}
}
