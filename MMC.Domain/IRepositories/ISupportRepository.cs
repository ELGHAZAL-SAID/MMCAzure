using MMC.Domain.Entities;

namespace MMC.Domain.IRepositories;

public interface ISupportRepository : IRepository<PresentationSupport>
{
    Task FindByIdAsync(int id);

    // Additional methods
    Task GetSupportListAsync(int id);
}