using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PicPaySimplificado.Core.Models;

public class Authorized
{
    [JsonPropertyName("status")]
    public string Status { get; set; } = string.Empty;
    [JsonPropertyName("data")]
    public AuthorizeData? Data { get; set; }

}
public class AuthorizeData
{
    [JsonPropertyName("authorization")]
    public bool Authorization { get; set; }
}
