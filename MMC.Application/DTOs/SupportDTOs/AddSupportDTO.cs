using MMC.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMC.Application.DTOs.SupportDTOs;

public class AddSupportDTO
{
    public int? EventId { get; set; }

    public string SupportType { get; set; } = null!;

    public string? SupportUrl { get; set; }
}
