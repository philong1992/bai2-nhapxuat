using API._Repositories.Interfaces;
using API._Services.Interfaces;
using API.Data;
using API.Models;
using LinqKit;
using Microsoft.EntityFrameworkCore;

namespace API._Services.Services
{
    public class HomeService : IHomeService
    {
        private readonly INhapXuatRepository _repo;
        public HomeService(INhapXuatRepository repo) {
            _repo = repo;
        }

        public async Task<bool> Add(NhapXuat model)
        {
            var checkItem = await _repo.FindSingle(x => x.SoPhieu.Trim() == model.SoPhieu.Trim() &&
                                                        x.MaVt.Trim() == model.MaVt.Trim());
            if(checkItem != null) {
                return false;
            } else {
                _repo.Add(model);
                return await _repo.Save();
            }
        }

        public async Task<bool> Delete(NhapXuat model)
        {
            var dataFind = await _repo.FindSingle(x => x.SoPhieu.Trim() == model.SoPhieu.Trim() &&
                                    x.MaVt.Trim() == model.MaVt.Trim());
            if(dataFind != null) {
                _repo.Remove(dataFind);
            }
            return await _repo.Save();
        }

        public async Task<bool> DeleteSP(string sophieu)
        {
            var dataDelete = await _repo.FindAll(x => x.SoPhieu.Trim() == sophieu.Trim()).ToListAsync();
            if(dataDelete.Any()) {
                _repo.RemoveMultiple(dataDelete);
                return await _repo.Save();
            } else {
                return false;
            }
        }

        public async Task<List<NhapXuat>> GetData(string searchStr) {
            var predNhapXuat = PredicateBuilder.New<NhapXuat>(true);
            if(!string.IsNullOrEmpty(searchStr)) {
                predNhapXuat = predNhapXuat.And(x => x.MaVt.Contains(searchStr) || x.TenVt.Contains(searchStr));
            }
            var data = await _repo.FindAll(predNhapXuat).ToListAsync();
            return data;
        }
    }
}