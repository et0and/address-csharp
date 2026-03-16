using System;

namespace Address.Core;

readonly record struct SecurityOptions
{
    public SecurityOptions() { }

    public Boolean ApiKey { get; init; } = false;

    public static SecurityOptions All() => new() { ApiKey = true };
}
