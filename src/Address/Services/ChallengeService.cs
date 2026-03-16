using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Address.Core;
using Address.Models.Challenge;

namespace Address.Services;

/// <inheritdoc/>
public sealed class ChallengeService : IChallengeService
{
    readonly Lazy<IChallengeServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IChallengeServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IAddressClient _client;

    /// <inheritdoc/>
    public IChallengeService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ChallengeService(this._client.WithOptions(modifier));
    }

    public ChallengeService(IAddressClient client)
    {
        _client = client;

        _withRawResponse = new(() => new ChallengeServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<ChallengeRetrieveResponse> Retrieve(
        ChallengeRetrieveParams? parameters = null,
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
public sealed class ChallengeServiceWithRawResponse : IChallengeServiceWithRawResponse
{
    readonly IAddressClientWithRawResponse _client;

    /// <inheritdoc/>
    public IChallengeServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ChallengeServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ChallengeServiceWithRawResponse(IAddressClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ChallengeRetrieveResponse>> Retrieve(
        ChallengeRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<ChallengeRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var challenge = await response
                    .Deserialize<ChallengeRetrieveResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    challenge.Validate();
                }
                return challenge;
            }
        );
    }
}
