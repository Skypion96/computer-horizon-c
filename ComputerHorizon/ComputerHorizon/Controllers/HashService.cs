using ComputerHorizon.Components;

namespace ComputerHorizon.Controllers
{
    public class HashService
    {
        public static string HashPwd(string pwd)
        {
            return BCrypt.Net.BCrypt.HashPassword(pwd);
        }
    }
}