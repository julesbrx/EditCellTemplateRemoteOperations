using Microsoft.AspNetCore.Mvc;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.Helpers;
using DevExtreme.AspNet.Data.ResponseModel;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace EditCellTemplateRemoteOperations.Controllers;

[ModelBinder(BinderType = typeof(DataSourceLoadOptionsBinder))]
public class DataSourceLoadOptions : DataSourceLoadOptionsBase { }

public class DataSourceLoadOptionsBinder : IModelBinder
{
    public Task BindModelAsync(ModelBindingContext ctx)
    {
        var options = new DataSourceLoadOptions();
        
        DataSourceLoadOptionsParser.Parse(options, key => ctx.ValueProvider.GetValue(key).FirstOrDefault());
        ctx.Result = ModelBindingResult.Success(options);
        
        return Task.CompletedTask;
    }
}

public class HomeController : Controller
{
    private readonly DataService _data;

    public HomeController(DataService data) => _data = data;

    [HttpGet]
    public IActionResult Index() => View();

    [HttpGet, ActionName("data")]
    public LoadResult Data(DataSourceLoadOptions options) => DataSourceLoader.Load(_data.GetData(), options);
}