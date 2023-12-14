using System;
using System.Collections.Generic;

namespace MMC.Domain.Entities;

public partial class Category
{
    public int Id { get; set; }

    public string CategoryName { get; set; } = null!;

    public int? SubCategoryId { get; set; }

    public virtual ICollection<Category> InverseSubCategory { get; set; } = new List<Category>();

    public virtual ICollection<Session> Sessions { get; set; } = new List<Session>();

    public virtual Category? SubCategory { get; set; }

    public virtual ICollection<Event> Events { get; set; } = new List<Event>();
}
