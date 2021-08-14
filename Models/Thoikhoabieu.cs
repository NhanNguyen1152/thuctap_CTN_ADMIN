using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace thuctap_CTN_NEW.Models
{
    public partial class Thoikhoabieu
    {
        [DisplayName("Mã thời khóa biểu")]
        public string TkbId { get; set; }
        [DisplayName("Lớp")]
        public string LId { get; set; }
        [DisplayName("Học viên")]
        public string HvId { get; set; }
        [DisplayName("Môn học")]
        public string TkbMonhoc { get; set; }
        [DisplayName("Khung giờ")]
        public string TkbKhunggio { get; set; }
        [DisplayName("Ngày bắt đầu")]
        public DateTime? TkbNgaybatdau { get; set; }
        [DisplayName("Ngày kết thúc")]
        public DateTime? TkbNgayketthuc { get; set; }
        [DisplayName("Thứ")]
        public string TkbThu { get; set; }
        [DisplayName("Link học")]
        public string TkbLinkhoc { get; set; }

        public virtual Hocvien Hv { get; set; }
        public virtual Lop LIdNavigation { get; set; }
    }
}
