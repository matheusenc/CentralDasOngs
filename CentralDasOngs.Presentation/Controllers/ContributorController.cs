using CentralDasOngs.Application.UseCase.Contributor.Register;
using CentralDasOngs.Communication.Requests;
using Microsoft.AspNetCore.Mvc;

namespace CentralDasOngs.Presentation.Controllers;

public class ContributorController : Controller
{

    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(RequestLoginModel model)
    {
        return RedirectToAction("Index", "Home");
    }
    
    public IActionResult Register()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> Register([FromServices] IRegisterContributorUseCase _useCase,
        RequestRegisterContributorModel model)
    {
        var validationErrors = await _useCase.Execute(model);

        if (validationErrors.Count != 0)
        {
            ViewBag.ErrorList = validationErrors;
            return View(model);
        }

        return RedirectToAction("Login");
    }
}