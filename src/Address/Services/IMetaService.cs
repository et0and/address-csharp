using System;
using System.Threading;
using System.Threading.Tasks;
using Address.Core;
using Address.Models.Meta;

namespace Address.Services;

/// <summary>
/// Dataset version, ingestion status, and service metadata.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IMetaService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IMetaServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IMetaService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns metadata about the LINZ NZ Addresses dataset including: - Dataset
    /// version identifier - Last ingestion timestamp - Total record count - Data source
    /// information
    ///
    /// <para>This endpoint is useful for client applications that need to verify data
    /// currency or display dataset attribution.</para>
    /// </summary>
    Task<MetaRetrieveResponse> Retrieve(
        MetaRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IMetaService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IMetaServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IMetaServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/meta</c>, but is otherwise the
    /// same as <see cref="IMetaService.Retrieve(MetaRetrieveParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<MetaRetrieveResponse>> Retrieve(
        MetaRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
