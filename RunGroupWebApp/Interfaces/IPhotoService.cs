using CloudinaryDotNet.Actions;

namespace RunGroupWebApp.Interfaces
{
    public interface IPhotoService
    {
        Task<ImageUploadResult> AddPhotoAsync(IFormFile file);
        Task<DeletionResult> DelePhotoAsync(string publicId);

    }
}
