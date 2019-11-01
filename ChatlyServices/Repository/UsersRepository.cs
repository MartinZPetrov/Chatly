using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChatlyServices.Repository
{
    public class UsersRepository : IUserRepository
    {

        private ChatlyEntities context = null;

        public UsersRepository()
        {
            context =  new ChatlyEntities();
        }

        public Users Authenticate(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return null;

            var user = context.Users.SingleOrDefault(x => x.UserName == username);

            // check that user exists
            if (user == null)
                return null;

            // check if password is correct
            //if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            //    return null;
            
                

            // authentication successful
            return user;
        }

        public Users Create(Users user, string password)
        {
            //check password is passed in
            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentException("Password is required");

            if (context.Users.Any(x => x.Email == user.Email))
                throw new ArgumentException("This username is already taken");

            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash);

            user.PasswordHash = passwordHash;

            context.Users.Add(user);
            context.SaveChanges();

            return user;
        }

        private static void CreatePasswordHash(string password, out byte[] passwordHash)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentNullException("Value cannot be empty");

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }


        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public bool UserExists(int userid)
        {
            return context.Users.Any(u => u.Id == userid);
        }

        public bool Save()
        {
            return (context.SaveChanges() >= 0);
        }

        private static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            if (password == null)
                throw new ArgumentNullException("password");

            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only");
            if (storedHash.Length != 64) throw new ArgumentException("Invalid length of stored hash");
            if (storedSalt.Length != 128) throw new ArgumentException("Invalid length of stored salt");

            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i]) return false;
                }
            }

            return true;
        }
    }
}