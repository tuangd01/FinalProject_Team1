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
    
    public partial class tableBILL
    {
        public int idHD { get; set; }
        [Display(Name="Mã khách hàng")]
        public Nullable<int> idKH { get; set; }
        [Display(Name = "Tên khách hàng")]
        public string tenKH { get; set; }
        [Display(Name = "Sđt")]
        public string sodienthoaiKH { get; set; }
        [Display(Name = "Ngày đặt")]
        public Nullable<System.DateTime> ngaydathang { get; set; }
        [Display(Name = "Ngày giao")]
        public Nullable<System.DateTime> ngaygiaohang { get; set; }
        [Display(Name = "Ngày nhận")]
        public Nullable<System.DateTime> ngaynhanhang { get; set; }
        [Display(Name = "Địa chỉ nhận")]
        public string diachinhanhang { get; set; }
        [Display(Name = "Mã sản phẩm")]
        public Nullable<int> idSP { get; set; }
        [Display(Name = "Tên sản phẩm")]
        public string tenSP { get; set; }
        [Display(Name = "Đơn giá")]
        public Nullable<int> dongiaSP { get; set; }
        [Display(Name = "Số lượng")]
        public Nullable<int> soluongSP { get; set; }
        [Display(Name = "Ghi chú")]
        public string ghichuSP { get; set; }
        [Display(Name = "Bill-Tổng tiền")]
        public Nullable<int> thanhtienBILL { get; set; }
        [Display(Name = "Bill-Số lượng")]
        public Nullable<int> soluongBILL { get; set; }
        [Display(Name = "Bill-Đơn giá")]
        public Nullable<int> dongiaBILL { get; set; }
        [Display(Name = "Tổng doanh thu")]
        public Nullable<int> tongdoanhthu { get; set; }
        [Display(Name = "Bill-Ghi chú")]
        public string ghichuBILL { get; set; }
    }
}
