using Menuu.Models;

namespace Menuu.Repositories.Interfaces

{
    public interface ICategoryRepository
    {
        IEnumerable<Category> Categories { get; }
    }
}
