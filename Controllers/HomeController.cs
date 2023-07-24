using Microsoft.AspNetCore.Mvc;
using Mortiz.DAL.Interfaces;
using System.Diagnostics;

namespace Mortiz.Controllers
{
    public class HomeController : Controller
    {
     private readonly IClothesRepository _clothesRepository;

        public HomeController(IClothesRepository clothesRepository)
        {
            _clothesRepository = clothesRepository;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var result = await _clothesRepository.SelectAll();
            return View(result);
        }

    
    }
}