﻿namespace School
{
    public class Student
    {
        private static int nextStudentId = 1;

        public string Name { get; set; }

        // The ID has been changed to read only. IDs of classes should not change because they are a unique identifier.
        public int StudentId { get; private set; }

        public int NumberOfCredits { get; private set; }

        public double Gpa { get; private set; }

        public Student(string name, int numberOfCredits, double gpa)
        {
            StudentId = nextStudentId++;
            Name = name;
            NumberOfCredits = numberOfCredits;
            Gpa = gpa;
        }

        public Student(string name)
            : this(name, 0, 0) { }

        public void AddGrade(Grade grade, byte credits)
        {
            byte gradePoints;
            switch(grade)
            {
                case Grade.A:
                    gradePoints = 4;
                    break;
                case Grade.B:
                    gradePoints = 3;
                    break;
                case Grade.C:
                    gradePoints = 2;
                    break;
                case Grade.D:
                    gradePoints = 1;
                    break;
                default:
                    gradePoints = 0;
                    break;
            }

            var qualityScore = Gpa * NumberOfCredits;

            NumberOfCredits += credits;

            Gpa = (qualityScore + gradePoints) / NumberOfCredits;
        }

        public GradeLevel GetGradeLevel()
        {
            if (NumberOfCredits <= 29) return GradeLevel.Freshman;
            if (NumberOfCredits <= 59) return GradeLevel.Sophomore;
            if (NumberOfCredits <= 89) return GradeLevel.Junior;
            return GradeLevel.Senior;
        }
    }

}