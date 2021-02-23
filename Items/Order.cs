using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace OrderApiJwtConsumer.Items
{
    public class Order
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("status")]
        public string Status { get; set; }
        [JsonPropertyName("quantity")]
        public int Quantity { get; set; }
        [JsonPropertyName("total")]
        public decimal Total { get; set; }
        [JsonPropertyName("currency")]
        public string Currency { get; set; }
        [JsonPropertyName("ts")]
        public string TS { get; set; }
        [JsonPropertyName("customerId")]
        public int CustomerId { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}\nStatus: {Status}\nQuantity: {Quantity}\nTotal: {Total}\nCurrency: {Currency}\nTS: {TS}";
        }

        public string ToJson()
        {
            return JsonSerializer.Serialize(this);
        }

        public static Order FromJson(string json)
        {
            return JsonSerializer.Deserialize<Order>(json);
        }

        public static List<Order> ListFromJson(string json)
        {
            return JsonSerializer.Deserialize<List<Order>>(json);
        }

    }

}
