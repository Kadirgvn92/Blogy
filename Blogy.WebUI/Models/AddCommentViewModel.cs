﻿using Blogy.EntityLayer;
using System.ComponentModel.DataAnnotations;

namespace Blogy.WebUI.Models;

public class AddCommentViewModel
{
    public int CommentID { get; set; }
    [Required(ErrorMessage = "Ad soyad alanı gereklidir.")]
    public string FullName { get; set; }
    [Required(ErrorMessage = "Email adresi gereklidir.")]
    [EmailAddress(ErrorMessage = "Geçerli bir email adresi giriniz.")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Yorum alanı gereklidir.")]
    public string Content { get; set; }
    public DateTime CommentDate { get; set; }
    public string CommentStatus { get; set; }
    public int ArticleID { get; set; }
}
