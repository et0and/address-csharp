using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Address.Core;
using Address.Models.Reverse;

namespace Address.Services;

/// <summary>
/// Full-text address search and reverse geocoding powered by FTS5 with abbreviation expansion.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IReverseService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IReverseServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IReverseService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Find the nearest addresses to given geographic coordinates (reverse geocoding).
    ///
    /// <para>**Query parameters:** - `lat`: Latitude in decimal degrees (required)
    /// - `lng`: Longitude in decimal degrees (required) - `limit`: Maximum number
    /// of results (default: 10, max: 100) - `format`: Response format - "full" or "simple"</para>
    ///
    /// <para>**Distance calculation:** Results are sorted by distance from the provided
    /// coordinates, calculated using the Haversine formula for spherical distance
    /// on Earth.</para>
    ///
    /// <para>**Example:** `/v1/reverse?lat=-41.2865&lng=174.7762&limit=5`</para>
    /// </summary>
    Task<List<ReverseGeocodeResponse>> Geocode(
        ReverseGeocodeParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IReverseService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IReverseServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IReverseServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for `get /v1/reverse`, but is otherwise the
    /// same as <see cref="IReverseService.Geocode(ReverseGeocodeParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<List<ReverseGeocodeResponse>>> Geocode(
        ReverseGeocodeParams parameters,
        CancellationToken cancellationToken = default
    );
}
