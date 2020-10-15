using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeightTracker.Data;
using WeightTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace WeightTracker.Services
{
    public class UsersService : IUsersService
    {
        private readonly WeightTrackerDbContext db;

        public UsersService(WeightTrackerDbContext db)
        {
            this.db = db;
        }

        public async Task<string> AddWeight(decimal weight, string name, string secretWord)
        {
           var user = this.db.Users
                .SingleOrDefault(u => u.Name == name && u.SecretWord == secretWord);

            var newWeight = new Weight
            {
                Kilograms = weight,
                CreatedOn = DateTime.UtcNow
            };

            user.Weights.Add(newWeight);
            this.db.Users.Update(user);
            await this.db.SaveChangesAsync();

            return newWeight.Id;
        }

        public User GetUserBy(int id)
        {
            var user = this.db.Users
               .SingleOrDefault(u => u.Id == id);

            return user;
        }

        public bool CheckCredentials(string name, string secretWord)
        {
            var user = this.db.Users
                .SingleOrDefault(u => u.Name == name && u.SecretWord == secretWord);

            if (user == null)
            {
                return false;
            }

            return true;
        }

        public IEnumerable<WeightsReportWeight> GetWeights(string name, string secretWord)
        {
            var weights = this.db.Users
                .Include(x => x.Weights)
                .SingleOrDefault(u => u.Name == name && u.SecretWord == secretWord)
                .Weights
                .Select(w => new WeightsReportWeight
                {
                    Kilograms = w.Kilograms,
                    CreatedOn = w.CreatedOn
                })
                .OrderByDescending(x => x.CreatedOn)
                .ToList();

            return weights;
        }

        public async Task<int> RegisterNewUser(string name, string secretWord)
        {
            var newUser = new User
            {
                Name = name,
                SecretWord = secretWord,
            };

            await this.db.Users.AddAsync(newUser);
            await this.db.SaveChangesAsync();

            return newUser.Id;
        }

        public User GetUserBy(string name)
        {
            var user = this.db.Users
               .SingleOrDefault(u => u.Name == name);

            return user;
        }
    }
}
