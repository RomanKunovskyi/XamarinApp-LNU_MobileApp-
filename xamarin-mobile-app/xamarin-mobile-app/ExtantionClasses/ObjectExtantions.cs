using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace xamarin_mobile_app.ExtantionClasses
{
    public static class ObjectExtantions
    {
        public static string ConvertToEscapedString(this object obj)
        {
            var settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All
            };

            string serializedObject = JsonConvert.SerializeObject(obj, settings);

            string encodedObject = Uri.EscapeDataString(serializedObject);

            return encodedObject;
        }
    }
}
