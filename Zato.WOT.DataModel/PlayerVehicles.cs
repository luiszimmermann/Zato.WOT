// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using QuickType;
//
//    var data = PlayerVehicles.FromJson(jsonString);

namespace Zato.WOT.DataModel
{
	using System;
	using System.Net;
	using System.Collections.Generic;

	using Newtonsoft.Json;

	public partial class PlayerVehicles
	{
		[JsonProperty("status")]
		public string Status { get; set; }

		[JsonProperty("meta")]
		public Meta Meta { get; set; }

		[JsonProperty("data")]
		public Dictionary<long, List<PlayerVehicleInsideData>> Data { get; set; }
	}

	//public partial class Data
	//{
	//	[JsonProperty("1001068548")]
	//	public List<The1001068548> The1001068548 { get; set; }
	//}

	public partial class PlayerVehicleInsideData
	{
		[JsonProperty("all")]
		public All All { get; set; }

		[JsonProperty("last_battle_time")]
		public long LastBattleTime { get; set; }

		[JsonProperty("account_id")]
		public long AccountId { get; set; }

		[JsonProperty("max_xp")]
		public long MaxXp { get; set; }

		[JsonProperty("in_garage_updated")]
		public long InGarageUpdated { get; set; }

		[JsonProperty("max_frags")]
		public long MaxFrags { get; set; }

		[JsonProperty("frags")]
		public object Frags { get; set; }

		[JsonProperty("mark_of_mastery")]
		public long MarkOfMastery { get; set; }

		[JsonProperty("battle_life_time")]
		public long BattleLifeTime { get; set; }

		[JsonProperty("in_garage")]
		public object InGarage { get; set; }

		[JsonProperty("tank_id")]
		public long TankId { get; set; }
	}
}
