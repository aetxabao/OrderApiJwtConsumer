using System.Text.Json;
using System.Text.Json.Serialization;

namespace OrderApiJwtConsumer.Items
{
    public class LoginResponse
    {
        [JsonPropertyName("username")]
        public string UserName { get; set; }
        [JsonPropertyName("firstName")]
        public string FirstName { get; set; }
        [JsonPropertyName("lastName")]
        public string LastName { get; set; }
        [JsonPropertyName("token")]
        public string Token { get; set; }

        public string ToJson()
        {
            return JsonSerializer.Serialize(this);
        }

        public static LoginResponse FromJson(string json)
        {
            return JsonSerializer.Deserialize<LoginResponse>(json);
        }

    }

}
