using System;
using System.Collections.Generic;
using System.Linq;
using SQLite.Net.Platform.XamarinIOS;

using Foundation;
using UIKit;

namespace SQLitePrePopulated.iOS
{
	[Register("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
			global::Xamarin.Forms.Forms.Init();

			string dbPath = FileHelper.GetLocalFilePath("Testbase.sqlite");

			LoadApplication(new App(dbPath, new SQLitePlatformIOS()));

			return base.FinishedLaunching(app, options);
		}
	}
}
