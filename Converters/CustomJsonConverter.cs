﻿using System;
using System.Linq;
using Newtonsoft.Json;

namespace Graphene.Core.Converters
{
    public class CustomJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType.GetInterfaces().Contains(typeof(ICustomJson));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (!CanConvert(objectType))
                return null;

            var entity = (ICustomJson)Activator.CreateInstance(objectType);
            entity.ReadJson(reader, serializer);
            return entity;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (CanConvert(value.GetType()))
            {
                ((ICustomJson)value).WriteJson(writer, serializer);
            }
        }
    }

    public interface ICustomJson
    {
        void ReadJson(JsonReader reader, JsonSerializer serializer);

        void WriteJson(JsonWriter writer, JsonSerializer serializer);
    }
}