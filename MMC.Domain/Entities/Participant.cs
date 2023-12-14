using System;
using System.Collections.Generic;

namespace MMC.Domain.Entities;
public partial class Participant
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Gender { get; set; } = null!;

    public string? PhoneNumber { get; set; }

    public int? CityId { get; set; }

    public virtual City? City { get; set; }

    public virtual ICollection<Event> Events { get; set; } = new List<Event>();
}
