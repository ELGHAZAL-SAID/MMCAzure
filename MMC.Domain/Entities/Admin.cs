namespace MMC.Domain.Entities;

public class Admin
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Gender { get; set; } = null!;

    public int? UserId { get; set; }

    public int? CreatedByAdminId { get; set; }

    public virtual Admin? CreatedByAdmin { get; set; }

    public virtual ICollection<Event> Events { get; set; } = new List<Event>();

    public virtual ICollection<Admin> InverseCreatedByAdmin { get; set; } = new List<Admin>();

    public virtual ICollection<Speaker> Speakers { get; set; } = new List<Speaker>();

    public virtual User? User { get; set; }
}
