using System;
using System.Collections.Generic;

namespace MMC.Domain.Entities;
public partial class User
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string Email { get; set; } = null!;

    public int? IsBlocked { get; set; }

    public int? IsEmailConfirmed { get; set; }

    public string? EmailConfirmationToken { get; set; }

    public string PasswordHash { get; set; } = null!;

    public string UserType { get; set; } = null!;

    public virtual Admin? Admin { get; set; }

    public virtual Speaker? Speaker { get; set; }
}
