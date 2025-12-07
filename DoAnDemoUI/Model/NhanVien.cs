using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoAnDemoUI.Model
{
    [Table("NHANVIEN")]
    public class NhanVien
    {
        [Key]
        public int MaNhanVien { get; set; }

        [StringLength(200)]
        public string TenNhanVien { get; set; }

        public DateTime? NgaySinh { get; set; }

        [StringLength(20)]
        public string SoDienThoai { get; set; }

        [StringLength(200)]
        public string DiaChi { get; set; }

        [StringLength(200)]
        public string Email { get; set; }

        // Nhân viên lập nhiều phiếu mượn và phiếu phạt
        public virtual ICollection<PhieuMuon> PhieuMuons { get; set; } = new List<PhieuMuon>();
        public virtual ICollection<PhieuPhat> PhieuPhats { get; set; } = new List<PhieuPhat>();
    }
}