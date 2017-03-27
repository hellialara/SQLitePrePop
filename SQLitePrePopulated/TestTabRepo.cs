using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using SQLite.Net;
using SQLite.Net.Interop;
using SQLite.Net.Async;
using System.Threading.Tasks;

namespace SQLitePrePopulated
{
	public class TestTabRepository
	{
		private SQLiteAsyncConnection dbConn;

		public TestTabRepository(ISQLitePlatform sqlitePlatform, string dbPath)
		{
			if (dbConn == null)
			{
				var connectionFunc = new Func< SQLiteConnectionWithLock > (() =>
																	   new SQLiteConnectionWithLock
																	   (
																		   sqlitePlatform,
																		   new SQLiteConnectionString(dbPath, storeDateTimeAsTicks: false)
																		  ));
				dbConn = new SQLiteAsyncConnection(connectionFunc);
				dbConn.CreateTableAsync<TestTab>();

			}
			Debug.WriteLine("Repo");
		}

		public async Task<List<TestTab>> GetAllItems()
		{
			List<TestTab> people = await dbConn.Table<TestTab>().ToListAsync();
			return people;
		}
	}
}
