using System;
using System.Collections.Generic;

namespace MMC.Domain.Entities;

public partial class PresentationSupport
{
    public int Id { get; set; }

    public int? EventId { get; set; }

    public string SupportType { get; set; } = null!;

    public string? SupportUrl { get; set; }
}
