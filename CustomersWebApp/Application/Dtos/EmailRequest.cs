using System.Text.Json.Serialization;

namespace CustomersWebApp.Application.Dtos;

public class EmailRequest
{
    [JsonPropertyName("email_address")]
    public string EmailAddress {  get; set; }
}
