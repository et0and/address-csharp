using System.Net.Http;

namespace Address.Exceptions;

public class AddressUnauthorizedException : Address4xxException
{
    public AddressUnauthorizedException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
