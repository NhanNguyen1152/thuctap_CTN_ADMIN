using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace thuctap_CTN_NEW.Models
{
    public partial class Ad
    {
        [DisplayName("Mã Giảng Viên")]
        public string AdId { get; set; }
        [DisplayName( "Tài khoản")]
        public string AdUsername { get; set; }
        [DisplayName ("Mật Khẩu")]
        public string AdPassword { get; set; }
        [DisplayName ("Tên Giảng Viên")]
        public string AdTen { get; set; }
    }
}
