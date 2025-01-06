using Catalog.Core.Entities;

namespace Catalog.Core.Repositories.Interfaces;

public interface ITypeRepository
{
    Task<IEnumerable<ProductType>> GetAllTypes();

}