using System.ComponentModel.DataAnnotations;

namespace SGAS.IdentityServer.Quickstart.Account
{
    public class AccountViewModel
    {

        public string Name { get; set; }

        public string Email { get; set; }

        public DateTime BirthDate { get; set; }

        public string Username { get; set; }
       // [Required]
        public string Password { get; set; }

        public string ConfirmedPassword { get; set; }

        public int FuncaoId { get; set; }

    }
}
