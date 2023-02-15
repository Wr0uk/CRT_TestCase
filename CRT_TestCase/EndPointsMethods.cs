using System.Net;
using System.Net.Http.Json;

namespace CRT_TestCase;

public static class EndPointsMethods
{
    public static HttpStatusCode GetAll(string endPoint, out Root? data)
    {
        HttpClient client = new HttpClient();
        var res = client.GetAsync(endPoint).Result;
        var statusCode = res.StatusCode;
        data = res.Content.ReadFromJsonAsync<Root>().Result;
        client.Dispose();
        return statusCode ;
    }
    
    public static HttpStatusCode GetAll(string endPoint)
    {
        HttpClient client = new HttpClient();
        var res = client.GetAsync(endPoint).Result;
        var statusCode = res.StatusCode;
        client.Dispose();
        return statusCode;
    }

    public static HttpStatusCode GetById(string endPoint, uint id, out Root? data)
    {
        HttpClient client = new HttpClient();
        var res = client.GetAsync(endPoint+$"/{id}").Result;
        var statusCode = res.StatusCode;
        data = res.Content.ReadFromJsonAsync<Root>().Result;
        client.Dispose();
        return statusCode;
    }
    public static HttpStatusCode GetById(string endPoint, uint id)
    {
        HttpClient client = new HttpClient();
        var res = client.GetAsync(endPoint+$"/{id}").Result;
        var statusCode = res.StatusCode;
        client.Dispose();
        return statusCode;
    }

    public static HttpStatusCode Put(string endPoint, Book book)
    {
        HttpClient client = new HttpClient();
        PutPostModel data = new PutPostModel(book);
        var res = client.PutAsJsonAsync(endPoint+$"/{book.id}", data).Result;
        var statusCode = res.StatusCode;
        client.Dispose();
        return statusCode;
    }
    public static HttpStatusCode Put(string endPoint, Book book , out Book newBook)
    {
        HttpClient client = new HttpClient();
        PutPostModel data = new PutPostModel(book);
        var res = client.PutAsJsonAsync(endPoint+$"/{book.id}", data).Result;
        var statusCode = res.StatusCode;
        newBook = res.Content.ReadFromJsonAsync<SingleBook>().Result!.book;
        client.Dispose();
        return statusCode;
    }

    public static HttpStatusCode Post(string endPoint, PutPostModel data)
    {
        HttpClient client = new HttpClient();
        var res = client.PostAsJsonAsync(endPoint,data).Result;
        var statusCode = res.StatusCode;
        client.Dispose();
        return statusCode;
    }
    public static HttpStatusCode Post(string endPoint, PutPostModel data, out Book book)
    {
        HttpClient client = new HttpClient();
        var res = client.PostAsJsonAsync(endPoint,data).Result;
        var statusCode = res.StatusCode;
        book = res.Content.ReadFromJsonAsync<SingleBook>().Result!.book;
        client.Dispose();
        return statusCode;
    }

    public static HttpStatusCode Delete(string endPoint, uint id)
    {
        HttpClient client = new HttpClient();
        var res = client.DeleteAsync(endPoint + $"/{id}").Result;
        var statusCode = res.StatusCode;
        client.Dispose();
        return statusCode;
    }
}