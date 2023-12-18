using MMC.Application.DTOs.SponsorDTOs;
using MMC.Application.DTOs.SupportDTOs;
using MMC.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMC.Application.Interfaces;

public interface ISupportService
{
    Task<SupportDTO> FindByIdAsync(int id);
    Task<List<SupportDTO>> FindAllAsync();
    Task<SupportDTO> CreateAsync(AddSupportDTO entity);
    Task<SupportDTO> UpdateAsync(int id, UpdateSupportDTO entity);
    Task DeleteAsync(int id);


}
