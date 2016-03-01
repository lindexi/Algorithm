namespace Algorithm.Model
{
    public class common_divisor
    {
        private int i = 0;
        public int euler(int m,int n)
        {
            i++;
            if (i > 1000)
            {
                return -1;
            }
            return n == 0 ? m : euler(n, m%n);
        }
    }
}
