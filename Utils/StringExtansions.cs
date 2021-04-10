using System;

namespace Utils
{
    public static class StringExtansions
    {
        public static bool IsGoodString(this string checkString) 
        {
            return string.IsNullOrEmpty(checkString) && string.IsNullOrWhiteSpace(checkString);
        }
    }
}
