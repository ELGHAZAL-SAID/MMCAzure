using AutoMapper;

using MMC.Application.DTOs.SupportDTOs;

using MMC.Application.Interfaces;
using MMC.Domain.Entities;
using MMC.Domain.IRepositories;
using System;

namespace MMC.Application.Services;

public class SupportService : ISupportService
{
    private readonly ISupportRepository _supportRepository;
    private readonly IMapper _mapper;

    public SupportService(ISupportRepository supportRepository, IMapper mapper)
    {
        _supportRepository = supportRepository;
        _mapper = mapper;
    }

    public async Task<List<SupportDTO>> FindAllAsync()
    {
        var presentationSupports = await _supportRepository.GetAllAsync();
        return _mapper.Map<List<SupportDTO>>(presentationSupports);
    }

    public async Task<SupportDTO> FindByIdAsync(int id)
    {
        var presentationSupport = await _supportRepository.GetAsync(id);
        return _mapper.Map<SupportDTO>(presentationSupport);
    }

    public async Task<SupportDTO> CreateAsync(AddSupportDTO entity)
    {
        var presentationSupport = _mapper.Map<PresentationSupport>(entity);
        var newPresentationSupport = await _supportRepository.PostAsync(presentationSupport);
        return _mapper.Map<SupportDTO>(newPresentationSupport);
    }

    public async Task<SupportDTO> UpdateAsync(int id, UpdateSupportDTO entity)
    {
        var presentationSupport = _mapper.Map<PresentationSupport>(entity);
        var updatedPresentationSupport = await _supportRepository.PutAsync(id, presentationSupport);
        return _mapper.Map<SupportDTO>(updatedPresentationSupport);
    }

    public async Task DeleteAsync(int id)
    {
        var existingPartner = await _supportRepository.GetAsync(id);
        if (existingPartner == null)
        {
            return;
        }

        await _supportRepository.DeleteAsync(id);
    }

}

