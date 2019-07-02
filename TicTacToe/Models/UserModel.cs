using System;
using System.ComponentModel.DataAnnotations;

namespace TicTacToe.Models
{
    public class UserModel
    {
        public Guid Id { get; set; }

        [Required()]
        public string FirstName { get; set; }

        [Required()]
        public string LastName { get; set; }

        [Required(), DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(), DataType(DataType.Password)]
        public string Password { get; set; }

        public bool IsEmailConfirmed { get; set; }

        public System.DateTime? EmailConfirmationDate { get; set; }

        public int Score { get; set; }
    }
}
