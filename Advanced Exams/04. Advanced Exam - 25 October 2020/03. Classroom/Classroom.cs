using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassroomProject
{
    public class Classroom
    {
        private List<Student> students;

        public Classroom(int capacity)
        {
            this.Capacity = capacity;
            this.students = new List<Student>();
        }

        public int Capacity { get; private set; }

        public int Count 
        { 
            get { return this.students.Count; }
        }

        public string RegisterStudent(Student student)
        {
            string message = string.Empty;

            if (this.students.Count < this.Capacity)
            {
                this.students.Add(student);
                message = $"Added student {student.FirstName} {student.LastName}";
            }
            else
            {
                message = "No seats in the classroom";
            }

            return message;
        }

        public string DismissStudent(string firstName, string lastName)
        {
            string message = string.Empty;

            if (this.students.Any(s => s.FirstName == firstName) 
                && this.students.Any(s => s.LastName == lastName))
            {
                message = $"Dismissed student {firstName} {lastName}";
            }
            else
            {
                message = "Student not found";
            }

            return message;
        }

        public string GetSubjectInfo(string subject)
        {
            StringBuilder sb = new StringBuilder();            

            if (this.students.Any(s => s.Subject == subject))
            {
                sb.AppendLine($"Subject: {subject}");
                sb.AppendLine("Students:");

                foreach (var student in this.students.Where(s => s.Subject == subject))
                {
                    sb.AppendLine($"{student.FirstName} {student.LastName}");
                }                
            }
            else
            {
                sb.AppendLine("No students enrolled for the subject");
            }

            return sb.ToString().TrimEnd();
        }

        public int GetStudentsCount()
        {
            return this.Count;
        }

        public Student GetStudent(string firstName, string lastName)
        {
            object correctStudent = new object();

            foreach (var student in this.students)
            {
                if (student.FirstName == firstName && student.LastName == lastName)
                {
                    correctStudent = student;
                }
            }

            return (Student) correctStudent;
        }
    }
}
