using System;
using System.Threading;
using System.Threading.Tasks;
using Address.Core;
using Address.Models.RequestKey;

namespace Address.Services;

/// <summary>
/// Health and API key onboarding endpoints that do not require authentication.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IRequestKeyService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IRequestKeyServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IRequestKeyService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Submit a proof-of-work solution to obtain an API key. The request must include a
    /// valid nonce that solves the challenge previously obtained from GET /challenge.
    /// This prevents automated abuse while allowing legitimate users to access the API.
    /// </summary>
    Task<RequestKeyCreateResponse> Create(
        RequestKeyCreateParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IRequestKeyService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IRequestKeyServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IRequestKeyServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /request-key</c>, but is otherwise the
    /// same as <see cref="IRequestKeyService.Create(RequestKeyCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<RequestKeyCreateResponse>> Create(
        RequestKeyCreateParams parameters,
        CancellationToken cancellationToken = default
    );
}
