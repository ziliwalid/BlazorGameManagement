using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


    public interface IAuthenticationService
    {
    HttpClient Http { get; }
    Task<TokenResponse> Login(string username, string password);
}
