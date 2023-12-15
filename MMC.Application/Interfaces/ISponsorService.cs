using MMC.Application.DTOs.PartnerDTOs;
using MMC.Application.DTOs.SponsorDTOs;
using MMC.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMC.Application.Interfaces;

public interface ISponsorService
{
    Task<SponsorDTO> FindByIdAsync(int id);
    Task<List<SponsorDTO>> FindAllAsync();
    Task<SponsorDTO> CreateAsync(AddSponsorDTO entity);
    Task<SponsorDTO> UpdateAsync(int id, UpdateSponsorDTO entity);
    Task DeleteAsync(int id);
}
