using System.Net.Http;

namespace Address.Exceptions;

public class Address4xxException : AddressApiException
{
    public Address4xxException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
