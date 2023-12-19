using Microsoft.EntityFrameworkCore;
using MMC.Domain.IRepositories;
using MMC.Domain.Entities;
using MMC.Infrastructure.Data;

namespace MMC.Infrastructure.Repositories;

public class SponsorRepository : Repository<Sponsor>, ISponsorRepository
{
    public SponsorRepository(DBC db) : base(db) { }

    // Additional methods
}
