using System.Collections.Generic;
using _0_Framework.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Application.Contracts.ProductCategory;

namespace ServiceHost.Areas.Administration.Pages.Shop.Products;

public class IndexModel : PageModel
{
    private readonly IProductApplication _productApplication;
    private readonly IProductCategoryApplication _productCategoryApplication;
    public List<ProductViewModel> Products;
    public ProductSearchModel SearchModel;
    public SelectList ProductCategories;
    public IndexModel(IProductApplication productApplication, 
        IProductCategoryApplication productCategoryApplication)
    {
        _productApplication = productApplication;
        _productCategoryApplication = productCategoryApplication;
    }

    public void OnGet(ProductSearchModel searchModel)
    {
        ProductCategories = new SelectList(_productCategoryApplication.GetProductCategories(), "Id", "Name");
        Products = _productApplication.Search(searchModel);
    }

    public IActionResult OnGetCreate()
    {
        return Partial("./Create", new CreateProduct());
    }

    public JsonResult OnPostCreate(CreateProduct command)
    {
        var result = _productApplication.Create(command);
        return new JsonResult(result);
    }

    public IActionResult OnGetEdit(long id)
    {
        var productCategory = _productApplication.GetDetails(id);
        return Partial("Edit", productCategory);
    }

    
    public JsonResult OnPostEdit(EditProduct command)
    {
        var result = _productApplication.Edit(command);
        return new JsonResult(result);
    }
}