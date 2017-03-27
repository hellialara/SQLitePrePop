using SQLite.Net.Attributes;
namespace SQLitePrePopulated
{
	public class TestTab
	{
		[PrimaryKey, AutoIncrement, NotNull, Unique]
		public int Id { get; set; }
		[NotNull]
		public string Name { get; set; }
		public string Info { get; set; }
		[NotNull]
		public string Image { get; set; }
		[Ignore]
		public string ImgLarge { get; set; }
		public string URL { get; set; }
	}
}
