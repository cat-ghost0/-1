using System.ComponentModel.DataAnnotations;

namespace PR1.ActionClass.HelperClass.DTO
{
    public class AccountDTO
    {
        public long Id { get; set; }
        public string Phone { get; set; } = null!;
        public string Sex { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Role { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;    
        public string Fname { get; set; } = null!;

        public string? FullName { get; set; } = null!;


    }
}
