using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookManagement.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên sách không được để trống")]
        [StringLength(200)]
        [Display(Name = "Tên sách")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Tác giả không được để trống")]
        [StringLength(100)]
        [Display(Name = "Tác giả")]
        public string Author { get; set; } = string.Empty;

        [Required]
        [Range(0.01, 100000000, ErrorMessage = "Giá phải lớn hơn 0")]
        [Column(TypeName = "decimal(18,2)")]
        [Display(Name = "Giá")]
        public decimal Price { get; set; }

        [Range(0, 100000, ErrorMessage = "Số lượng không được âm")]
        [Display(Name = "Số lượng")]
        public int Quantity { get; set; }

        [Range(1000, 2100, ErrorMessage = "Năm xuất bản không hợp lệ")]
        [Display(Name = "Năm xuất bản")]
        public int PublishedYear { get; set; }
    }
}