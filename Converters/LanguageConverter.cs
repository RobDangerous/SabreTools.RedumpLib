using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SabreTools.RedumpLib.Data;

namespace SabreTools.RedumpLib.Converters
{
    /// <summary>
    /// Serialize Language enum values
    /// </summary>
    public class LanguageConverter : JsonConverter<Language?[]>
    {
        public override bool CanRead { get { return false; } }

#if NET48
        public override Language?[] ReadJson(JsonReader reader, Type objectType, Language?[] existingValue, bool hasExistingValue, JsonSerializer serializer)
#else
        public override Language?[] ReadJson(JsonReader reader, Type objectType, Language?[]? existingValue, bool hasExistingValue, JsonSerializer serializer)
#endif
        {
            throw new NotImplementedException();
        }

#if NET48
        public override void WriteJson(JsonWriter writer, Language?[] value, JsonSerializer serializer)
#else
        public override void WriteJson(JsonWriter writer, Language?[]? value, JsonSerializer serializer)
#endif
        {
            if (value == null)
                return;

            JArray array = new JArray();
            foreach (var val in value)
            {
                JToken t = JToken.FromObject(val.ShortName() ?? string.Empty);
                array.Add(t);
            }

            array.WriteTo(writer);
        }
    }
}