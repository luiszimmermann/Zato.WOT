using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Zato.WOT.DataModel
{
	public static class JsonHelper
	{
		public static T FromJson<T>(string json) => JsonConvert.DeserializeObject<T>(json, Converter.Settings);

		public static string ToJson<T>(this T self) => JsonConvert.SerializeObject(self, Converter.Settings);

		public class Converter
		{
			public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
			{
				MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
				DateParseHandling = DateParseHandling.None,
			};
		}
	}
}
