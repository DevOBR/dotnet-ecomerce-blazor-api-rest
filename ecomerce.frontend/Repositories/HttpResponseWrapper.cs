using System.Net;

namespace ecomerce.frontend.Repositories;

public class HttpResponseWrapper<T>
{
    public HttpResponseWrapper(T? response, bool error, HttpResponseMessage httpResponseMessage)
    {
        Response = response;
        Error = error;
        HttpResponseMessage = httpResponseMessage;
    }

    public T? Response { get; }
    public bool Error { get; }
    public HttpResponseMessage HttpResponseMessage { get; }

    public async Task<string?> GeterrorMessageAsync()
    {
        if (!Error)
        {
            return null;
        }

        var statusCode = HttpResponseMessage.StatusCode;
        if (statusCode == HttpStatusCode.NotFound)
        {
            return "Data not found";
        }

        if (statusCode == HttpStatusCode.BadRequest)
        {
            return await HttpResponseMessage.Content.ReadAsStringAsync();
        }

        if (statusCode == HttpStatusCode.Unauthorized)
        {
            return "You need to be logged in to run this operation.";
        }

        if (statusCode == HttpStatusCode.Forbidden)
        {
            return "You don not have permissions to do this operation.";
        }

        return "There was an unexpected error.";
    }

}
