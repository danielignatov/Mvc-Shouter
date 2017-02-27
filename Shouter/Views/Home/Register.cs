namespace Shouter.Views.Home
{
    using SimpleMVC.Interfaces.Generic;
    using Tools;
    using ViewModels;

    public class Register : IRenderable<LoginRegisterUserErrorMessageViewModel>
    {
        #region Properties
        public LoginRegisterUserErrorMessageViewModel Model { get; set; }
        #endregion

        #region Methods
        public string Render()
        {
            string page = FileRead.HtmlDocument("../../Content/register.html");

            if (Model.Message == null)
            {
                page = page.Replace("##Message##", "");
            }
            else
            {
                page = page.Replace("##Message##", $"<div class=\"thumbnail\"><p class=\"text-danger\">{Model.Message}</p></div>");
            }

            return page;
        }
        #endregion
    }
}