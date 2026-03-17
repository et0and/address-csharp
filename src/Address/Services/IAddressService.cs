using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Address.Core;
using Address.Models.Addresses;

namespace Address.Services;

/// <summary>
/// Look up and list NZ addresses with filtering, pagination, and address ID lookup.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IAddressService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IAddressServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAddressService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Retrieve a single address record by its LINZ address_id.
    ///
    /// <para>The address_id is a unique identifier assigned by Land Information New
    /// Zealand (LINZ). This is the canonical way to retrieve a specific address when
    /// you know its ID.</para>
    ///
    /// <para>**Response formats:** - Default: Full address object with all LINZ
    /// attributes - Simple (format=simple): Compact representation with essential
    /// fields only</para>
    ///
    /// <para>**Example:** `/v1/addresses/123456?format=simple`</para>
    /// </summary>
    Task<AddressRetrieveResponse> Retrieve(
        AddressRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(AddressRetrieveParams, CancellationToken)"/>
    Task<AddressRetrieveResponse> Retrieve(
        string id,
        AddressRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve a paginated list of addresses with optional filtering by location.
    ///
    /// <para>**Filtering:** - `town_city`: Filter by town/city name (e.g.,
    /// "Wellington") - `suburb_locality`: Filter by suburb/locality (e.g., "Te Aro") -
    /// `road_name`: Filter by road/street name (e.g., "Lambton Quay") - `bbox`:
    /// Bounding box filter as comma-separated coordinates
    /// (min_lon,min_lat,max_lon,max_lat)</para>
    ///
    /// <para>**Pagination:** - `limit`: Maximum number of results (default: 100, max:
    /// 1000) - `offset`: Number of results to skip</para>
    ///
    /// <para>**Example:** `/v1/addresses?town_city=Wellington&limit=50`</para>
    /// </summary>
    Task<List<AddressListResponse>> List(
        AddressListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IAddressService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IAddressServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAddressServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/addresses/{id}</c>, but is otherwise the
    /// same as <see cref="IAddressService.Retrieve(AddressRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<AddressRetrieveResponse>> Retrieve(
        AddressRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(AddressRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<AddressRetrieveResponse>> Retrieve(
        string id,
        AddressRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/addresses</c>, but is otherwise the
    /// same as <see cref="IAddressService.List(AddressListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<List<AddressListResponse>>> List(
        AddressListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
