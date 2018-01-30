using LiteDB;
using System;
using System.IO;
using Xunit;
using Zato.WOT.LiteDB;

namespace Zato.WOT.xUnit
{
	public class UnitTestLiteDB
	{
		[Fact]
		public void TestLiteDBInit()
		{
			var wotdb = new WotDB();
			var db = wotdb.Db;
			var strings = db.GetCollection<XUnitLiteDBTest>("ForceCreation");
			strings.Insert(new XUnitLiteDBTest() { Id = 1, Test = "xUnit" });
			Assert.True(File.Exists(AppDomain.CurrentDomain.BaseDirectory + @"WOTData.db"), "WOTData don't exists");
			File.Delete(AppDomain.CurrentDomain.BaseDirectory + @"WOTData.db");
		}
	}

	public class XUnitLiteDBTest
	{
		[BsonId]
		public int Id { get; set; }
		public string Test { get; set; }
	}
}
