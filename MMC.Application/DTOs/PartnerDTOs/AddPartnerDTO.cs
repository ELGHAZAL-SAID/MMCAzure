using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMC.Application.DTOs.PartnerDTOs;

public class AddPartnerDTO
{
    public string Name { get; set; } = null!;

    public string? LogoUrl { get; set; }
}
