using System;
using System.Collections.Generic;

namespace MMC.Domain.Entities;
public partial class Event
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;
     
    public string? SubTitle { get; set; }

    public string? Image { get; set; }

    public string? Description { get; set; }

    public string EventType { get; set; } = null!;

    public DateTime DateStart { get; set; }

    public DateTime DateEnd { get; set; }

    public int? IsBlocked { get; set; }

    public int? IsAvailable { get; set; }

    public string? Location { get; set; }

    public string? Url { get; set; }

    public int? CityId { get; set; }

    public int? CreatedByAdminId { get; set; }

    public virtual City? City { get; set; }

    public virtual Admin? CreatedByAdmin { get; set; }

    public virtual ICollection<EventSpeaker> EventSpeakers { get; set; } = new List<EventSpeaker>();

    public virtual ICollection<PresentationSupport> PresentationSupports { get; set; } = new List<PresentationSupport>();

    public virtual ICollection<Session> Sessions { get; set; } = new List<Session>();

    public virtual ICollection<Category> Categories { get; set; } = new List<Category>();

    public virtual ICollection<Participant> Participants { get; set; } = new List<Participant>();

    public virtual ICollection<Partner> Partners { get; set; } = new List<Partner>();

    public virtual ICollection<Sponsor> Sponsors { get; set; } = new List<Sponsor>();
}
