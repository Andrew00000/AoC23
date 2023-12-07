namespace Day7
{
    public class HandStrengthComparer : IComparer<Hand>
    {
        public int Compare(Hand? x, Hand? y)
        {
            if (x is null || y is null)
            {
                throw new ArgumentNullException();
            }


            if (x.IsStrongerThan(y))
            {
                return 1;
            }
            else if (y.IsStrongerThan(x))
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }
}
