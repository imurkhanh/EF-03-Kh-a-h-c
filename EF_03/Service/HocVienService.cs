using EF_03.Entity;
using EF_03.IService;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_03.Service
{
    public class HocVienService : IHocVienService
    {
        private readonly AppDbContext DbContext;

        public HocVienService()
        {
            DbContext = new AppDbContext();
        }
        public void SuaHocVien()
        {
            Console.WriteLine("Nhập học viên ID cần sửa: ");
            int hocVienId = int.Parse(Console.ReadLine());
            var hocVien = DbContext.HocVien.Find(hocVienId);
            Console.WriteLine("Họ tên mới: ");
            hocVien.HoTen = Console.ReadLine();
            Console.WriteLine("Ngày sinh mới: ");
            hocVien.NgaySinh = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Nhập quê quán mới: ");
            hocVien.QueQuan = Console.ReadLine();
            Console.WriteLine("Nhập địa chỉ mới: ");
            hocVien.DiaChi = Console.ReadLine();
            Console.WriteLine("Nhập số điện thoại: ");
            hocVien.SoDienThoai = Console.ReadLine();
            DbContext.Update(hocVien);
            DbContext.SaveChanges();
            Console.WriteLine("Sửa thông tin học viên thành công");

        }

        public void TimKiemHocVienTheoHoTen_KhoaHoc()
        {
            Console.WriteLine("Nhập tên học viên cần tìm: ");
            string tenHocVien = Console.ReadLine();
            Console.WriteLine("Nhập tên khóa học cần tìm: ");
            string tenKhoaHoc = Console.ReadLine();
            var danhSach = DbContext.HocVien
                           .Join(DbContext.KhoaHoc, hv=>hv.KhoaHocId,kh=>kh.KhoaHocId, (hv, kh) => new {HocVien=hv,KhoaHoc=kh})
                           .Where(x=>x.HocVien.HoTen.ToLower().Contains(tenHocVien.ToLower()) && x.KhoaHoc.TenKhoaHoc.ToLower().Contains(tenKhoaHoc.ToLower()) )
                           .Select(x=>x.HocVien)
                           .ToList();
            foreach(var temp in danhSach)
            {
                Console.WriteLine(temp);
            }    
        }
    }
}
