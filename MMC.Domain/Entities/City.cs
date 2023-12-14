using System;
using System.Collections.Generic;

namespace MMC.Domain.Entities;
public partial class City
{
    public int Id { get; set; }

    public string CityName { get; set; } = null!;

    public int? CountryId { get; set; }

    public virtual Country? Country { get; set; }

    public virtual ICollection<Event> Events { get; set; } = new List<Event>();

    public virtual ICollection<Participant> Participants { get; set; } = new List<Participant>();
}
