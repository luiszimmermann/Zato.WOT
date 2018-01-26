using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Zato.WOT.DataModel;

namespace Zato.WOT.Core
{
	public class PlayerService
	{
		public PlayerService(string AppId)
		{
			this.AppId = AppId;
		}

		public string AppId { get; set; }

		private async Task<long> GetAccountIdByName(string name)
		{
			var client = new HttpClient();
			var stringTask = client.GetStringAsync($"https://api.wotblitz.com/wotb/account/list/?application_id={AppId}&search={name}");
			var acc = JsonHelper.FromJson<Account>(await stringTask);
			return acc.Data.First().AccountId;
		}

		public async Task<(PlayerPersonalData data, long accountId)> GetPlayerInfo(string name)
		{
			var account_id = await GetAccountIdByName(name);
			var client = new HttpClient();
			var stringTask = client.GetStringAsync($"https://api.wotblitz.com/wotb/account/info/?application_id={AppId}&account_id={account_id}");
			var data = JsonHelper.FromJson<PlayerPersonalData>(await stringTask);
			return (data, account_id);
		}
	}
}
