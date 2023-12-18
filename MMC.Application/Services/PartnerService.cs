using AutoMapper;
using MMC.Application.DTOs.PartnerDTOs;
using MMC.Application.Interfaces;
using MMC.Domain.Entities;
using MMC.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMC.Application.Services
{
    public class PartnerService : IPartnerService
    {
        private readonly IPartnerRepository _partnerRepository;
        private readonly IMapper _mapper;

        public PartnerService(IPartnerRepository partnerRepository, IMapper mapper)
        {
            _partnerRepository = partnerRepository;
            _mapper = mapper;
        }

        public async Task<PartnerDTO> FindByIdAsync(int id)
        {
            var partner = await _partnerRepository.GetAsync(id);
            return _mapper.Map<PartnerDTO>(partner);
        }

        public async Task<List<PartnerDTO>> FindAllAsync()
        {
            var partners = await _partnerRepository.GetAllAsync();
            return _mapper.Map<List<PartnerDTO>>(partners);
        }

        public async Task<PartnerDTO> CreateAsync(AddPartnerDTO entity)
        {
            var partner = _mapper.Map<Partner>(entity);
            var createdPartner = await _partnerRepository.PostAsync(partner);
            return _mapper.Map<PartnerDTO>(createdPartner);
        }

        public async Task<PartnerDTO> UpdateAsync(int id, UpdatePartnerDTO entity)
        {
            var existingPartner = await _partnerRepository.GetAsync(id);
            if (existingPartner == null)
            {
                return null;
            }

            _mapper.Map(entity, existingPartner);
            await _partnerRepository.PutAsync(id, existingPartner);
            return _mapper.Map<PartnerDTO>(existingPartner);
        }

        public async Task DeleteAsync(int id)
        {
            var existingPartner = await _partnerRepository.GetAsync(id);
            if (existingPartner == null)
            {
                return;
            }

            await _partnerRepository.DeleteAsync(id);
        }
    }
}
