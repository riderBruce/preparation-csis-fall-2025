using System.Text.Json;
using System.Text.Json.Serialization;

namespace SchoolDashboard
{
    public class PersonJsonConverter : JsonConverter<Person>
    {
        public override Person Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            using var jsonDoc = JsonDocument.ParseValue(ref reader);
            var root = jsonDoc.RootElement;

            string type = root.GetProperty("type").GetString() ?? throw new JsonException("Missing type");

            return type.ToLowerInvariant() switch
            {
                "student" => JsonSerializer.Deserialize<Student>(root.GetRawText(), options),
                "teacher" => JsonSerializer.Deserialize<Teacher>(root.GetRawText(), options),
                "staff" => JsonSerializer.Deserialize<Staff>(root.GetRawText(), options),
                _ => throw new JsonException($"Unknown type: {type}")
            };
        }

        //public override void Write(Utf8JsonWriter writer, Person value, JsonSerializerOptions options)
        //{
        //    JsonSerializer.Serialize(writer, value switch
        //    {
        //        Student s => new { type = "student", s.Name, s.Age, s.Major },
        //        Teacher t => new { type = "teacher", t.Name, t.Age, t.Subject },
        //        Staff s => new { type = "staff", s.Name, s.Age, s.Department },
        //        _ => new { type = "person", value.Name, value.Age }
        //    }, options);
        //}
        public override void Write(Utf8JsonWriter writer, Person value, JsonSerializerOptions options)
        {
            if (value is Student student)
            {
                JsonSerializer.Serialize(writer, new
                {
                    type = "student",
                    student.Name,
                    student.Age,
                    student.Major
                }, options);
            }
            else if (value is Teacher teacher)
            {
                JsonSerializer.Serialize(writer, new
                {
                    type = "teacher",
                    teacher.Name,
                    teacher.Age,
                    teacher.Subject
                }, options);
            }
            else if (value is Staff staff)
            {
                JsonSerializer.Serialize(writer, new
                {
                    type = "staff",
                    staff.Name,
                    staff.Age,
                    staff.Department
                }, options);
            }
            else
            {
                JsonSerializer.Serialize(writer, new
                {
                    type = "person",
                    value.Name,
                    value.Age
                }, options);
            }
        }

    }
}
