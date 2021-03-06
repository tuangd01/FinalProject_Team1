﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BanHangXachTay.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class tablePRODUCT
    {
        [Display(Name = "ID sản phẩm")]
        public int idSP { get; set; }
        [Display(Name = "Tên sản phẩm")]
        public string tenSP { get; set; }
        [Display(Name = "Đơn giá")]
        public Nullable<int> dongiaSP { get; set; }
        [Display(Name = "Số lượng")]
        public Nullable<int> soluongSP { get; set; }
        [Display(Name = "Ngày nhập")]
        public Nullable<System.DateTime> ngaynhap { get; set; }

        [Display(Name = "Hình ảnh")]
        public byte[] img { get; set; }
        [Display(Name = "Ghi chú")]
        public string ghichuSP { get; set; }
        [Display(Name = "Nhà cung cấp")]
        public Nullable<int> MaNCC { get; set; }

        [Display(Name = "Loại sản phẩm")]
        public Nullable<int> idLSP { get; set; }


        public virtual NHACUNGCAP NHACUNGCAP { get; set; }
        public virtual LoaiSanPham LoaiSanPham { get; set; }
    }
}
