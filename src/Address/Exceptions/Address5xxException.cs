using System.Net.Http;

namespace Address.Exceptions;

public class Address5xxException : AddressApiException
{
    public Address5xxException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
