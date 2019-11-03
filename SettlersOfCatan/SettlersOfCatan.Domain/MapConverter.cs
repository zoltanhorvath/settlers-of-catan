using Newtonsoft.Json;
using SettlersOfCatan.Domain.Map;
using System;
using System.Collections.Generic;

namespace SettlersOfCatan.Domain
{
    public class MapConverter : JsonConverter<SortedDictionary<Coordinates, Hexagon>>
    {
        public override SortedDictionary<Coordinates, Hexagon> ReadJson(JsonReader reader, Type objectType, SortedDictionary<Coordinates, Hexagon> existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override void WriteJson(JsonWriter writer, SortedDictionary<Coordinates, Hexagon> value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
