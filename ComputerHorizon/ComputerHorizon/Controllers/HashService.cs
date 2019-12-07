using ComputerHorizon.Components;

namespace ComputerHorizon.Controllers
{
    public class HashService
    {
        public static string HashPwd(string mdp)
        {
            return BCrypt.Net.BCrypt.HashPassword(mdp);
        }
    }
}