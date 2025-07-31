using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagerBranch
{
    public static class StudentValidator
    {
        private const int MaxNameLength = 100;
        private const int MaxMajorLength = 50;
        private const int MaxAge = 150;
        private const int MinAge = 0;
        public static bool IsValidName(string name)
            => !string.IsNullOrWhiteSpace(name) 
            && name.Length <= MaxNameLength;
        public static bool IsValidAge(int age)
            => age >= MinAge && age <= MaxAge;
        public static bool IsValidMajor(string major)
            => !string.IsNullOrWhiteSpace(major) 
            && major.Length <= MaxMajorLength;
        public static bool IsValidStudent(Student student)
        {
            if (student == null) return false;

            return IsValidName(student.Name) &&
                   IsValidAge(student.Age) &&
                   IsValidMajor(student.Major);
        }
    }
}
