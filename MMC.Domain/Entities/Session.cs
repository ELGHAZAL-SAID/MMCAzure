using System;
using System.Collections.Generic;

namespace MMC.Domain.Entities;
public partial class Session
{
    public int Id { get; set; }

    public int? EventId { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime DateStart { get; set; }

    public DateTime DateEnd { get; set; }

    public int? CategoryId { get; set; }

    public virtual Category? Category { get; set; }

    public virtual Event? Event { get; set; }

    public virtual ICollection<Speaker> Speakers { get; set; } = new List<Speaker>();
}
