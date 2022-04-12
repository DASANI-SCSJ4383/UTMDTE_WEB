using System.Text.Json;
using System.Text.Json.Serialization;

namespace UTMDTE_WEB.API
{
    public class JsonSetting
    {
        public static JsonSerializerOptions GetDeserializeSetting()
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                NumberHandling = JsonNumberHandling.AllowReadingFromString
            };

            return options;
        }

        public static JsonSerializerOptions GetSerializeSetting()
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            return options;
        }
    }
}
