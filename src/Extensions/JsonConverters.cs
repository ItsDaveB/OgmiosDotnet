using System.Numerics;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Ogmios.Extensions
{
    public static class JsonConverters
    {
        public class BigIntegerJsonConverter : JsonConverter<BigInteger>
        {
            public override BigInteger Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                _ = BigInteger.TryParse(reader.GetString(), out BigInteger result);
                return result;
            }

            public override void Write(Utf8JsonWriter writer, BigInteger bigIntegerValue, JsonSerializerOptions options)
            {
                writer.WriteRawValue(bigIntegerValue.ToString(), skipInputValidation: true);
            }
        }
    }
}