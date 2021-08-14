using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace thuctap_CTN_NEW.Models
{
    public partial class Taikhoan
    {
        [DisplayName("Mã tài khoản")]
        public string TkId { get; set; }
        [DisplayName("Tài khoản")]
        public string TkUrn { get; set; }
        [DisplayName("Mật khẩu")]
        public string TkPw { get; set; }
    }
}
