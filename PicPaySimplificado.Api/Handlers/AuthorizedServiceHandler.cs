using System.Text.Json;
using System.Text.Json.Serialization;
using PicPaySimplificado.Core;
using PicPaySimplificado.Core.Handlers;
using PicPaySimplificado.Core.Models;
using PicPaySimplificado.Core.Requests;
using PicPaySimplificado.Core.Responses;

namespace PicPaySimplificado.Api.Handlers;

public class AuthorizedServiceHandler(IHttpClientFactory httpClientFactory) : IAuthorizedServiceHandler
{
    private readonly HttpClient httpClient = httpClientFactory.CreateClient(Configuration.HttpClientName);

    public async Task<Response<Authorized>?> GetAuthorizedAsync()
    {
        try
        {
            var result = await httpClient.GetFromJsonAsync<Authorized>("api/v2/authorize");
            return new Response<Authorized>(result, 200);
        }
        catch (Exception ex)
        {
            return new Response<Authorized>(null, 400, ex.Message);
        }
    }

    public async Task<Response<bool>> NotifyUsers(TransferRequest request)
    {
        try
        {
            var jsonNotify = new 
            {
                Payer = request.Payer,
                Payee = request.Payee,
                Value = request.Value,
                Message = "Transaferencia realizada com sucesso."
            };
            var httpResponseMessage = await httpClient.PostAsJsonAsync("api/v1/notify", jsonNotify);

            if(!httpResponseMessage.IsSuccessStatusCode)
            {
                var result = JsonSerializer.Deserialize<NotifyErrorResponse>(await httpResponseMessage.Content.ReadAsStringAsync());
                return new Response<bool>(false, (int)httpResponseMessage.StatusCode, result?.Message);
            }
            return new Response<bool>(true, 200);
        }
        catch (Exception ex)
        {
            return new Response<bool>(false, 400, ex.Message);
        }     
    }
}