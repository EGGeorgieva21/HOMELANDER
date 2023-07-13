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
        private readonly GenericRepository<User> genericRepository;
        public UserService()
        {
            _context = new ResumeBuilderContext();
            genericRepository = new GenericRepository<User>(_context);
        }

        public User? RegisterUser(string username, string password, string email)
        {
            List<User> users = genericRepository.GetAll().ToList();
            if (users.FirstOrDefault(u => u.Username == username) != null)
            {
                return null;
            }

            User user = new User()
            {
                Username = username,
                Email = email
            };

            user.Salt = GenerateSalt();
            string saltedPassword = password + user.Salt;
            user.Password = HashPassword(saltedPassword);

            genericRepository.Add(user);
            User? registeredUser = genericRepository.GetAll().FirstOrDefault(u => u.Username == username);
            _context.SaveChanges();

            return registeredUser;
        }

        public User? VerifyUser(string username, string password)
        {
            List<User> users = genericRepository.GetAll().ToList();
            User? user = users.FirstOrDefault(u => u.Username == username);

            if(user == null)
            { 
                return null; 
            }

            string saltedPassword = password + user.Salt;
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