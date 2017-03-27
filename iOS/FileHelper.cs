using System;
using System.IO;
using Xamarin.Forms;
using Foundation;
using SQLitePrePopulated.iOS;
using System.Diagnostics;


namespace SQLitePrePopulated.iOS
{
	public class FileHelper
	{
		public static string GetLocalFilePath(string filename)
		{
			string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			string libFolder = Path.Combine(docFolder, "..", "Library", "Databases");

			if (!Directory.Exists(libFolder))
			{
				Directory.CreateDirectory(libFolder);
			}

			string dbPath = Path.Combine(libFolder, filename);

			CopyDatabaseIfNotExists(dbPath);

			return dbPath;


		}


		private static void CopyDatabaseIfNotExists(string dbPath)
		{

			if (!File.Exists(dbPath))
			{
				
				var existingDb = NSBundle.MainBundle.PathForResource("Testbase", "sqlite");
				File.Copy(existingDb, dbPath);
			}

		}

	}
}
