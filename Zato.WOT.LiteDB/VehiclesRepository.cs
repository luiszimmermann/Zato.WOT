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
		public void PersistOrUpdateVehicle(Vehicles vh)
		{
			try
			{
				var vehicles = db.GetCollection<VehicleInsideData>("VehicleInsideData");

				foreach (var item in vh.Data)
				{
					if (!vehicles.Exists(x => x.TankId == item.Value.TankId))
						vehicles.Insert(item.Value);
				}

				vehicles.EnsureIndex(x => x.TankId);
			}
			catch (Exception ex)
			{
			}
		}

		public VehicleInsideData GetVehicleById(long id)
		{
			try
			{
				var vehicles = db.GetCollection<VehicleInsideData>("VehicleInsideData");
				var vh = vehicles.FindById(id);

				return vh;
			}
			catch (Exception ex)
			{
				return null;
			}
		}

	}
}
