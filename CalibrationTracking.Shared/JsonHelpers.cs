using Newtonsoft.Json;

namespace CalibrationTracking.Shared
{
    public static class JsonHelpers
    {
        public static T GetJsonResourceAsObject<T>(byte[] bytes)
        {
            string streamResult;

            using (StreamReader reader = new StreamReader(new MemoryStream(bytes)))
            {
                streamResult = reader.ReadToEnd();
            }

            var jsonResult = JsonConvert.DeserializeObject<T>(streamResult);

            if (jsonResult == null) throw new ArgumentNullException(nameof(bytes));

            return jsonResult;
        }
    }
}
