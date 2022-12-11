using CookBook.Models;
using Duende.IdentityServer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CookBook.Controllers;

[AllowAnonymous]
public class HomeController : Controller
{
    private readonly IWebHostEnvironment _environment;
    private readonly IIdentityServerInteractionService _interaction;
    private readonly ILogger<HomeController> _logger;

    public HomeController(IWebHostEnvironment environment, ILogger<HomeController> logger,
        IIdentityServerInteractionService interaction)
    {
        _environment = environment;
        _logger = logger;
        _interaction = interaction;
    }

    public async Task<IActionResult> Index(string errorId)
    {
        if (_environment.IsDevelopment())
        {
            var vm = new ErrorViewModel();

            // retrieve error details from identityserver
            var message = await _interaction.GetErrorContextAsync(errorId);
            if (message != null) vm.Error = message;
            ViewBag.VM = vm;
            return View(vm);
        }

        _logger.LogInformation("Homepage is disabled in production. Returning 404.");
        return NotFound();
    }
}