using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using DoAnDemoUI.Model; // Đảm bảo namespace này chứa các class Entity bạn vừa tạo

namespace DoAnDemoUI.Data
{
    public class ThuVienContext : DbContext
    {
        // Constructor gọi chuỗi kết nối từ App.config
        // Đảm bảo trong App.config có connectionString tên là "DefaultConnection"
        public ThuVienContext() : base("name=DefaultConnection")
        {
            // Tắt Lazy Loading nếu bạn muốn query dữ liệu nhanh hơn và tự dùng .Include() khi cần
            // this.Configuration.LazyLoadingEnabled = false; 
        }

        // --- DANH SÁCH CÁC BẢNG (DBSET) ---

        // 1. Hệ thống
        public virtual DbSet<User> Users { get; set; }

        // 2. Danh mục cơ bản
        public virtual DbSet<NhaXuatBan> NhaXuatBans { get; set; }
        public virtual DbSet<TheLoai> TheLoais { get; set; }
        public virtual DbSet<TacGia> TacGias { get; set; }
        public virtual DbSet<NhanVien> NhanViens { get; set; } // <--- Đã thêm bảng Nhân Viên

        // 3. Nghiệp vụ chính
        public virtual DbSet<TheThuVien> TheThuViens { get; set; }
        public virtual DbSet<DocGia> DocGias { get; set; }
        public virtual DbSet<Sach> Sachs { get; set; }

        // 4. Mượn trả
        public virtual DbSet<PhieuMuon> PhieuMuons { get; set; }
        public virtual DbSet<CTPhieuMuon> CTPhieuMuons { get; set; }

        // 5. Phạt
        public virtual DbSet<PhieuPhat> PhieuPhats { get; set; }
        public virtual DbSet<CTPhieuPhat> CTPhieuPhats { get; set; }

        // --- CẤU HÌNH MODEL ---
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Xóa quy tắc tự động thêm "s" vào tên bảng
            // (Ví dụ: Class "Sach" sẽ map vào bảng "SACH" thay vì "Saches")
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            // Nếu bạn muốn cấu hình thêm (ví dụ Cascade Delete), viết ở đây
            // modelBuilder.Entity<PhieuMuon>()
            //    .HasRequired(p => p.NhanVien)
            //    .WithMany(n => n.PhieuMuons)
            //    .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}