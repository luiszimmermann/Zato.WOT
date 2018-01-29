using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Zato.WOT.DataModel;

namespace Zato.WOT.Core
{
	public class VehicleService
	{
		public VehicleService(string AppId)
		{
			this.AppId = AppId;
		}

		public string AppId { get; set; }

		public async Task<Vehicles> GetAllTanks()
		{
			var client = new HttpClient();
			var stringTask = client.GetStringAsync($"https://api.wotblitz.com/wotb/encyclopedia/vehicles/?application_id={AppId}");
			var vehicles = JsonHelper.FromJson<Vehicles>(await stringTask);
			return vehicles;
		}
	}
}
