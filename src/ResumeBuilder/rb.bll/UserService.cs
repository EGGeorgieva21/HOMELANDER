using rb.dal.Data;
using rb.dal.Models;
using rb.dal.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace rb.bll
{
    public class UserService
    {
        private readonly ResumeBuilderContext _context;
        GenericRepository<User> genericRepository;
        public UserService()
        {
            _context = new ResumeBuilderContext();
            genericRepository = new(_context);
        }

        public bool RegisterUser(string Username, string Password, string Email)
        {
            List<User> users = genericRepository.GetAll().ToList();
            if (users.FirstOrDefault(u => u.Username == Username) != null)
            {
                return false;
            }

            User user = new User()
            {
                Username = Username,
                Email = Email
            };

            user.Salt = GenerateSalt();
            string saltedPassword = Password + user.Salt;
            user.Password = HashPassword(saltedPassword);

            genericRepository.Add(user);
            _context.SaveChanges();
            return true;
        }

        public User? VerifyUser(string Username, string Password)
        {
            List<User> users = genericRepository.GetAll().ToList();
            User user = users.FirstOrDefault(u => u.Username == Username);

            if(user == null)
            { 
                return null; 
            }

            string saltedPassword = Password + user.Salt;
            if(user.Password != HashPassword(saltedPassword)) 
            {
                return null;
            }
            return user;
        }


        private string GenerateSalt()
        {
            Random rnd = new Random();

            byte[] rndBytes = new byte[16];
            rnd.NextBytes(rndBytes);

            string salt = Convert.ToHexString(rndBytes);

            return salt;
        }

        private string HashPassword(string password)
        {
            SHA256 hash = SHA256.Create();

            byte[] passBytes = Encoding.Default.GetBytes(password);

            string hashedPass = Convert.ToHexString(hash.ComputeHash(passBytes));

            return hashedPass;
        }

    }
}
