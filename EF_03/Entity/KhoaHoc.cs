using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_03.Entity
{
    public class KhoaHoc
    {
        public int KhoaHocId { get; set; }
        [Required]
        [MaxLength(10)]
        public string TenKhoaHoc { get; set; }
        public string MoTa { get; set; }
        [Required]
        public double HocPhi { get; set; }
        public DateTime NgayBatDau { get; set; }
        public DateTime NgayKetThuc
        {
            get { return NgayBatDau.AddDays(15); }
        }
    }
}
