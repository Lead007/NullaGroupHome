using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace NullaGroupHome
{
    public static class JsonHelper
    {
        public static T DeserializeFile<T>(this JavaScriptSerializer serializer, string filePath)
        {
            T result;
            using (var reader = new StreamReader(filePath))
            {
                result = serializer.Deserialize<T>(reader.ReadToEnd());
            }
            return result;
        }

        public static object DeserializeFile(this JavaScriptSerializer serializer, string filePath, Type targetType)
        {
            object result;
            using (var reader = new StreamReader(filePath))
            {
                result = serializer.Deserialize(reader.ReadToEnd(), targetType);
            }
            return result;
        }
    }
}