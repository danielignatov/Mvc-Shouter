namespace Shouter.App.Controllers
{
    using Models;
    using Services;
    using SimpleMVC.Attributes.Methods;
    using SimpleMVC.Controllers;
    using SimpleMVC.Interfaces.Generic;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using ViewModel;

    public class HomeController : Controller
    {
        #region Methods
        [HttpGet]
        public IActionResult<ShowShoutsViewModel> Feed()
        {
            var viewModel = new ShowShoutsViewModel();
            viewModel.Shouts = ShoutService.ReturnAllShouts();

            return View(viewModel);
        }
        #endregion
    }
}