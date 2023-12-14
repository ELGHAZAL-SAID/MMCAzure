using System;
using System.Collections.Generic;

namespace MMC.Domain.Entities;
public partial class Country
{
    public int Id { get; set; }

    public string CountyName { get; set; } = null!;

    public virtual ICollection<City> Cities { get; set; } = new List<City>();
}
