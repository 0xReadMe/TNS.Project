using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Windows;
using TNS.Front_end.SUBSCRIBERS.MODELS;

namespace TNS.Front_end;

class ApiContext
{
    public static List<T> Get<T>(string url) 
    {
        using var httpClient = new HttpClient();
        try
        {
            var response = httpClient.GetAsync(url).Result;
            response.EnsureSuccessStatusCode();

            var jsonResponse = response.Content.ReadAsStringAsync().Result;
            var deserializeResponce = JsonSerializer.Deserialize<List<T>>(jsonResponse);

            return deserializeResponce;
        }
        catch (HttpRequestException ex)
        {
            var dialog = new MessageWindow($"Ошибка при получении данных: {ex.Message}");
            throw;
        }
        catch (JsonException ex)
        {
            var dialog = new MessageWindow($"JSON-deserailization error: {ex.Message}");
            throw;
        }
    }

    public static bool Get(string url)
    {
        using var httpClient = new HttpClient();
        try
        {
            var response = httpClient.GetAsync(url).Result;
            response.EnsureSuccessStatusCode();

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else 
            {
                return false;
            }
        }
        catch (HttpRequestException ex)
        {
            var dialog = new MessageWindow($"Ошибка при получении данных: {ex.Message}");
            throw;
        }
        catch (JsonException ex)
        {
            var dialog = new MessageWindow($"JSON-deserailization error: {ex.Message}");
            throw;
        }
    }

    //public static void Put<T>(string url, T model)
    //{
    //    using var httpClient = new HttpClient();
    //    try
    //    {
    //        var response = httpClient.PutAsJsonAsync(url, model);
    //        //if (response.IsSuccessStatusCode)
    //    }
    //    catch (HttpRequestException ex)
    //    {
    //        var dialog = new MessageWindow($"Ошибка при обновлении данных: {ex.Message}");
    //        throw;
    //    }
    //    catch (JsonException ex)
    //    {
    //        var dialog = new MessageWindow($"JSON-serailization error: {ex.Message}");
    //        throw;
    //    }
    //}

    public static void Post<T>(string url, T model)
    {
        using var httpClient = new HttpClient();
        try
        {
            var response = httpClient.PostAsJsonAsync(url, model);
        }
        catch (HttpRequestException ex)
        {
            var dialog = new MessageWindow($"Ошибка при добавлении данных: {ex.Message}");
            throw;
        }
        catch (JsonException ex)
        {
            var dialog = new MessageWindow($"JSON-serailization error: {ex.Message}");
            throw;
        }
    }

    public static void Delete(string url)
    {
        using var httpClient = new HttpClient();
        try
        {
            var response = httpClient.DeleteAsync(url);
        }
        catch (HttpRequestException ex)
        {
            var dialog = new MessageWindow($"Ошибка при удалении: {ex.Message}");
            throw;
        }
        catch (JsonException ex)
        {
            var dialog = new MessageWindow($"JSON-deserailization error: {ex.Message}");
            throw;
        }
    }
}