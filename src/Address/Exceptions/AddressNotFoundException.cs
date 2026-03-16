using System.Net.Http;

namespace Address.Exceptions;

public class AddressNotFoundException : Address4xxException
{
    public AddressNotFoundException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
