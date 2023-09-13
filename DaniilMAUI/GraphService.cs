using Azure.Identity;
using Microsoft.Graph;
using Microsoft.Graph.Models;

namespace DaniilMAUI
{
    internal class GraphService
    {
        private readonly string[] _scopes = new[] { "User.Read" };
        private const string TenantId = "000e77d6-ddf3-421e-b896-1ce0bbb2d2dd";
        private const string ClientId = "7d69d8e6-05cf-42b6-976a-3f4f233a24a4";
        private GraphServiceClient _client;

        public GraphService()
        {
            Initialize();
        }

        private void Initialize()
        {
            // assume Windows for this sample
            if (OperatingSystem.IsWindows())
            {
                var options = new InteractiveBrowserCredentialOptions
                {
                    TenantId = TenantId,
                    ClientId = ClientId,
                    AuthorityHost = AzureAuthorityHosts.AzurePublicCloud,
                    RedirectUri = new Uri("https://localhost"),
                };

                InteractiveBrowserCredential interactiveCredential = new(options);
                _client = new GraphServiceClient(interactiveCredential, _scopes);
            }
            else
            {
                // TODO: Add iOS/Android support
            }
        }


        public async Task<User> GetMyDetailsAsync()
        {
            try
            {
                return await _client.Me.GetAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading user details: {ex}");
                return null;
            }
        }






    }
}
