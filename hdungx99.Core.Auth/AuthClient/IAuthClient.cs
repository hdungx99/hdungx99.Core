using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hdungx99.Core.Auth.AuthClient
{
    public interface IAuthClient
    {
        Task<HttpClient> GetClient();
    }
}
