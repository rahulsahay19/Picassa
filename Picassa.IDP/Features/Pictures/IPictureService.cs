namespace Picassa.IDP.Features.Pictures
{
    using System.Threading.Tasks;
    public interface IPictureService
    {
        Task<int> Create(string imageUrl, string description, string userId);
    }
}
