namespace SchoolDashboard
{
    public class Staff : Person
    {
        public string Department { get; set; }

        public Staff() { }

        public Staff(string name, int age, string department)
            : base(name, age)
        {
            Department = department;
        }

        public override string GetDetails() =>
            $"[Staff] {Name}, Age {Age}, Department: {Department}";
    }
}
