namespace Shouter.App.Controllers
{
    using BindingModels;
    using Models;
    using Security;
    using Services;
    using SimpleHttpServer.Models;
    using SimpleMVC.Attributes.Methods;
    using SimpleMVC.Controllers;
    using SimpleMVC.Interfaces;
    using SimpleMVC.Interfaces.Generic;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using ViewModels;

    class UserController : Controller
    {
        [HttpGet]
        public IActionResult<StatusMessageViewModel> Register()
        {
            var viewModel = new StatusMessageViewModel();
            viewModel.Message = "<br>";

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult<StatusMessageViewModel> Register(RegisterUserBindingModel model)
        {
            var viewModel = new StatusMessageViewModel();
            string[] birthDateParts = model.BirthDate.Split('/');
            DateTime birthDate = new DateTime(int.Parse(birthDateParts[2]), int.Parse(birthDateParts[1]), int.Parse(birthDateParts[0]));

            if (model.Password != model.PasswordConfirm)
            {
                viewModel.Message = $"<div class=\"container\"><div class=\"thumbnail\"><p class=\"text-danger\">Passwords does not match!</p></div></div>";

                return View(viewModel);
            }

            if (!UserService.ValidBirthDate(birthDate))
            {
                viewModel.Message = $"<div class=\"container\"><div class=\"thumbnail\"><p class=\"text-danger\">You must be at least 13 years old to register!</p></div></div>";

                return View(viewModel);
            }

            if (!UserService.ValidUsername(model.Username))
            {
                viewModel.Message = $"<div class=\"container\"><div class=\"thumbnail\"><p class=\"text-danger\">Username already registered!</p></div></div>";

                return View(viewModel);
            }

            if (!UserService.ValidEmail(model.Email))
            {
                viewModel.Message = $"<div class=\"container\"><div class=\"thumbnail\"><p class=\"text-danger\">Email already registered!</p></div></div>";

                return View(viewModel);
            }

            User user = new User()
            {
                Username = model.Username,
                Password = model.Password,
                BirthDate = birthDate,
                Email = model.Email
            };

            UserService.RegisterUserToDatabase(user);

            viewModel.Message = $"<div class=\"container\"><div class=\"thumbnail\"><p class=\"text-success\">Successfully registered!</p></div></div>";
            
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult<StatusMessageViewModel> Login()
        {
            var viewModel = new StatusMessageViewModel();
            viewModel.Message = "<br>";

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult<StatusMessageViewModel> Login(LoginUserBindingModel model, HttpSession session)
        {
            var viewModel = new StatusMessageViewModel();

            // If true = there is no such username
            if (UserService.ValidUsername(model.Username))
            {
                viewModel.Message = $"<div class=\"container\"><div class=\"thumbnail\"><p class=\"text-danger\">Invalid username!</p></div></div>";

                return View(viewModel);
            }

            if (!UserService.ValidPassword(model.Username, model.Password))
            {
                viewModel.Message = $"<div class=\"container\"><div class=\"thumbnail\"><p class=\"text-danger\">Incorrect Password!</p></div></div>";

                return View(viewModel);
            }

            SignInManager.LogIn(model.Username, session);

            viewModel.Message = $"<div class=\"container\"><div class=\"thumbnail\"><p class=\"text-success\">Successfully logged in!</p></div></div>";

            return View(viewModel);
        }
    }
}