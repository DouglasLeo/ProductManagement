using System.IO;
using System.Threading.Tasks;

namespace ProductManagement.Domain.Interfaces
{
    public interface IImportFileService
    {
        Task Import(Stream fileStream);
    }
}