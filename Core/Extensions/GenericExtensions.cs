using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Techpork.Core.Extensions
{
    public static class GenericExtensions
    {
        public static string AddBasePath(this string uri, HttpContext context)
        {
            string protocol = context.Request.Protocol.ToLower();
            protocol = protocol.Split("/")[0];
            string host = context.Request.Host.Value;
            string isHttps = context.Request.IsHttps ? "s" : "";
            return protocol + isHttps + "://" + host + "/" + uri;
        }

        public static bool IsValidEmail(this string email)
        {
            Regex rx = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
            var match = rx.Match(email);
            return match.Success;
        }

        public static string Capitalize(this string str)
        {
            return char.ToUpper(str[0]) + str.Substring(1);
        }

        public static string ToTimestamp(this DateTime value)
        {
            return value.ToString("yyyyMMddHHmmssffff");
        }

        public static bool IsNotNullString(this string media)
        {
            return !string.IsNullOrEmpty(media);
        }


        public static bool IsNotUrl(this string media)
        {
            return !media.Contains("http://") && !media.Contains("https://");
        }

        public static string RemoveBearer(this string token)
        {
            bool bearerPresent = token.Contains(" ");
            if (bearerPresent)
            {
                string[] splitJWT = token.Split(" ");
                token = splitJWT[1];
            }
            return token;
        }

        public static T ToNumber<T>(this string num) where T : struct
        {
            if ((typeof(T).Name.ToLower().Contains("double")
                || typeof(T).Name.ToLower().Contains("int"))
                && num[0] != '-')
            {
                return (T)Convert.ChangeType(num, typeof(T));
            }
            return (T)Convert.ChangeType(0, typeof(T));
        }
    }
}
