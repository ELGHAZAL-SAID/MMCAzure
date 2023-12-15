using Microsoft.EntityFrameworkCore;
using MMC.Application.IRepositories;
using MMC.Domain.Entities;
using MMC.Infrastructure.Data;

namespace MMC.Infrastructure.Repositories;

public class PartnerRepository : Repository<Partner>, IPartnerRepository
{
    public PartnerRepository(DBC db) : base(db)
    {
    }

    // Additional methods
}
