using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;
using System.Threading;


namespace JustEnergy
{
	[TestFixture(Platform.Android)]
	[TestFixture(Platform.iOS)]
	public class Tests
	{
		IApp app;
		Platform platform;

		public Tests(Platform platform)
		{
			this.platform = platform;
		}

		[SetUp]
		public void BeforeEachTest()
		{
			app = AppInitializer.StartApp(platform);
			app.Screenshot("App Launched");
		}

		[Test]
		public void UsernameNoPassword()
		{
			app.Tap(x => x.Css("#username"));
			app.Screenshot("We Tapped on the username Text Field");

			app.EnterText("Just Energy");
			app.Screenshot("Then, we entered our username");
			app.DismissKeyboard();
			app.Screenshot("Dismissed Keyboard");

			app.Tap(x => x.Css("#loginbtn"));
			app.Screenshot("We Tapped on the Login Button");
		}

		[Test]
		public void PasswordNoUsername()
		{
			app.Tap(x => x.Css("#password"));
			app.Screenshot("We Tapped on the password Text Field");

			app.EnterText("Microsoft");
			app.Screenshot("Then, we entered our password");
			app.DismissKeyboard();
			app.Screenshot("Dismissed Keyboard");

			app.Tap(x => x.Css("#loginbtn"));
			app.Screenshot("We Tapped on the Login Button");
		}

		[Test]
		public void ResetPassword()
		{
			Thread.Sleep(8000);
			app.Tap(x => x.Css("#resetPasswordbtn"));
			app.Screenshot("We Tapped on the Reset Password Button");

			app.Tap(x => x.Css("#username"));
			app.Screenshot("Then, we Tapped on the username Text Field");
			app.EnterText("Just Energy");
			app.Screenshot("Then, we entered our username");
			app.DismissKeyboard();

			Thread.Sleep(8000);
			app.Tap(x => x.Css("#emailAddress"));
			app.Screenshot("Then, we Tapped on the Email Text Field");
			app.EnterText("JustEnergy@microsoft.com");
			app.Screenshot("We entered in our E-mail");
			app.DismissKeyboard();
			app.Screenshot("Dismissed Keyboard");

			app.Tap(x => x.Css(".ui-btn-text"));
			app.Screenshot("We Tapped on the 'Send Password' Button");
		}

	}
}
