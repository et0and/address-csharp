using System;

namespace Address.Exceptions;

public class AddressInvalidDataException : AddressException
{
    public AddressInvalidDataException(string message, Exception? innerException = null)
        : base(message, innerException) { }
}
