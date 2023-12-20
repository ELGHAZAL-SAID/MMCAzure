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

        public async Task<supportDTO> FindByIdAsync(int id)
        {
            var partner = await _partnerRepository.GetAsync(id);
            return _mapper.Map<supportDTO>(partner);
        }

        public async Task<List<supportDTO>> FindAllAsync()
        {
            var partners = await _partnerRepository.GetAllAsync();
            return _mapper.Map<List<supportDTO>>(partners);
        }

        public async Task<supportDTO> CreateAsync(AddPartnerDTO entity)
        {
            var partner = _mapper.Map<Partner>(entity);
            var createdPartner = await _partnerRepository.PostAsync(partner);
            return _mapper.Map<supportDTO>(createdPartner);
        }

        public async Task<supportDTO> UpdateAsync(int id, UpdatePartnerDTO entity)
        {
            var existingPartner = await _partnerRepository.GetAsync(id);
            if (existingPartner == null)
            {
                return null;
            }

            _mapper.Map(entity, existingPartner);
            await _partnerRepository.PutAsync(id, existingPartner);
            return _mapper.Map<supportDTO>(existingPartner);
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
