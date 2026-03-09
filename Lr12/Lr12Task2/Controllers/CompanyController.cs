using Lr12Task2.Data;
using Microsoft.AspNetCore.Mvc;

namespace Lr12Task2.Controllers;

public class CompanyController : Controller
{
    private readonly CompanyContext _context;

    public CompanyController(CompanyContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var companies = _context.Companies.ToList();
        return View(companies);
    }
}

