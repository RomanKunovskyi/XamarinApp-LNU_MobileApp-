using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace xamarin_mobile_app.ExtantionClasses
{
    public static class StringExtentions
    {
        public static T ConvertFromEscapedString<T>(this string str)
        {
            var settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All
            };

            string unescapedString = Uri.UnescapeDataString(str);

            var targetObject = JsonConvert.DeserializeObject<T>(unescapedString, settings);

            return targetObject;
        }
    }
}
