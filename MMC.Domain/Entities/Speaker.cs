using System;
using System.Collections.Generic;

namespace MMC.Domain.Entities;
public partial class Speaker
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? Bio { get; set; }

    public string? Expertise { get; set; }

    public string Gender { get; set; } = null!;

    public int? UserId { get; set; }

    public int? CreatedByAdminId { get; set; }

    public virtual Admin? CreatedByAdmin { get; set; }

    public virtual ICollection<EventSpeaker> EventSpeakers { get; set; } = new List<EventSpeaker>();

    public virtual User? User { get; set; }

    public virtual ICollection<Session> Sessions { get; set; } = new List<Session>();
}
