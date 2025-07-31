using StudentManagerBranch;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace StudentManagerBranch
{
    public class PersonConverter : JsonConverter<Person>
    {
        public override Person Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            using var jsonDoc = JsonDocument.ParseValue(ref reader);
            var jsonObject = jsonDoc.RootElement;

            if (!jsonObject.TryGetProperty("Type", out var typeProp))
                throw new JsonException("Missing Type discriminatior");

            var typeValue = typeProp.GetString();
            return typeValue switch
            {
                "Student" => JsonSerializer.Deserialize<Student>(jsonObject.GetRawText(), options),
                "Teacher" => JsonSerializer.Deserialize<Teacher>(jsonObject.GetRawText(), options),
                _ => throw new JsonException($"Unknown type: {typeValue}"),
            };
        }
        public override void Write(Utf8JsonWriter writer, Person value, JsonSerializerOptions options)
        {
            var type = value switch
            {
                Student => "Student",
                Teacher => "Teacher",
                _ => "Person",
            };
            using var jsonDoc = JsonDocument.Parse(JsonSerializer.Serialize(value, value.GetType(), options));
            writer.WriteStartObject();
            writer.WriteString("Type", type);
            foreach (var prop in jsonDoc.RootElement.EnumerateObject())
            {
                prop.WriteTo(writer);
            }
            writer.WriteEndObject();
        }
    }
}
