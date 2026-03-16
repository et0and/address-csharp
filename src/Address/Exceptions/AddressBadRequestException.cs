using System.Net.Http;

namespace Address.Exceptions;

public class AddressBadRequestException : Address4xxException
{
    public AddressBadRequestException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
