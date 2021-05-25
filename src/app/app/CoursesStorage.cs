using System;
using System.IO;
using System.Text;

namespace app
{
    class CoursesStorage
    {
        private Course[] courses;
        private string filename = "course.csv";

        public CoursesStorage(int size)
        {
            this.courses = new Course[size];
        }

        public void Add(Course course, int index)
        {
            this.courses[index] = course;
        }

        public void Sort()
        {
            CoursesComparer comparer = new CoursesComparer();
            Array.Sort(this.courses, 0, this.courses.Length, comparer);
        }

        public void Store()
        {
            if (!File.Exists(this.filename))
                File.Create(this.filename);

            string[] data = this.GetWriteableCourses();
            Encoding encoding = Encoding.GetEncoding(1251);
            File.WriteAllLines(this.filename, data, encoding);
        }

        protected string[] GetWriteableCourses()
        {
            string[] result = new string[this.courses.Length + 1];
            result[0] = "Название;Время приготовления;Цена";

            for (int i = 1; i < result.Length; i++)
            {
                result[i] = this.FormatCourse(this.courses[i - 1]);
            }

            return result;
        }

        protected string FormatCourse(Course course)
        {
            return String.Format(
                "{0};{1};{2}",
                course.Name,
                course.CookingTime,
                course.Price
            );
        }
    }
}
