using StudentPortal.Models;

namespace StudentPortal.Services
{
    public class StudentRepository
    {
        private readonly List<Student> students = new();

        public IReadOnlyList<Student> Students => students;

        public void Add(Student student) => students.Add(student);

        public IEnumerable<Student> FindByMajor(string major) =>
            students.Where(s => s.Major.Equals(major, StringComparison.OrdinalIgnoreCase));

        public Student? FindByName(string name) =>
            students.FirstOrDefault(s => s.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

        public IEnumerable<string> GetMajors() => students.Select(s => s.Major).Distinct();

        public void DisplayStats()
        {
            var grouped = students.GroupBy(s => s.Major);
            foreach (var group in grouped)
            {
                Console.WriteLine($"{group.Key} - Count: {group.Count()}, Avg Age: {group.Average(s => s.Age):F1}");
            }
        }

        public async Task SaveToFileAsync(string path)
        {
            using StreamWriter writer = new(path);
            foreach (var student in students)
                await writer.WriteLineAsync(student.ToCsv());
        }

        public async Task LoadFromFileAsync(string path)
        {
            students.Clear();
            if (!File.Exists(path)) return;
            var lines = await File.ReadAllLinesAsync(path);
            foreach (var line in lines)
                students.Add(Student.FromCsv(line));
        }
    }
}
