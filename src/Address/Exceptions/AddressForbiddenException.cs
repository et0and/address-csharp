using System.Net.Http;

namespace Address.Exceptions;

public class AddressForbiddenException : Address4xxException
{
    public AddressForbiddenException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
