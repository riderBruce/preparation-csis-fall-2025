namespace StudentManagerBranch.Models
{
    public class Teacher : Person
    {
        public string Subject { get; set; }

        public override string GetDetails()
            => base.GetDetails() + $", Subject: {Subject}";
    }
}
