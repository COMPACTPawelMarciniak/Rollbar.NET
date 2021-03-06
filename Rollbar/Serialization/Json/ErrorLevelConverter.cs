﻿namespace Rollbar.Serialization.Json
{
    using System;
    using Newtonsoft.Json;

#pragma warning disable CS1584 // XML comment has syntactically incorrect cref attribute
#pragma warning disable CS1658 // Warning is overriding an error
    /// <summary>
    /// ErrorLevelConverter simplifies ErrorLevel Json de/serialization.
    /// </summary>
    /// <seealso cref="Rollbar.Serialization.Json.JsonConverter{Rollbar.ErrorLevel}" />
    public class ErrorLevelConverter 
#pragma warning restore CS1658 // Warning is overriding an error
#pragma warning restore CS1584 // XML comment has syntactically incorrect cref attribute
        : JsonConverter<ErrorLevel>
    {

        /// <summary>
        /// Writes the json.
        /// </summary>
        /// <param name="writer">The writer.</param>
        /// <param name="value">The value.</param>
        /// <param name="serializer">The serializer.</param>
        public override void WriteJson(
            JsonWriter writer, 
            ErrorLevel value, 
            JsonSerializer serializer
            )
        {
            writer.WriteValue(value.ToString().ToLower());
        }

        /// <summary>
        /// Reads the json.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <param name="existingValue">The existing value.</param>
        /// <param name="serializer">The serializer.</param>
        /// <returns></returns>
        /// <exception cref="JsonSerializationException">
        /// </exception>
        public override ErrorLevel ReadJson(
            JsonReader reader, 
            ErrorLevel existingValue, 
            JsonSerializer serializer
            )
        {
            string value;
            try
            {
                value = (string)reader.Value;
            }
            catch
            {
                var valueType = reader.Value == null ? null : reader.Value.GetType();
                var msg = string.Format("Could not convert JsonReader value ({0}, type {1}) to an string", reader.Value, valueType);
                throw new JsonSerializationException(msg);
            }

            if (!string.IsNullOrWhiteSpace(value))
            {
                var chars = value.ToCharArray();
                chars[0] = Char.ToUpper(chars[0]);
                value = new string(chars);
            }

            if (Enum.TryParse(value, true, out ErrorLevel level))
            {
                return level;
            }

            throw new JsonSerializationException(string.Format("Could not convert {0} to an ErrorLevel", value));
        }
    }
}