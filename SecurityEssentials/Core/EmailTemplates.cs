﻿namespace SecurityEssentials.Core
{
	public static class EmailTemplates
	{
		public static string RegistrationNeedsApprovalText(string applicationName, string url)
		{
			return string.Format(
				"A user has requested access to {0}. To approve or disallow access click on <a href='{1}User/Approvals'>{1}User/Approvals</a>",
				applicationName, url);
		}

		public static string RegistrationPendingBodyText(string firstName, string lastName, string applicationName,
			string url, string emailVerificationToken)
		{
			return string.Format(
				"{0}Welcome to {1}, to complete your registration you just need to confirm your email address by clicking <a href='{2}Account/EmailVerifyAsync?EmailVerficationToken={3}'>{2}Account/EmailVerifyAsync?EmailVerficationToken={3}</a>. If you did not request this registration then you can ignore this email and do not need to take any further action{4}",
				GetGreeting(firstName, lastName), applicationName, url, emailVerificationToken, NotSpoofText(applicationName));
		}

		public static string RegistrationDuplicatedBodyText(string firstName, string lastName, string applicationName,
			string url)
		{
			return string.Format(
				"{0}You already have an account on {1}. You (or possibly someone else) just attempted to register on {1} with this email address. However you are registered and cannot re-register with the same address. If you'd like to login you can do so by clicking here: <a href='{2}Account/LogOn'>{2}Account/LogOn</a>. If you have forgotten your password you can answer some security questions here to reset your password:<a href='{2}Account/Recover'>{2}Account/Recover</a>. If it wasn't you who attempted to register with this email address or you did it by mistake, you can safely ignore this email{3}",
				GetGreeting(firstName, lastName), applicationName, url, NotSpoofText(applicationName));
		}

		public static string ChangePasswordPendingBodyText(string firstName, string lastName, string applicationName,
			string url, string passwordResetToken)
		{
			return string.Format(
				"{0}A request has been received to reset your {1} password. You can complete this process any time within the next 15 minutes by clicking <a href='{2}Account/RecoverPassword?PasswordResetToken={3}'>{2}Account/RecoverPassword?PasswordResetToken={3}</a>. If you did not make this request this then please ignore this email.{4}",
				GetGreeting(firstName, lastName), applicationName, url, passwordResetToken, NotSpoofText(applicationName));
		}

		public static string ChangePasswordCompletedBodyText(string firstName, string lastName, string applicationName)
		{
			return
				$"{GetGreeting(firstName, lastName)}Just a note from {applicationName} to say your password has been changed today, if this wasn't done by yourself, please contact the site administrator asap{NotSpoofText(applicationName)}";
		}

		public static string ChangeSecurityInformationCompletedBodyText(string firstName, string lastName,
			string applicationName)
		{
			return
				$"{GetGreeting(firstName, lastName)}Please be advised that the security information on your {applicationName} account been changed. If you did not initiate this action then please contact the site administrator as soon as possible{NotSpoofText(applicationName)}";
		}

		public static string ChangeEmailAddressPendingBodyText(string firstName, string lastName, string applicationName,
			string url, string token)
		{
			return string.Format(
				"{0}A request has been received to change your {1} username/email address. You can complete this process any time within the next 15 minutes by clicking <a href='{2}Account/ChangeEmailAddressConfirmAsync?NewEmailAddressToken={3}'>{2}Account/ChangeEmailAddressConfirmAsync?NewEmailAddressToken={3}</a>. If you did not request this then you can ignore this email.{4}",
				GetGreeting(firstName, lastName), applicationName, url, token, NotSpoofText(applicationName));
		}

		public static string ChangeEmailAddressCompletedBodyText(string firstName, string lastName, string applicationName,
			string oldEmailAddress, string newEmailAddress)
		{
			return
				$"{GetGreeting(firstName, lastName)}A request has been completed to change your {applicationName} username/email address from {oldEmailAddress} to {newEmailAddress}. This email address can no longer be used to sign into the account. If you did not request this then please contact the website administration asap.{NotSpoofText(applicationName)}";
		}

		public static string GetGreeting(string firstName, string lastName)
		{
			return $"Dear {firstName} {lastName},<br /><br />";
		}

		public static string PasswordResetBodyText(string firstName, string lastName, string applicationName,
			string newPassword)
		{
			return
				$"{GetGreeting(firstName, lastName)}Just a note from {applicationName} to say your password has been changed to '{newPassword}' (without the quote marks), this action was done by a system administrator. From now on you won't be able to use your old password. If you don't like this new password, you can always change it when you logon.{NotSpoofText(applicationName)}";
		}

		private static string NotSpoofText(string applicationName)
		{
			return string.Format(
				"<br /><br /><br />How do I know this is not a Spoof email? Spoof or ‘phishing’ emails tend to have generic greetings such as \"Dear {0} member\". Emails from {0} will always contain your full name.<br />",
				applicationName);
		}
	}
}