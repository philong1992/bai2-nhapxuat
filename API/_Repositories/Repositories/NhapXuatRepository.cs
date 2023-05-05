using API.Models;
using API._Repositories.Interfaces;
using API.Data;
namespace API._Repositories.Repositories
{
    public class NhapXuatRepository : Repository<NhapXuat>, INhapXuatRepository
    {
        private DataContext _context;
        public NhapXuatRepository(DataContext context) : base(context)
        {
            _context = context;
        }
    }
}