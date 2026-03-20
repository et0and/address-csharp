using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Address.Core;
using Address.Services;

namespace Address;

/// <summary>
/// A client for interacting with the Address REST API.
///
/// <para>This client performs best when you create a single instance and reuse it
/// for all interactions with the REST API. This is because each client holds its
/// own connection pool and thread pools. Reusing connections and threads reduces
/// latency and saves memory.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IAddressClient : IDisposable
{
    /// <inheritdoc cref="ClientOptions.HttpClient" />
    HttpClient HttpClient { get; init; }

    /// <inheritdoc cref="ClientOptions.BaseUrl" />
    string BaseUrl { get; init; }

    /// <inheritdoc cref="ClientOptions.ResponseValidation" />
    bool ResponseValidation { get; init; }

    /// <inheritdoc cref="ClientOptions.MaxRetries" />
    int? MaxRetries { get; init; }

    /// <inheritdoc cref="ClientOptions.Timeout" />
    TimeSpan? Timeout { get; init; }

    string ApiKey { get; init; }

    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IAddressClientWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAddressClient WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IHealthService Health { get; }

    IChallengeService Challenge { get; }

    IRequestKeyService RequestKey { get; }

    IAddressService Addresses { get; }

    ISearchService Search { get; }

    IReverseService Reverse { get; }

    IMetaService Meta { get; }
}

/// <summary>
/// A view of <see cref="IAddressClient"/> that provides access to raw HTTP responses for each method.
/// </summary>
public interface IAddressClientWithRawResponse : IDisposable
{
    /// <inheritdoc cref="ClientOptions.HttpClient" />
    HttpClient HttpClient { get; init; }

    /// <inheritdoc cref="ClientOptions.BaseUrl" />
    string BaseUrl { get; init; }

    /// <inheritdoc cref="ClientOptions.ResponseValidation" />
    bool ResponseValidation { get; init; }

    /// <inheritdoc cref="ClientOptions.MaxRetries" />
    int? MaxRetries { get; init; }

    /// <inheritdoc cref="ClientOptions.Timeout" />
    TimeSpan? Timeout { get; init; }

    string ApiKey { get; init; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAddressClientWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IHealthServiceWithRawResponse Health { get; }

    IChallengeServiceWithRawResponse Challenge { get; }

    IRequestKeyServiceWithRawResponse RequestKey { get; }

    IAddressServiceWithRawResponse Addresses { get; }

    ISearchServiceWithRawResponse Search { get; }

    IReverseServiceWithRawResponse Reverse { get; }

    IMetaServiceWithRawResponse Meta { get; }

    /// <summary>
    /// Sends a request to the Address REST API.
    /// </summary>
    Task<HttpResponse> Execute<T>(
        HttpRequest<T> request,
        CancellationToken cancellationToken = default
    )
        where T : ParamsBase;
}
