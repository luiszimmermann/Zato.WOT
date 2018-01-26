namespace Zato.WOT.DataModel
{
	using System;
	using System.Net;
	using System.Collections.Generic;

	using Newtonsoft.Json;

	public partial class Account
	{
		[JsonProperty("status")]
		public string Status { get; set; }

		[JsonProperty("data")]
		public List<Datum> Data { get; set; }
	}

	public partial class Datum
	{
		[JsonProperty("nickname")]
		public string Nickname { get; set; }

		[JsonProperty("account_id")]
		public long AccountId { get; set; }
	}
}
