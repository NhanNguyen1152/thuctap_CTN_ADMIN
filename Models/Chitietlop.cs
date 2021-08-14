using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace thuctap_CTN_NEW.Models
{
    public partial class Chitietlop
    {
        [DisplayName("Mã chi tiết lớp")]
        public string CtlId { get; set; }
        [DisplayName("Mã học viên")]
        public string HvId { get; set; }
        [DisplayName("Mã lớp")]
        public string LId { get; set; }

        public virtual Hocvien Hv { get; set; }
        public virtual Lop LIdNavigation { get; set; }
    }
}
