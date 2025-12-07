using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoAnDemoUI.Model
{
    [Table("THETHUVIEN")]
    public class TheThuVien
    {
        [Key]
        public int SoThe { get; set; }

        public DateTime? NgayBatDau { get; set; }
        public DateTime? NgayKetThuc { get; set; }

        [StringLength(200)]
        public string GhiChu { get; set; }

        // Một thẻ thư viện thuộc về Độc giả (quan hệ ngược)
        public virtual ICollection<DocGia> DocGias { get; set; } = new List<DocGia>();
    }
}