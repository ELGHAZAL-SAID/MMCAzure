using System;
using System.Collections.Generic;

namespace MMC.Domain.Entities;
public partial class EventSpeaker
{
    public int EventId { get; set; }

    public int SpeakerId { get; set; }

    public DateTime ParticipationDate { get; set; }

    public DateTime? EventTimeSlot { get; set; }

    public virtual Event Event { get; set; } = null!;

    public virtual Speaker Speaker { get; set; } = null!;
}
