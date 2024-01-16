using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_03.Entity
{
    public class AppDbContext:DbContext
    {
        public virtual DbSet<HocVien> HocVien { get; set; }
        public virtual DbSet<KhoaHoc> KhoaHoc { get; set; }
        public virtual DbSet<NgayHoc> NgayHoc { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-V5E7153\\SQLEXPRESS;Database=EF_03;Trusted_Connection = True;TrustServerCertificate=True");
        }
    }
}
