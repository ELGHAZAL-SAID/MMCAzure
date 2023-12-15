using Microsoft.EntityFrameworkCore;
using MMC.Application.IRepositories;
using MMC.Infrastructure.Data;
using MMC.Domain.Entities;

namespace MMC.Infrastructure.Repositories;

public class SupportRepository : Repository<PresentationSupport>, ISupportRepository
{
    public SupportRepository(DBC db) : base(db)
    {
    }

    // Additional methods
}
