using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Address.Core;
using Address.Models.Search;

namespace Address.Services;

/// <summary>
/// Full-text address search and reverse geocoding powered by FTS5 with abbreviation expansion.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface ISearchService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ISearchServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ISearchService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Search addresses using full-text search with intelligent query processing.
    ///
    /// <para>**Search features:** - FTS5 full-text search with ranking by relevance
    /// - Automatic abbreviation expansion (e.g., "st" → "street", "rd" → "road")
    /// - Fuzzy matching fallback for typos and variations - Address component matching
    /// (street, suburb, city, postcode)</para>
    ///
    /// <para>**Query parameters:** - `q`: Search query string (required) - `limit`:
    /// Maximum results (default: 100, max: 1000) - `format`: Response format - "full"
    /// or "simple"</para>
    ///
    /// <para>**Examples:** - `/v1/search?q=lambton+quay` - Search for addresses on
    /// Lambton Quay - `/v1/search?q=123+quay+st+auckland` - Search for specific
    /// address - `/v1/search?q=wlg&limit=20` - Abbreviation expansion</para>
    /// </summary>
    Task<List<SearchQueryResponse>> Query(
        SearchQueryParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ISearchService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ISearchServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ISearchServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for `get /v1/search`, but is otherwise the
    /// same as <see cref="ISearchService.Query(SearchQueryParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<List<SearchQueryResponse>>> Query(
        SearchQueryParams parameters,
        CancellationToken cancellationToken = default
    );
}
