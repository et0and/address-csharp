using System;
using System.Threading;
using System.Threading.Tasks;
using Address.Core;
using Address.Models.Health;

namespace Address.Services;

/// <summary>
/// Health, API information, and API key onboarding endpoints that do not require authentication.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IHealthService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IHealthServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IHealthService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a simple OK response to verify the API is operational. This endpoint
    /// does not require authentication and is useful for monitoring and load balancer
    /// health checks.
    /// </summary>
    Task<HealthCheckResponse> Check(
        HealthCheckParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IHealthService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IHealthServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IHealthServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for `get /health`, but is otherwise the
    /// same as <see cref="IHealthService.Check(HealthCheckParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<HealthCheckResponse>> Check(
        HealthCheckParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
