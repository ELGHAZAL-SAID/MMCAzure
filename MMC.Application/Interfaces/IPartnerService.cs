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
        Task<supportDTO> FindByIdAsync(int id);
        Task<List<supportDTO>> FindAllAsync();
        Task<supportDTO> CreateAsync(AddPartnerDTO entity);
        Task<supportDTO> UpdateAsync(int id, UpdatePartnerDTO entity);
        Task DeleteAsync(int id);
    }
}
