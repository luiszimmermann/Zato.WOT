// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using QuickType;
//
//    var data = Welcome.FromJson(jsonString);

namespace Zato.WOT.DataModel
{
	using System;
	using System.Net;
	using System.Collections.Generic;

	using Newtonsoft.Json;

	public partial class PlayerPersonalData
	{
		[JsonProperty("status")]
		public string Status { get; set; }

		[JsonProperty("meta")]
		public Meta Meta { get; set; }

		[JsonProperty("data")]
		public Dictionary<long, InsideData> Data { get; set; }
	}

	//public partial class Data
	//{
	//	public Dictionary<string, InsideData> InsideData { get; set; }
	//	//[JsonProperty("1001068548")]
	//	//public The1001068548 The1001068548 { get; set; }
	//}

	public partial class InsideData
	{
		[JsonProperty("statistics")]
		public Statistics Statistics { get; set; }

		[JsonProperty("account_id")]
		public long AccountId { get; set; }

		[JsonProperty("created_at")]
		public long CreatedAt { get; set; }

		[JsonProperty("updated_at")]
		public long UpdatedAt { get; set; }

		[JsonProperty("private")]
		public object Private { get; set; }

		[JsonProperty("last_battle_time")]
		public long LastBattleTime { get; set; }

		[JsonProperty("nickname")]
		public string Nickname { get; set; }
	}

	public partial class Statistics
	{
		[JsonProperty("clan")]
		public All Clan { get; set; }

		[JsonProperty("all")]
		public All All { get; set; }

		[JsonProperty("frags")]
		public object Frags { get; set; }
	}

	public partial class All
	{
		[JsonProperty("spotted")]
		public long Spotted { get; set; }

		[JsonProperty("max_frags_tank_id")]
		public long MaxFragsTankId { get; set; }

		[JsonProperty("hits")]
		public long Hits { get; set; }

		[JsonProperty("frags")]
		public long Frags { get; set; }

		[JsonProperty("max_xp")]
		public long MaxXp { get; set; }

		[JsonProperty("max_xp_tank_id")]
		public long MaxXpTankId { get; set; }

		[JsonProperty("wins")]
		public long Wins { get; set; }

		[JsonProperty("losses")]
		public long Losses { get; set; }

		[JsonProperty("capture_points")]
		public long CapturePoints { get; set; }

		[JsonProperty("battles")]
		public long Battles { get; set; }

		[JsonProperty("damage_dealt")]
		public long DamageDealt { get; set; }

		[JsonProperty("damage_received")]
		public long DamageReceived { get; set; }

		[JsonProperty("max_frags")]
		public long MaxFrags { get; set; }

		[JsonProperty("shots")]
		public long Shots { get; set; }

		[JsonProperty("frags8p")]
		public long Frags8P { get; set; }

		[JsonProperty("xp")]
		public long Xp { get; set; }

		[JsonProperty("win_and_survived")]
		public long WinAndSurvived { get; set; }

		[JsonProperty("survived_battles")]
		public long SurvivedBattles { get; set; }

		[JsonProperty("dropped_capture_points")]
		public long DroppedCapturePoints { get; set; }
	}

	public partial class Meta
	{
		[JsonProperty("count")]
		public long Count { get; set; }
	}
}
