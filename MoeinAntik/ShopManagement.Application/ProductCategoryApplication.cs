using _0_Framework.Application;
using ShopManagement.Application.Contracts.ProductCategory;
using ShopManagement.Domain.ProductCategoryAgg;
using System.Net.NetworkInformation;

namespace ShopManagement.Application
{
    public class ProductCategoryApplication : IProductCategoryApplication
    {
        private readonly IProductCategoryRepository _ProductCategoryRepository;

        public ProductCategoryApplication(IProductCategoryRepository productCategoryRepository) 
        { 
            _ProductCategoryRepository = productCategoryRepository;
        }
        public OperationResult Create(CreateProductCategory command)
        {
            var operation = new OperationResult();
            if (_ProductCategoryRepository.Exists(x=>x.Name == command.Name))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            var slug = command.Slug.GenerateSlug();
            var productCategory = new ProductCategory(command.Name, command.Description, command.Picture, command.PictureAlt,
                command.PictureTitle, command.Keywords,
                command.MetaDescription, slug);
            _ProductCategoryRepository.Create(productCategory);
            _ProductCategoryRepository.SaveChanges();
            return operation.Succeded();
        }


        public OperationResult Edit(EditProductCategory command)
        {
            var opertion = new OperationResult();
            var productCategory = _ProductCategoryRepository.Get(command.Id);
            if (productCategory == null)            
            {
                return opertion.Failed(ApplicationMessages.RecordNotFound);
            }
            if (_ProductCategoryRepository.Exists(x => x.Name == command.Name && x.Id != command.Id)) {
                return opertion.Failed(ApplicationMessages.DuplicatedRecord);


                }
            
            var slug = command.Slug.GenerateSlug();
            productCategory.Edit(command.Name, command.Description, command.Picture,
                command.PictureAlt, command.PictureTitle, command.Keywords,
                command.MetaDescription, command.Slug);
            _ProductCategoryRepository.SaveChanges();
            return opertion.Succeded();
        }

        public EditProductCategory GetDetails(long id)
        {
            return _ProductCategoryRepository.GetDetails(id);
        }

        public List<ProductCategoryViewModel> Search(ProductCategorySearchModel SearchModel)
        {
            return _ProductCategoryRepository.Search(SearchModel);
        }
    }
}
