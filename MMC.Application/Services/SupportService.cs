using AutoMapper;
using MMC.Application.DTOs.SupportDTOs;
using MMC.Application.Interfaces;
using MMC.Domain.Entities;
using System;

public class SupportService : ISupportService
{
    private readonly ISupportService _context;
    private readonly IMapper _mapper;

    public SupportService(ISupportService context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<SupportDTO> FindByIdAsync(int id)
    {
        var entity = await _context.FindByIdAsync(id);
        return _mapper.Map<SupportDTO>(entity);
    }

    public async Task<List<SupportDTO>> FindAllAsync()
    {
        var entities = await _context.FindAllAsync();
        return _mapper.Map<List<SupportDTO>>(entities);
    }

    public async Task<SupportDTO> CreateAsync(AddSupportDTO entity)
    {
        var newEntity = _mapper.Map<PresentationSupport>(entity);
        await _context.CreateAsync(newEntity);
        return _mapper.Map<SupportDTO>(newEntity);
    }

    public async Task<SupportDTO> UpdateAsync(int id, UpdateSupportDTO entity)
    {
        var existingEntity = await _context.Supports.FindAsync(id);
        _mapper.Map(entity, existingEntity);
        _context.Entry(existingEntity).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return _mapper.Map<SupportDTO>(existingEntity);
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _context.Supports.FindAsync(id);
        if (entity != null)
        {
            _context.Supports.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
    
}
