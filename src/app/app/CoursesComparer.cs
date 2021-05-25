using System.Collections;

namespace app
{
    class CoursesComparer : IComparer
    {
        int IComparer.Compare(object x, object y)
        {
            Course c1 = (Course)x;
            Course c2 = (Course)y;

            if (c1.CookingTime > c2.CookingTime)
                return 1;
            else if (c1.CookingTime == c2.CookingTime)
            {
                if (c1.Price > c2.Price)
                    return 1;
                else if (c1.Price == c2.Price)
                    return 0;
                else
                    return -1;
            }
            else
                return -1;
        }
    }
}
