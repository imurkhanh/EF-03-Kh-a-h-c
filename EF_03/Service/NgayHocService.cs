using EF_03.Entity;
using EF_03.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_03.Service
{
    public class NgayHocService : INgayHocService
    {
        private readonly AppDbContext DbContext;

        public NgayHocService()
        {
            DbContext = new AppDbContext();
        }
        public void ThemNgayHoc()
        {
            Console.WriteLine("Nhập khóa học ID: ");
            int khoaHocId = int.Parse(Console.ReadLine());
            var khoaHoc = DbContext.KhoaHoc.Find(khoaHocId);
            if(khoaHoc == null)
            {
                Console.WriteLine("Không tồn tại khóa học");
            }
            else
            {
                Console.WriteLine("Nội dung: ");
                string noiDung = Console.ReadLine();
                Console.WriteLine("Ghi chú: ");
                string ghiChu = Console.ReadLine();

                NgayHoc ngayHoc = new NgayHoc
                {
                    KhoaHocId=khoaHocId,
                    NoiDung = noiDung,
                    GhiChu = ghiChu,
                };
                DbContext.Add(ngayHoc);
                DbContext.SaveChanges();
                Console.WriteLine("Thêm ngày học thành công");
            }
        }
    }
}
