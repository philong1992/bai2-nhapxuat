using API.Models;

namespace API._Services.Interfaces
{
    public interface IHomeService
    {
        Task<List<NhapXuat>> GetData(string searchStr);
        Task<bool> Add(NhapXuat model);
        Task<bool> Delete(NhapXuat model);
        Task<bool> DeleteSP(string sophieu);
    }
}