// StringExtensions.cs00:5200:52

namespace Cenfotur.WebApi.Extensions
{
    public static class StringExtensions
    {
        public static bool ContainsAny(this int val, params int[] values)
        {
            if (val !=0 || values.Length > 0)
            {
                foreach (int value in values)
                {
                    if(value == val)
                        return true;
                }
            }

            return false;
        }
    }
}