namespace hdungx99.Core.Auth.AuthClientDI
{
    public interface IAuthClient
    {
        Task<HttpClient> GetClient();
    }
}
