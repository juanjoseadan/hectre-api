﻿using MongoDB.Bson.Serialization;
using System;

namespace Hectre.Core.Utils
{
    public class StringOrIntSerializer : IBsonSerializer
    {
        public Type ValueType => typeof(string);

        public object Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
        {
            switch (context.Reader.CurrentBsonType)
            {
                case MongoDB.Bson.BsonType.String:
                    return context.Reader.ReadString();
                case MongoDB.Bson.BsonType.Int32:
                    return context.Reader.ReadInt32().ToString();
                case MongoDB.Bson.BsonType.Int64:
                    return context.Reader.ReadInt64().ToString();
                default:
                    return null;
            }
        }

        public void Serialize(BsonSerializationContext context, BsonSerializationArgs args, object value)
        {
            if (value != null)
            {
                context.Writer.WriteString(value.ToString());
            }
            else
            {
                context.Writer.WriteNull();
            }
        }
    }
}
