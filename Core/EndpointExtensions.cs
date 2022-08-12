namespace EFCoreRelationshipsApi.Core;

public static class EndpointExtensions
{
    
    public static IEndpointRouteBuilder MapEndpoint(this IEndpointRouteBuilder app, 
        IEndpoint endpoint) 
    {

        app.MapMethods(endpoint.Pattern, 
                       new[] { endpoint.Method.ToString() },
                       endpoint.Handler);            

        return app;
    }

    public static IEndpointRouteBuilder MapEndpoints(this IEndpointRouteBuilder app,
        params IEndpoint[] endpoints) 
    {
        foreach (var endpoint in endpoints)
        {
            app.MapEndpoint(endpoint);
        }

        return app;
    }

}
