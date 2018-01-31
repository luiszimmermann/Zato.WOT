using System;
using System.Collections.Generic;
using System.Text;
using Zato.WOT.DataModel;
using System.Linq;
using LiteDB;

namespace Zato.WOT.LiteDB
{
	public class VehiclesRepository : WotDB
	{
		public void PersistOrUpdateVehicle(Vehicles vh, bool fullup = false)
		{
			try
			{
				var vehicles = Db.GetCollection<VehicleInsideData>("VehicleInsideData");

				foreach (var item in vh.Data)
				{
					var tankExists = vehicles.Exists(x => x.TankId == item.Value.TankId);
					if (!tankExists)
					{
						vehicles.Insert(item.Value);
					}
					else if (fullup && tankExists)
					{
						vehicles.Upsert(item.Value);
					}
				}

				vehicles.EnsureIndex(x => x.TankId);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}

		public VehicleInsideData GetVehicleById(long id)
		{
			try
			{
				var vehicles = Db.GetCollection<VehicleInsideData>("VehicleInsideData");
				var vh = vehicles.FindById(id);
				if (vh == null) { vh = new VehicleInsideData(); }
				return vh;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				return null;
			}
		}

	}
}
