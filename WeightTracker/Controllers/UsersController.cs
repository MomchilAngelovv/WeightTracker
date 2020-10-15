using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeightTracker.Models;
using WeightTracker.Services;

namespace WeightTracker.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUsersService usersService;

        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return this.View();
        }

        [HttpGet]
        public IActionResult WeightsReport(string name, string secretWord)
        {
            var userExists = this.usersService.CheckCredentials(name, secretWord);

            if (!userExists)
            {
                return this.RedirectToAction("NotAllowed", "Home");
            }

            var weights = this.usersService.GetWeights(name, secretWord);
            var viewModel = new WeightsReportViewModel
            {
                Name = name,
                SecretWord = secretWord,
                Weights = weights
            };

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddWeight(decimal weight, string name, string secretWord, IFormFile formFile)
        {
            var userExists = this.usersService.CheckCredentials(name, secretWord);

            if (!userExists)
            {
                return this.RedirectToAction("NotAllowed", "Home");
            }

            await this.usersService.AddWeight(weight, name, secretWord);
            return this.RedirectToAction(nameof(WeightsReport), new { Name = name, SecretWord = secretWord });
        }

        [HttpPost]
        public async Task<IActionResult> Register(UsersRegisterInputModel inputModel)
        {
            if (this.ModelState.IsValid == false)
            {
                return this.View(inputModel);
            }

            var newUserId = await this.usersService.RegisterNewUser(inputModel.Name, inputModel.SecretWord);
            return this.RedirectToAction("Index", "Home");
        }
    }
}
