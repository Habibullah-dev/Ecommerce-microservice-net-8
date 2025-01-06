using Catalog.Core.Entities;

namespace Catalog.Core.Repositories.Interfaces;

public interface IBrandRepository 
{
    Task<IEnumerable<ProductBrand>> GetAllBrands();

}
