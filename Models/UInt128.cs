﻿using System;
using System.IO;
using System.Numerics;
using Graphene.Core.Converters;
using Graphene.Core.Interfaces;
using Newtonsoft.Json;

namespace Graphene.Core.Models
{
    [JsonConverter(typeof(CustomJsonConverter))]
    public class UInt128 : ICustomJson, ICustomSerializer
    {
        public string Value { get; set; }


        public UInt128() { }

        public UInt128(string value)
        {
            Value = value;
        }


        #region ICustomJson

        public void ReadJson(JsonReader reader, JsonSerializer serializer)
        {
            Value = serializer.Deserialize<string>(reader);
        }

        public void WriteJson(JsonWriter writer, JsonSerializer serializer)
        {
            writer.WriteValue(Value);
        }

        #endregion

        #region ICustomSerializer

        public void Serializer(Stream stream, IMessageSerializer serializeHelper)
        {
            var bi = BigInteger.Parse(Value);
            var buf = bi.ToByteArray();
            stream.Write(buf, 0, Math.Min(buf.Length, 16));
            if (buf.Length < 16)
            {
                buf = new byte[16 - buf.Length];
                stream.Write(buf, 0, buf.Length);
            }
        }

        #endregion
    }
}