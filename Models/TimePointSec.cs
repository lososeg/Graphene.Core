﻿using System;
using System.IO;
using Graphene.Core.Converters;
using Graphene.Core.Interfaces;
using Newtonsoft.Json;

namespace Graphene.Core.Models
{
    [JsonConverter(typeof(CustomJsonConverter))]
    public class TimePointSec : ICustomSerializer, ICustomJson
    {
        public DateTime Value { get; set; }


        public TimePointSec() { }

        public TimePointSec(DateTime value)
        {
            Value = value;
        }


        public static implicit operator DateTime(TimePointSec d)
        {
            return d.Value;
        }

        public static implicit operator TimePointSec(DateTime d)
        {
            return new TimePointSec(d);
        }


        #region ICustomJson

        public void ReadJson(JsonReader reader, JsonSerializer serializer)
        {
            Value = serializer.Deserialize<DateTime>(reader);
        }

        public void WriteJson(JsonWriter writer, JsonSerializer serializer)
        {
            writer.WriteValue(Value.ToString("s"));
        }

        #endregion

        #region ICustomSerializer

        public void Serializer(Stream stream, IMessageSerializer serializeHelper)
        {
            var buf = BitConverter.GetBytes((uint)(Value.Ticks / 10000000 - 62135596800)); // 01.01.1970
            stream.Write(buf, 0, buf.Length);
        }

        #endregion
    }
}