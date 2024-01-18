using Blazored.LocalStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;


public class AuthenticationService : IAuthenticationService
{
    public HttpClient Http { get; }
    public ILocalStorageService LocalStorage { get; }

    public AuthenticationService(HttpClient http, ILocalStorageService localStorage)
    {
        Http = http;
        LocalStorage = localStorage;
    }


    public string test()
    {
        return "hello from authServic";
    }


    public async Task<TokenResponse> Login(string username, string password)
    {
        var loginModel = new
        {
            Email = username,
            Password = password
        };

        var response = await this.Http.PostAsJsonAsync("api/App/login", loginModel);
        if (!response.IsSuccessStatusCode)
            throw new Exception("Login failed");

        var token = await response.Content.ReadFromJsonAsync<TokenResponse>();
        //store the token in local storage
        await LocalStorage.SetItemAsStringAsync("AuthToken", token!.Token);
        return token;

    }
}


