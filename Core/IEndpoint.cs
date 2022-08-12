namespace EFCoreRelationshipsApi.Core;

public interface IEndpoint
{
    string Pattern { get; }

    HttpMethod Method { get; }

    Delegate Handler { get; }

}
