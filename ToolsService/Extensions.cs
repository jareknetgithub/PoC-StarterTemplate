using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolsService
{
    public static class Extensions
    {
        public static string Pwd_MakeHash(this string value) 
            => BCrypt.Net.BCrypt.HashPassword(value);  

        public static bool Pwd_Verify(this string value, string pwdhash)
            => BCrypt.Net.BCrypt.Verify(value, pwdhash);

        public static string DB_value(this string? value)
            => string.IsNullOrEmpty(value) ? string.Empty : value;
    }
}
