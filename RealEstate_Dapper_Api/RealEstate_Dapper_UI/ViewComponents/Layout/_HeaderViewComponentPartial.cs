using Microsoft.AspNetCore.Mvc;

namespace RealEstate_Dapper_UI.ViewComponents.Layout
{
    public class _HeaderViewComponentPartial : ViewComponent //ViewComponent'ler partial view görevi görür
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }

    }
}
