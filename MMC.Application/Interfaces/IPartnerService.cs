using MMC.Application.DTOs.PartnerDTOs;
using MMC.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMC.Application.Interfaces
{
    public interface IPartnerService
    {
        Task<PartnerDTO> FindByIdAsync(int id);
        Task<List<PartnerDTO>> FindAllAsync();
        Task<PartnerDTO> CreateAsync(AddPartnerDTO entity);
        Task<PartnerDTO> UpdateAsync(int id, UpdatePartnerDTO entity);
        Task DeleteAsync(int id);
    }
}
