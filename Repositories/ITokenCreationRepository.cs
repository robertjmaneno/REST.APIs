using Microsoft.AspNetCore.Identity;

namespace REST.APIs.Repositories
{
    public interface ITokenCreationRepository
    {

        string TokenCreation(IdentityUser user, List<string> roles);

    }
}
