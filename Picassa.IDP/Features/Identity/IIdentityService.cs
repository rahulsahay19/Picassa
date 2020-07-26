namespace Picassa.IDP.Features.Identity
{
   public interface IIdentityService
   {
       string CreateJWTToken(string userId, string userName, string secret);
   }
}
