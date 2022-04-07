using Microsoft.AspNetCore.Mvc;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;

namespace EditCellTemplateRemoteOperations.Controllers;

public class HomeController : Controller
{
    private readonly DataService _data;

    public HomeController(DataService data) => _data = data;

    [HttpGet]
    public IActionResult Index() => View();

    [HttpGet, ActionName("data")]
    public LoadResult Data(DataSourceLoadOptionsBase options)
    {
        return DataSourceLoader.Load(_data.GetData(), options);
    }
}