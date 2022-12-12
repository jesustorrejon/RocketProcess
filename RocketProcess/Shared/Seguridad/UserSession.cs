﻿namespace RocketProcess.Shared.Seguridad
{
    public class UserSession
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Token { get; set; }
        public string Role { get; set; }
        public string Permisos { get; set; }
        public int ExpiresIn { get; set; }
        public DateTime ExpiryTimeStamp { get; set; }
    }

}