using System;

namespace ComputerHorizon.Components
{
    public class AdminConnected
    {
        public String Token { get; set; }

        public AdminConnected(string token)
        {
            Token = token;
        }

        public AdminConnected()
        {
        }
    }
}