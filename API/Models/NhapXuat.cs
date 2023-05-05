using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class NhapXuat
    {
        public string SoPhieu { get; set; }
        public DateTime? NgayLapPhieu { get; set; }
        public string MaVt { get; set; }
        public string TenVt { get; set; }
        public string Dvt { get; set; }
        public double? SlNhap { get; set; }
        public double? SlXuat { get; set; }
    }
}
