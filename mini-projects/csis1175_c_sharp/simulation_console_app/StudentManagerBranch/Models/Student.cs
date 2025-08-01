namespace StudentManagerBranch.Models
{
    public class Student : Person
    {
        public string Major { get; set; }

        public override string GetDetails()
            => base.GetDetails() + $", Major: {Major}";
    }
}
