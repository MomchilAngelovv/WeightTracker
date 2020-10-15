using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using WeightTracker.Data;
using WeightTracker.Services;
using Xunit;

namespace WeightTracker.Tests
{
    public class UsersServiceTests
    {
        [Fact]
        public async Task RegisterNewUser_Should_Properly_Register_New_User()
        {
            var options = new DbContextOptionsBuilder<WeightTrackerDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var db = new WeightTrackerDbContext(options);
            var userService = new UsersService(db);
            await userService.RegisterNewUser("TestUser", "TestSecretWord");

            Assert.Equal("TestUser", db.Users.First().Name);
        }

        [Fact]
        public async Task AddWeight_Should_Properly_Register_New_User()
        {
            var options = new DbContextOptionsBuilder<WeightTrackerDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var db = new WeightTrackerDbContext(options);
            var userService = new UsersService(db);
            await userService.RegisterNewUser("TestUser", "TestSecretWord");

            await userService.AddWeight(100, "TestUser", "TestSecretWord"); 

            Assert.Single(db.Users.First().Weights);
        }
    }
}
