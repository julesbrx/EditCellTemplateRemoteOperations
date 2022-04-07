using Microsoft.AspNetCore.Mvc;

namespace EditCellTemplateRemoteOperations.Controllers;

public class HomeController : Controller
{
    private readonly DataService _data;

    public HomeController(DataService data) => _data = data;

    [HttpGet]
    public IActionResult Index() => View();

    [HttpGet, ActionName("data")]
    public List<ProductDto> Data() => _data.GetData();
}