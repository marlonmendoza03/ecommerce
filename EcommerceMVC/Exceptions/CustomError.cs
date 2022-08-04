using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;

namespace EcommerceMVC.Exceptions
{
    public class CustomErrors
    {
        [JsonPropertyName("result")]
        public Result? Result { get; set; }
    }

    public class Result
    {

        [JsonPropertyName("message")]
        public string Message { get; set; } = "failed";
    }
}
