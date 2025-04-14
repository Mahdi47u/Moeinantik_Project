using ShopManagement.Application.Contracts.ProductCategory;
using System.Linq.Expressions;

namespace ShopManagement.Domain.ProductCategoryAgg 
{

    public interface IProductCategoryRepository
    {
        void Create(ProductCategory entity);
        public ProductCategory GetById(long id);
        List<ProductCategory> GetAll();


        /// <summary>
        /// for the param Expression and ... it is for multiple ways to check the database for the match data 
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        bool isExist(Expression<Func<ProductCategory ,bool >> expression);

        void SaveChanges();

        List<ProductCategoryViewModel> Search(ProductCategorySearchModel searchModel);
        EditProductCategory GetDetails(long id);
    }
}

