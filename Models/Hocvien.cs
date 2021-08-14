using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace thuctap_CTN_NEW.Models
{
    public partial class Hocvien
    {
        public Hocvien()
        {
            Chitietlops = new HashSet<Chitietlop>();
            Thoikhoabieus = new HashSet<Thoikhoabieu>();
        }

        [DisplayName("Mã học viên")]
        public string HvId { get; set; }
        [DisplayName("Ngày sinh")]
        public DateTime? HvNgaysinh { get; set; }
        [DisplayName("Giới tính")]
        public string HvGioitinh { get; set; }
        [DisplayName("Địa chỉ")]
        public string HvDiachi { get; set; }
        [DisplayName("Số điện thoại")]
        public string HvSdt { get; set; }
        [DisplayName("Email")]
        public string HvEmail { get; set; }
        [DisplayName("Ngày vào ")]
        public DateTime? HvNgayvao { get; set; }
        [DisplayName("Hình ảnh")]
        public string HvHinhanh { get; set; }
        [DisplayName("Họ tên")]
        public string HvTen { get; set; }

        public virtual ICollection<Chitietlop> Chitietlops { get; set; }
        public virtual ICollection<Thoikhoabieu> Thoikhoabieus { get; set; }
    }
}
