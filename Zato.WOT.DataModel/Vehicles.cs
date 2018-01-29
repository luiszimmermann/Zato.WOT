// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using QuickType;
//
//    var data = Vehicles.FromJson(jsonString);

namespace Zato.WOT.DataModel
{
	using System;
	using System.Net;
	using System.Collections.Generic;

	using Newtonsoft.Json;
	using LiteDB;

	public partial class Vehicles
	{
		[JsonProperty("status")]
		public string Status { get; set; }

		[JsonProperty("meta")]
		public Meta Meta { get; set; }

		[JsonProperty("data")]
		public Dictionary<long, VehicleInsideData> Data { get; set; }
	}

	public partial class VehicleInsideData
	{
		//[JsonProperty("suspensions")]
		//public List<long> Suspensions { get; set; }

		//[JsonProperty("description")]
		//public string Description { get; set; }

		//[JsonProperty("engines")]
		//public List<long> Engines { get; set; }

		//[JsonProperty("prices_xp")]
		//public PricesXp PricesXp { get; set; }
		//
		//[JsonProperty("next_tanks")]
		//public NextTanks NextTanks { get; set; }

		//[JsonProperty("modules_tree")]
		//public ModulesTree ModulesTree { get; set; }

		[JsonProperty("nation")]
		public string Nation { get; set; }

		[JsonProperty("is_premium")]
		public bool IsPremium { get; set; }

		//[JsonProperty("images")]
		//public Images Images { get; set; }

		//[JsonProperty("cost")]
		//public Cost Cost { get; set; }

		//[JsonProperty("default_profile")]
		//public DefaultProfile DefaultProfile { get; set; }

		[JsonProperty("tier")]
		public long Tier { get; set; }

		[BsonId]
		[JsonProperty("tank_id")]
		public long TankId { get; set; }

		//[JsonProperty("type")]
		//public string PurpleType { get; set; }

		//[JsonProperty("guns")]
		//public List<long> Guns { get; set; }

		//[JsonProperty("turrets")]
		//public List<long> Turrets { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }
	}

	public partial class Cost
	{
		[JsonProperty("price_credit")]
		public long PriceCredit { get; set; }

		[JsonProperty("price_gold")]
		public long PriceGold { get; set; }
	}

	public partial class DefaultProfile
	{
		[JsonProperty("weight")]
		public long Weight { get; set; }

		[JsonProperty("profile_id")]
		public string ProfileId { get; set; }

		[JsonProperty("firepower")]
		public long Firepower { get; set; }

		[JsonProperty("shot_efficiency")]
		public long ShotEfficiency { get; set; }

		[JsonProperty("gun_id")]
		public long GunId { get; set; }

		[JsonProperty("signal_range")]
		public long SignalRange { get; set; }

		[JsonProperty("shells")]
		public List<Shell> Shells { get; set; }

		[JsonProperty("armor")]
		public Armor Armor { get; set; }

		[JsonProperty("speed_forward")]
		public long SpeedForward { get; set; }

		[JsonProperty("battle_level_range_min")]
		public long BattleLevelRangeMin { get; set; }

		[JsonProperty("speed_backward")]
		public long SpeedBackward { get; set; }

		[JsonProperty("engine")]
		public Engine Engine { get; set; }

		[JsonProperty("max_ammo")]
		public long MaxAmmo { get; set; }

		[JsonProperty("battle_level_range_max")]
		public long BattleLevelRangeMax { get; set; }

		[JsonProperty("engine_id")]
		public long EngineId { get; set; }

		[JsonProperty("hp")]
		public long Hp { get; set; }

		[JsonProperty("is_default")]
		public bool IsDefault { get; set; }

		[JsonProperty("protection")]
		public long Protection { get; set; }

		[JsonProperty("suspension")]
		public Suspension Suspension { get; set; }

		[JsonProperty("suspension_id")]
		public long SuspensionId { get; set; }

		[JsonProperty("max_weight")]
		public long MaxWeight { get; set; }

		[JsonProperty("gun")]
		public Gun Gun { get; set; }

		[JsonProperty("turret_id")]
		public long TurretId { get; set; }

		[JsonProperty("turret")]
		public Turret Turret { get; set; }

		[JsonProperty("maneuverability")]
		public long Maneuverability { get; set; }

		[JsonProperty("hull_weight")]
		public long HullWeight { get; set; }

		[JsonProperty("hull_hp")]
		public long HullHp { get; set; }
	}

	public partial class Armor
	{
		[JsonProperty("turret")]
		public Hull Turret { get; set; }

		[JsonProperty("hull")]
		public Hull Hull { get; set; }
	}

	public partial class Hull
	{
		[JsonProperty("front")]
		public long Front { get; set; }

		[JsonProperty("sides")]
		public long Sides { get; set; }

		[JsonProperty("rear")]
		public long Rear { get; set; }
	}

	public partial class Engine
	{
		[JsonProperty("tier")]
		public long Tier { get; set; }

		[JsonProperty("fire_chance")]
		public double FireChance { get; set; }

		[JsonProperty("power")]
		public long Power { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("weight")]
		public long Weight { get; set; }
	}

	public partial class Gun
	{
		[JsonProperty("move_down_arc")]
		public long MoveDownArc { get; set; }

		[JsonProperty("caliber")]
		public long Caliber { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("weight")]
		public long Weight { get; set; }

		[JsonProperty("move_up_arc")]
		public long MoveUpArc { get; set; }

		[JsonProperty("fire_rate")]
		public double FireRate { get; set; }

		[JsonProperty("clip_reload_time")]
		public long ClipReloadTime { get; set; }

		[JsonProperty("dispersion")]
		public double Dispersion { get; set; }

		[JsonProperty("clip_capacity")]
		public long ClipCapacity { get; set; }

		[JsonProperty("traverse_speed")]
		public double TraverseSpeed { get; set; }

		[JsonProperty("reload_time")]
		public double ReloadTime { get; set; }

		[JsonProperty("tier")]
		public long Tier { get; set; }

		[JsonProperty("aim_time")]
		public double AimTime { get; set; }
	}

	public partial class Shell
	{
		[JsonProperty("type")]
		public string PurpleType { get; set; }

		[JsonProperty("penetration")]
		public long Penetration { get; set; }

		[JsonProperty("damage")]
		public long Damage { get; set; }
	}

	public partial class Suspension
	{
		[JsonProperty("tier")]
		public long Tier { get; set; }

		[JsonProperty("load_limit")]
		public long LoadLimit { get; set; }

		[JsonProperty("traverse_speed")]
		public long TraverseSpeed { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("weight")]
		public long Weight { get; set; }
	}

	public partial class Turret
	{
		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("weight")]
		public long Weight { get; set; }

		[JsonProperty("view_range")]
		public long ViewRange { get; set; }

		[JsonProperty("traverse_left_arc")]
		public long TraverseLeftArc { get; set; }

		[JsonProperty("hp")]
		public long Hp { get; set; }

		[JsonProperty("traverse_speed")]
		public long TraverseSpeed { get; set; }

		[JsonProperty("tier")]
		public long Tier { get; set; }

		[JsonProperty("traverse_right_arc")]
		public long TraverseRightArc { get; set; }
	}

	public partial class Images
	{
		[JsonProperty("preview")]
		public string Preview { get; set; }

		[JsonProperty("normal")]
		public string Normal { get; set; }
	}

	public partial class ModulesTree
	{
		[JsonProperty("2")]
		public The1284 The2 { get; set; }

		[JsonProperty("3")]
		public The1284 The3 { get; set; }

		[JsonProperty("4")]
		public The1284 The4 { get; set; }

		[JsonProperty("5")]
		public The1284 The5 { get; set; }

		[JsonProperty("258")]
		public The1284 The258 { get; set; }

		[JsonProperty("259")]
		public The1284 The259 { get; set; }

		[JsonProperty("261")]
		public The1284 The261 { get; set; }

		[JsonProperty("516")]
		public The1284 The516 { get; set; }

		[JsonProperty("1284")]
		public The1284 The1284 { get; set; }

		[JsonProperty("1540")]
		public The1284 The1540 { get; set; }
	}

	public partial class The1284
	{
		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("next_modules")]
		public List<long> NextModules { get; set; }

		[JsonProperty("next_tanks")]
		public List<long> NextTanks { get; set; }

		[JsonProperty("is_default")]
		public bool IsDefault { get; set; }

		[JsonProperty("price_xp")]
		public long PriceXp { get; set; }

		[JsonProperty("price_credit")]
		public long PriceCredit { get; set; }

		[JsonProperty("module_id")]
		public long ModuleId { get; set; }

		[JsonProperty("type")]
		public string PurpleType { get; set; }
	}

	//public partial class NextTanks
	//{
	//	[JsonProperty("257")]
	//	public long The257 { get; set; }
	//
	//	[JsonProperty("2561")]
	//	public long The2561 { get; set; }
	//
	//	[JsonProperty("16641")]
	//	public long The16641 { get; set; }
	//}
	//
	//public partial class PricesXp
	//{
	//	[JsonProperty("2049")]
	//	public long The2049 { get; set; }
	//}
}
