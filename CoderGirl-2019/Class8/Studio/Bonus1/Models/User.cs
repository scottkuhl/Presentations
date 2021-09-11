﻿namespace UserSignup.Models
{
    public class User
    {
        public int UserId { get; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        private static int nextUserId = 0;

        public User()
        {
            UserId = ++nextUserId;
        }
    }
}
