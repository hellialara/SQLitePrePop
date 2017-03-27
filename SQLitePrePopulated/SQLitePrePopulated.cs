using System;
using System.Diagnostics;
using SQLite.Net.Interop;

using Xamarin.Forms;

namespace SQLitePrePopulated
{
	public class App : Application
	{
		public static TestTabRepository TestTabRepo { get; private set; }


		public App(string dbPath, ISQLitePlatform sqlitePlatform)


		{
			TestTabRepo = new TestTabRepository(sqlitePlatform, dbPath);

			Debug.WriteLine("AppPCL");

			MainPage = new NavigationPage(new TestTabPage());
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}
