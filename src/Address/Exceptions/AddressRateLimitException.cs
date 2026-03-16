using System.Net.Http;

namespace Address.Exceptions;

public class AddressRateLimitException : Address4xxException
{
    public AddressRateLimitException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
