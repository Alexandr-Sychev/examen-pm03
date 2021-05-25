using System;

namespace app
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = GetPositiveInt("Введите длину массива");
            CoursesStorage coursesStorage = new CoursesStorage(size);

            for (int i = 0; i < size; i++)
            {
                Course newCourse = new Course();
                FillCourse(newCourse);
                coursesStorage.Add(newCourse, i);
            }

            coursesStorage.Sort();
            coursesStorage.Store();
        }

        static int GetPositiveInt(string promptMessage)
        {
            string input;
            int result;
            bool success;

            do
            {
                Console.WriteLine(promptMessage);
                input = Console.ReadLine();
                success = Int32.TryParse(input, out result);
            } while (!success || result <= 0);

            return result;
        }

        static float GetPositiveFloat(string promptMessage)
        {
            string input;
            float result;
            bool success;

            do
            {
                Console.WriteLine(promptMessage);
                input = Console.ReadLine();
                success = float.TryParse(input, out result);
            } while (!success || result <= 0);

            return result;
        }

        static string GetString(string promptMessage)
        {
            Console.WriteLine(promptMessage);
            return Console.ReadLine();
        }

        static Course FillCourse(Course course)
        {
            course.Name = GetString("Введите название блюда");
            course.Price = GetPositiveFloat("Введите цену блюда");
            course.CookingTime = GetPositiveInt("Введите время приготовления в минутах");

            return course;
        }
    }
}
