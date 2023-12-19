using System;
using System.Collections.Generic;

namespace MMC.Domain.Entities;

public partial class Sponsor
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? LogoUrl { get; set; }
}
