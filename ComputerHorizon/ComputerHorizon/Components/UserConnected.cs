using System;

namespace ComputerHorizon.Components
{
    public class UserConnected
    {
        public String Token { get; set; }

        public UserConnected(string token)
        {
            this.Token = token;
        }
        
        public UserConnected()
        {
        }
    }
}