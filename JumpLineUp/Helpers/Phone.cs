
using System.Text.RegularExpressions;

namespace JumpLineUp.Helpers
{
    public static class Phone
    {
        public static string DisplayPhone(string phoneNumber)
        {
            return Regex.Replace(phoneNumber, @"(\d{3})(\d{3})(\d{4})", "$1-$2-$3");
        }




    }
}