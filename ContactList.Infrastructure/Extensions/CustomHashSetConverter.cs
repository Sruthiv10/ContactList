using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace RFL.TechStack.Infrastructure.Extensions
{
	public class CustomHashSetConverter : JsonConverter
	{
		public override bool CanConvert(Type objectType)
		{
			return objectType == typeof(HashSet<string>);
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, Newtonsoft.Json.JsonSerializer serializer)
		{
			JObject jo = JObject.Load(reader);
			return new HashSet<string>(jo.Properties().Select(p => p.Name));
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			HashSet<string> hashSet = (HashSet<string>)value;
			JObject jo = new JObject(hashSet.Select(s => new JProperty(s, s)));
			jo.WriteTo(writer);
		}
	}
}
