using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MMC.Domain.Entities;

public partial class PresentationSupport
{
    public int Id { get; set; }
    public int? EventId { get; set; }

    public string SupportType { get; set; } = null!;

    public string? SupportUrl { get; set; }
}
