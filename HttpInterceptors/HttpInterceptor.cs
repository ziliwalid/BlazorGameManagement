using Blazored.LocalStorage;
using System.Net.Http.Headers;

namespace frontendApi.HttpInterceptors
{
    public class HttpInterceptor : DelegatingHandler
    {
        private readonly ILocalStorageService _localStorage;

        public HttpInterceptor(ILocalStorageService localStorage) : base(new HttpClientHandler())
        {
            _localStorage = localStorage;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            // Check if a token is stored locally
            if (await _localStorage.ContainKeyAsync("AuthToken"))
            {
                // Retrieve the token and add it to the request headers
                var token = await _localStorage.GetItemAsync<string>("AuthToken");
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }

            // Continue with the request pipeline
            return await base.SendAsync(request, cancellationToken);
        }
    
}
}
