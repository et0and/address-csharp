using System;
using System.Net.Http;

namespace Address.Exceptions;

public class AddressException : Exception
{
    public AddressException(string message, Exception? innerException = null)
        : base(message, innerException) { }

    protected AddressException(HttpRequestException? innerException)
        : base(null, innerException) { }
}
