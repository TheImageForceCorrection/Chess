using System.IO;
using Newtonsoft.Json;

namespace Chess.Utilities.JsonSerialization
{
    public static class JsonResponse
    {
        public static ReturnType DeserializeResponse<ReturnType>(string response)
        {
            var jsonSerializer = JsonSerializer.Create();
            var stringReader = new StringReader(response);
            return (ReturnType)jsonSerializer.Deserialize(stringReader, typeof(ReturnType));
        }

        public static string SerializeResponse(object response)
        {
            var jsonSerializer = JsonSerializer.Create();
            var stringWriter = new StringWriter();
            jsonSerializer.Serialize(stringWriter, response);
            return stringWriter.ToString();
        }
    }
}
