using System.IO;

namespace Core.Utilities.FileHelper
{
    public interface IFormFile
    {
        int Length { get; set; }
        string FileName { get; }

        void CopyTo(FileStream stream);
    }
}