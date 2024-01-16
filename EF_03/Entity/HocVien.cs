using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_03.Entity
{
    public class HocVien
    {
        public int HocVienId { get; set; }
        public int KhoaHocId { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength(20)]
        public string HoTen { get; set; }
        public DateTime NgaySinh { get; set; }
        public string QueQuan { get; set; }
        public string DiaChi { get; set; }
        public string SoDienThoai { get; set; }
        public KhoaHoc KhoaHoc { get; set; }
    }
}
