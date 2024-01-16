using EF_03.Entity;
using EF_03.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_03.Service
{
    public class KhoaHocService : IKhoaHocService
    {
        private readonly AppDbContext DbContext;

        public KhoaHocService()
        {
            DbContext = new AppDbContext();
        }
        private int DemHocVienCungThangBatDau(string tenKhoaHoc)
        {
            var soHocVien = DbContext.HocVien
                            .Join(DbContext.KhoaHoc, hv => hv.KhoaHocId, kh => kh.KhoaHocId, (hv, kh) => new { HocVien = hv, KhoaHoc = kh })
                            .Where(x => x.HocVien.KhoaHoc.TenKhoaHoc.ToLower() == tenKhoaHoc.ToLower())
                            .Count();
            return soHocVien;
        }
        public double TinhDoanhThuTheoThang()
        {
            Console.WriteLine("Nhập tháng cần tính: ");
            int month = int.Parse(Console.ReadLine());
            double result = 0;
            var khoaHocTrongThang = DbContext.KhoaHoc.Where(x => x.NgayBatDau.Month == month);
            foreach (var temp in khoaHocTrongThang)
            {
                var tenKhoaHoc = temp.TenKhoaHoc;
                result += temp.HocPhi * DemHocVienCungThangBatDau(tenKhoaHoc);
            }
            return result;

        }

        public void XoaKhoaHoc()
        {
            Console.WriteLine("Nhập khóa học ID cần xóa: ");
            int khoaHocId = int.Parse(Console.ReadLine());
            if (DbContext.KhoaHoc.Any(x => x.KhoaHocId == khoaHocId))
            {
                var kHoc = DbContext.KhoaHoc.Find(khoaHocId);
                var nHoc = DbContext.NgayHoc.Find(khoaHocId);
                var hVien = DbContext.HocVien.Find(khoaHocId);
                if (nHoc != null)
                {
                    DbContext.Remove(nHoc);
                    DbContext.Remove(kHoc);
                    DbContext.SaveChanges();
                    Console.WriteLine("Xóa khóa học thành công");
                }
                if (hVien != null)
                {
                    DbContext.Remove(hVien);
                    DbContext.Remove(kHoc);
                    DbContext.SaveChanges();
                    Console.WriteLine("Xóa khóa học thành công");
                }
                else
                {
                    DbContext.Remove(kHoc);
                    DbContext.SaveChanges();
                    Console.WriteLine("Xóa khóa học thành công");
                }
            }
            else
            {
                Console.WriteLine("Khóa học không tồn tại");
            }
        }
    }
}
