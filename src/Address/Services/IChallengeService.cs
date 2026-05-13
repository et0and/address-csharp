using System;
using System.Threading;
using System.Threading.Tasks;
using Address.Core;
using Address.Models.Challenge;

namespace Address.Services;

/// <summary>
/// Health and API key onboarding endpoints that do not require authentication.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IChallengeService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IChallengeServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IChallengeService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a cryptographic challenge for proof-of-work based API key registration.
    /// The challenge must be solved by finding a nonce that, when combined with the
    /// challenge data, produces a hash below the difficulty threshold. Use this
    /// challenge with the POST /request-key endpoint to obtain an API key.
    /// </summary>
    Task<ChallengeRetrieveResponse> Retrieve(
        ChallengeRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IChallengeService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IChallengeServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IChallengeServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /challenge</c>, but is otherwise the
    /// same as <see cref="IChallengeService.Retrieve(ChallengeRetrieveParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ChallengeRetrieveResponse>> Retrieve(
        ChallengeRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
