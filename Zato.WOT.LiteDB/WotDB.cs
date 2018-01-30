using LiteDB;
using System;

namespace Zato.WOT.LiteDB
{
	public class WotDB : IDisposable
	{
		public LiteDatabase Db
		{
			get
			{
				if (_db == null)
					this._db = new LiteDatabase(AppDomain.CurrentDomain.BaseDirectory + @"WOTData.db");
				return _db;
			}
			set
			{
				_db = value;
			}
		}

		private LiteDatabase _db { get; set; }

		public WotDB()
		{
			// Open database (or create if not exits)
			//this._db = new LiteDatabase(@"WOTData.db");
		}

		public void Dispose()
		{
			_db.Dispose();
		}
	}
}
