namespace WebBooksManage.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Book")]
    public partial class Book
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [Required(ErrorMessage ="Tittle không được để trống!")]
        [StringLength(100, ErrorMessage ="Tittle không vượt quá 100 kí tự!")]
        public string Tittle { get; set; }
        [StringLength(100)]
        public string Decription { get; set; }

        [StringLength(20)]
        public string ImageCover { get; set; }
        [Range(1000,1000000,ErrorMessage ="Giá phải từ 1000-1000000!")]
        public double? Price { get; set; }
    }
}
