using MMC.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMC.Application.DTOs.SupportDTOs;

public class SupportDTO
{
    public int Id { get; set; }

    public int? EventId { get; set; }

    public string SupportType { get; set; } = null!;

    public string? SupportUrl { get; set; }
}
