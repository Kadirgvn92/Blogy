using System.ComponentModel.DataAnnotations;

namespace Blogy.WebUI.Models;

public class ReplyViewModel 
{
    [Required(ErrorMessage = "Ad soyad alanı gereklidir.")]
    public string FullName { get; set; }

    [Required(ErrorMessage = "Email adresi gereklidir.")]
    [EmailAddress(ErrorMessage = "Geçerli bir email adresi giriniz.")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Yorum alanı gereklidir.")]
    public string Content { get; set; }

    public int ArticleID { get; set; }

    public int ParentCommentID { get; set; } // Yanıtlanan yorumun ID'si
}
