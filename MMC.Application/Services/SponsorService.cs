using AutoMapper;
using MMC.Application.DTOs.SponsorDTOs;
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
    public class SponsorService : ISponsorService
    {
        private readonly ISponsorRepository _sponsorRepository;
        private readonly IMapper _mapper;

        public SponsorService(ISponsorRepository sponsorRepository, IMapper mapper)
        {
            _sponsorRepository = sponsorRepository;
            _mapper = mapper;
        }

        public async Task<SponsorDTO> FindByIdAsync(int id)
        {
            var sponsor = await _sponsorRepository.GetAsync(id);
            return _mapper.Map<SponsorDTO>(sponsor);
        }

        public async Task<List<SponsorDTO>> FindAllAsync()
        {
            var sponsors = await _sponsorRepository.GetAllAsync();
            return _mapper.Map<List<SponsorDTO>>(sponsors);
        }

        public async Task<SponsorDTO> CreateAsync(AddSponsorDTO entity)
        {
            var sponsor = _mapper.Map<Sponsor>(entity);
            var createdSponsor = await _sponsorRepository.PostAsync(sponsor);
            return _mapper.Map<SponsorDTO>(createdSponsor);
        }

        public async Task<SponsorDTO> UpdateAsync(int id, UpdateSponsorDTO entity)
        {
            var existingSponsor = await _sponsorRepository.GetAsync(id);
            if (existingSponsor == null)
            {
                return null;
            }

            _mapper.Map(entity, existingSponsor);
            await _sponsorRepository.PutAsync(id, existingSponsor);
            return _mapper.Map<SponsorDTO>(existingSponsor);
        }

        public async Task DeleteAsync(int id)
        {
            var existingSponsor = await _sponsorRepository.GetAsync(id);
            if (existingSponsor == null)
            {
                return;
            }

            await _sponsorRepository.DeleteAsync(id);
        }
    }
}
