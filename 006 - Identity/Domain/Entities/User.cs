using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.Base;
using Domain.Interfaces.Entity;

namespace Domain.Entities
{
    public class User:BaseEntity,IEntity
    {
        public string FirstName { get; set; } // Kullanıcının adı
        public string LastName { get; set; } // Kullanıcının soyadı
        public string Email { get; set; } // Kullanıcının e-posta adresi
        public byte[] PasswordHash { get; set; } // Kullanıcının şifresinin hashlenmiş hali
        public byte[] PasswordSalt { get; set; } // Şifreleme için kullanılan salt değeri

        public string PhoneNumber { get; set; } // Kullanıcının telefon numarası
        public string? ProfileImageUrl { get; set; } // Kullanıcının profil fotoğrafı URL'si
        public bool IsActive { get; set; } = true; // Kullanıcının aktif olup olmadığını belirten bayrak
        public DateTime? LastLoginDate { get; set; } // Kullanıcının en son giriş yaptığı tarih
        public int FailedLoginAttempts { get; set; } = 0; // Başarısız giriş deneme sayısı
        public DateTime? LockoutEnd { get; set; } // Çok fazla hatalı giriş sonrası hesap kilitlenirse, ne zaman açılacağı
        public string? Permissions { get; set; } // Kullanıcının özel izinleri (JSON string veya ayrı bir tablo olarak saklanabilir)
        public string? Address { get; set; } // Kullanıcının adresi
        public string? City { get; set; } // Kullanıcının yaşadığı şehir
        public string? Country { get; set; } // Kullanıcının yaşadığı ülke

        public bool TwoFactorEnabled { get; set; } = false; // İki faktörlü kimlik doğrulama açık mı?
        public string? TwoFactorSecretKey { get; set; } // 2FA için kullanılan gizli anahtar

        public string? RefreshToken { get; set; } // JWT Refresh Token değeri
        public DateTime? RefreshTokenExpiryTime { get; set; } // Refresh Token'ın geçerlilik süresi

        public string? GoogleId { get; set; } // Google ile giriş yapıldıysa Google ID
        public string? FacebookId { get; set; } // Facebook ile giriş yapıldıysa Facebook ID
        public string? LinkedInProfileUrl { get; set; } // Kullanıcının LinkedIn profil bağlantısı
        public DateTime? DateOfBirth { get; set; } // Kullanıcının doğum tarihi
        public string? Gender { get; set; } // Kullanıcının cinsiyeti (Erkek, Kadın vb.)

        public ICollection<UserRole> UserRoles { get; set; } // Kullanıcının rollerini tutar
        public ICollection<UserClaim> UserClaims { get; set; } // Kullanıcının sahip olduğu yetkileri tutar
    }
}