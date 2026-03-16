using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Address.Core;
using Address.Models.Meta;

namespace Address.Services;

/// <inheritdoc/>
public sealed class MetaService : IMetaService
{
    readonly Lazy<IMetaServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IMetaServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IAddressClient _client;

    /// <inheritdoc/>
    public IMetaService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new MetaService(this._client.WithOptions(modifier));
    }

    public MetaService(IAddressClient client)
    {
        _client = client;

        _withRawResponse = new(() => new MetaServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<MetaRetrieveResponse> Retrieve(
        MetaRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class MetaServiceWithRawResponse : IMetaServiceWithRawResponse
{
    readonly IAddressClientWithRawResponse _client;

    /// <inheritdoc/>
    public IMetaServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new MetaServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public MetaServiceWithRawResponse(IAddressClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<MetaRetrieveResponse>> Retrieve(
        MetaRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<MetaRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var meta = await response
                    .Deserialize<MetaRetrieveResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    meta.Validate();
                }
                return meta;
            }
        );
    }
}
