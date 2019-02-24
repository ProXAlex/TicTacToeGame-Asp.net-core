using Microsoft.AspNetCore.Mvc;

namespace TicTacToeGame.Components
{
    public class MenuViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }

    }
}