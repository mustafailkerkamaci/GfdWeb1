using System.ComponentModel.DataAnnotations;




namespace GFDWeb.Models
{
    public class Kullanici
    {
        [Key] // Birincil anahtar (Primary Key)
        public int Id { get; set; }

        [Required(ErrorMessage = "Ad alanı zorunludur")]
        [StringLength(50)]
        public string Ad { get; set; }

        [Required(ErrorMessage = "Soyad alanı zorunludur")]
        [StringLength(50)]
        public string Soyad { get; set; }

        [Required(ErrorMessage = "E-posta adresi zorunludur")]
        [EmailAddress(ErrorMessage = "Geçersiz e-posta adresi")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Şifre zorunludur")]
        [DataType(DataType.Password)]
        public string Sifre { get; set; }

        public DateTime KayitTarihi { get; set; } = DateTime.Now;
    }

}