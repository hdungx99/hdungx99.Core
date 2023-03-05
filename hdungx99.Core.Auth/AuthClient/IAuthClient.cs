namespace hdungx99.Core.Auth.AuthClient
{
    public interface IAuthClient
    {
        Task<HttpClient> GetClient();
    }
}
