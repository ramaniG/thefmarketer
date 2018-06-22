using Microsoft.AspNetCore.Http;
using System.Linq;

namespace Fmarketer.Base
{
    public class Helper
    {
        public static string GetTokenFromRequest(HttpRequest request)
        {

            if (!request.Headers.TryGetValue("Token", out var headerValue)) return null;

            var key = headerValue.FirstOrDefault();

            return key;
        }
    }
}
