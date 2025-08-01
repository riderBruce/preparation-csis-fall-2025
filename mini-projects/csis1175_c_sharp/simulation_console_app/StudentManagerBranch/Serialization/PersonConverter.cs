using System.Text.Json;
using System.Text.Json.Serialization;
using StudentManagerBranch.Models;

namespace StudentManagerBranch.Serialization
{
    public class PersonConverter : JsonConverter<Person>
    {
        public override Person Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            using var jsonDoc = JsonDocument.ParseValue(ref reader);
            var jsonObject = jsonDoc.RootElement;

            string type = jsonObject.GetProperty("Type").GetString();
            string json = jsonObject.GetRawText();

            return type switch
            {
                "Student" => JsonSerializer.Deserialize<Student>(json),
                "Teacher" => JsonSerializer.Deserialize<Teacher>(json),
                _ => JsonSerializer.Deserialize<Person>(json),
            };
        }

        //public override void Write(Utf8JsonWriter writer, Person value, JsonSerializerOptions options)
        //{
        //    JsonSerializer.Serialize(writer, value switch
        //    {
        //        Student s => new { Type = "Student", s.Name, s.Age, s.Major },
        //        Teacher t => new { Type = "Teacher", t.Name, t.Age, t.Subject },
        //        _ => new { Type = "Person", value.Name, value.Age }
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
