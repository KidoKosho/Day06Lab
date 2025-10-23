using System;
using System.ComponentModel.DataAnnotations;

public enum Branch
{
    IT = 1,
    BE = 2,
    CE = 3,
    EE = 4
}

public enum Gender
{
    Nam = 1,
    Nu = 2,
    Khac = 3
}

public class Student
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Họ tên bắt buộc phải nhập")]
    [StringLength(100, MinimumLength = 4, ErrorMessage = "Họ tên phải từ 4 đến 100 ký tự")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Email bắt buộc phải nhập")]
    [RegularExpression(@"^[a-zA-Z0-9._%+-]+@gmail\.com$", ErrorMessage = "Email phải có đuôi @gmail.com")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Mật khẩu bắt buộc phải nhập")]
    [StringLength(100, MinimumLength = 8, ErrorMessage = "Mật khẩu phải có ít nhất 8 ký tự")]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\W_]).+$",
        ErrorMessage = "Mật khẩu phải có chữ hoa, chữ thường, số và ký tự đặc biệt")]
    public string Password { get; set; }

    [Required(ErrorMessage = "Ngành học bắt buộc phải chọn")]
    public Branch Branch { get; set; }

    [Required(ErrorMessage = "Giới tính bắt buộc phải chọn")]
    public Gender Gender { get; set; }

    [Display(Name = "Hệ chính quy")]
    public bool IsRegular { get; set; }

    [Required(ErrorMessage = "Địa chỉ bắt buộc phải nhập")]
    [DataType(DataType.MultilineText)]
    public string Address { get; set; }

    [Required(ErrorMessage = "Ngày sinh bắt buộc phải nhập")]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    [CustomValidation(typeof(Student), nameof(ValidateDateOfBirth))]
    public DateTime DateOfBirth { get; set; }

    public static ValidationResult? ValidateDateOfBirth(DateTime date, ValidationContext context)
    {
        if (date < new DateTime(1963, 1, 1) || date > new DateTime(2005, 12, 31))
            return new ValidationResult("Ngày sinh phải trong khoảng 1963 - 2005");
        return ValidationResult.Success;
    }



    [Required(ErrorMessage = "Điểm bắt buộc nhập")]
    [Range(0.0, 10.0, ErrorMessage = "Điểm phải trong khoảng 0.0 đến 10.0")]
    public double Score { get; set; }
}
