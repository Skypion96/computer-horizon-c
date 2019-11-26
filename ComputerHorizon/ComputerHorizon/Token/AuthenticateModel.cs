using System.ComponentModel.DataAnnotations;

namespace ComputerHorizon.Token
{
    public class AuthenticateModel
    {
        [Required]
        public string Mail { get; set; }

        [Required]
        public string Mdp { get; set; }
    }
}