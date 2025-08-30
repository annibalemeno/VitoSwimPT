using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VitoSwimPT.Server.Users
{
    public class User
    {
        public Guid Id { get; set; }
        [Column(TypeName = "VARCHAR")]
        [StringLength(300)]
        public string Email { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(200)]
        public string FirstName { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(200)]
        public string LastName { get; set; }
        public string PasswordHash { get; set; }

        public bool EmailVerified { get; set; }
    }
}
