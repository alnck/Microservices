using System.Text.Json.Serialization;

namespace FreeCourse.Shared.Dtos
{
  public class Response<T>
  {
    public T Data { get; private set; }

    public List<string> Errors { get; set; }

    [JsonIgnore]
    public int StatusCode { get; private set; }
    [JsonIgnore]
    public bool IsSuccessful { get; private set; }

    // Static Factory Methodlar 

    public static Response<T> Success(T data, int statucCode)
    {
      return new Response<T>
      {
        Data = data,
        StatusCode =
        statucCode,
        IsSuccessful = true
      };
    }

    // Update ve Delete işlemlerinde
    public static Response<T> Success(int statusCode)
    {
      return new Response<T>
      {
        Data = default(T),
        StatusCode = statusCode,
        IsSuccessful = true
      };
    }

    // Hata durumunda
    public static Response<T> Fail(List<string> errors, int statusCode)
    {
      return new Response<T>
      {
        Errors = errors,
        StatusCode = statusCode,
        IsSuccessful = true
      };
    }

    public static Response<T> Fail(string error, int statusCode)
    {
      return new Response<T>
      {
        Errors = new List<string>() { error },
        StatusCode = statusCode,
        IsSuccessful = true
      };
    }
  }
}