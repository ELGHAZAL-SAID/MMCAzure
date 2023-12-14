using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using MMC.Domain.Entities;

namespace MMC.Infrastructure.Data;

public partial class DBC : DbContext
{
    public DBC()
    {
    }

    public DBC(DbContextOptions<DBC> options)
        : base(options)
    {
    }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<EventSpeaker> EventSpeakers { get; set; }

    public virtual DbSet<Participant> Participants { get; set; }

    public virtual DbSet<Partner> Partners { get; set; }

    public virtual DbSet<PresentationSupport> PresentationSupports { get; set; }

    public virtual DbSet<Session> Sessions { get; set; }

    public virtual DbSet<Speaker> Speakers { get; set; }

    public virtual DbSet<Sponsor> Sponsors { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=tcp:moroccomicro.database.windows.net;Initial Catalog=mmcdev;Persist Security Info=True;User ID=adminsa;Password=Erp12q@2ss");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Admins__3214EC27539061DC");

            entity.HasIndex(e => e.UserId, "UQ__Admins__1788CCADDC705800").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedByAdminId).HasColumnName("CreatedByAdminID");
            entity.Property(e => e.FirstName).HasMaxLength(100);
            entity.Property(e => e.Gender).HasMaxLength(20);
            entity.Property(e => e.LastName).HasMaxLength(100);
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.CreatedByAdmin).WithMany(p => p.InverseCreatedByAdmin)
                .HasForeignKey(d => d.CreatedByAdminId)
                .HasConstraintName("FK__Admins__CreatedB__656C112C");

            entity.HasOne(d => d.User).WithOne(p => p.Admin)
                .HasForeignKey<Admin>(d => d.UserId)
                .HasConstraintName("FK__Admins__UserID__6477ECF3");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Categori__3214EC27B32915DB");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CategoryName).HasMaxLength(100);
            entity.Property(e => e.SubCategoryId).HasColumnName("SubCategoryID");

            entity.HasOne(d => d.SubCategory).WithMany(p => p.InverseSubCategory)
                .HasForeignKey(d => d.SubCategoryId)
                .HasConstraintName("FK__Categorie__SubCa__72C60C4A");
        });

        modelBuilder.Entity<City>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Cities__3214EC27F6AF226E");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CityName).HasMaxLength(100);
            entity.Property(e => e.CountryId).HasColumnName("CountryID");

            entity.HasOne(d => d.Country).WithMany(p => p.Cities)
                .HasForeignKey(d => d.CountryId)
                .HasConstraintName("FK__Cities__CountryI__6FE99F9F");
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Countrie__3214EC2737539B24");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CountyName).HasMaxLength(100);
        });

        modelBuilder.Entity<Event>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Events__3214EC27CC3A387D");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CityId).HasColumnName("CityID");
            entity.Property(e => e.CreatedByAdminId).HasColumnName("CreatedByAdminID");
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.EventType).HasMaxLength(20);
            entity.Property(e => e.Image).HasMaxLength(255);
            entity.Property(e => e.IsAvailable).HasDefaultValueSql("((1))");
            entity.Property(e => e.IsBlocked).HasDefaultValueSql("((0))");
            entity.Property(e => e.Location).HasMaxLength(255);
            entity.Property(e => e.SubTitle).HasMaxLength(255);
            entity.Property(e => e.Title).HasMaxLength(255);
            entity.Property(e => e.Url).HasMaxLength(255);

            entity.HasOne(d => d.City).WithMany(p => p.Events)
                .HasForeignKey(d => d.CityId)
                .HasConstraintName("FK__Events__CityID__787EE5A0");

            entity.HasOne(d => d.CreatedByAdmin).WithMany(p => p.Events)
                .HasForeignKey(d => d.CreatedByAdminId)
                .HasConstraintName("FK__Events__CreatedB__797309D9");

            entity.HasMany(d => d.Categories).WithMany(p => p.Events)
                .UsingEntity<Dictionary<string, object>>(
                    "EventCategory",
                    r => r.HasOne<Category>().WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__EventCate__Categ__1F98B2C1"),
                    l => l.HasOne<Event>().WithMany()
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__EventCate__Event__1EA48E88"),
                    j =>
                    {
                        j.HasKey("EventId", "CategoryId").HasName("PK__EventCat__D8D45BD283C5B26E");
                        j.ToTable("EventCategories");
                        j.IndexerProperty<int>("EventId").HasColumnName("EventID");
                        j.IndexerProperty<int>("CategoryId").HasColumnName("CategoryID");
                    });

            entity.HasMany(d => d.Participants).WithMany(p => p.Events)
                .UsingEntity<Dictionary<string, object>>(
                    "EventParticipant",
                    r => r.HasOne<Participant>().WithMany()
                        .HasForeignKey("ParticipantId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__EventPart__Parti__10566F31"),
                    l => l.HasOne<Event>().WithMany()
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__EventPart__Event__0F624AF8"),
                    j =>
                    {
                        j.HasKey("EventId", "ParticipantId").HasName("PK__EventPar__8E66B1E7A88EA794");
                        j.ToTable("EventParticipants");
                        j.IndexerProperty<int>("EventId").HasColumnName("EventID");
                        j.IndexerProperty<int>("ParticipantId").HasColumnName("ParticipantID");
                    });

            entity.HasMany(d => d.Partners).WithMany(p => p.Events)
                .UsingEntity<Dictionary<string, object>>(
                    "EventPartner",
                    r => r.HasOne<Partner>().WithMany()
                        .HasForeignKey("PartnerId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__EventPart__Partn__17F790F9"),
                    l => l.HasOne<Event>().WithMany()
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__EventPart__Event__17036CC0"),
                    j =>
                    {
                        j.HasKey("EventId", "PartnerId").HasName("PK__EventPar__4ADB1E43FBC86527");
                        j.ToTable("EventPartners");
                        j.IndexerProperty<int>("EventId").HasColumnName("EventID");
                        j.IndexerProperty<int>("PartnerId").HasColumnName("PartnerID");
                    });

            entity.HasMany(d => d.Sponsors).WithMany(p => p.Events)
                .UsingEntity<Dictionary<string, object>>(
                    "EventSponsor",
                    r => r.HasOne<Sponsor>().WithMany()
                        .HasForeignKey("SponsorId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__EventSpon__Spons__1BC821DD"),
                    l => l.HasOne<Event>().WithMany()
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__EventSpon__Event__1AD3FDA4"),
                    j =>
                    {
                        j.HasKey("EventId", "SponsorId").HasName("PK__EventSpo__3AF2C19FC11EA781");
                        j.ToTable("EventSponsors");
                        j.IndexerProperty<int>("EventId").HasColumnName("EventID");
                        j.IndexerProperty<int>("SponsorId").HasColumnName("SponsorID");
                    });
        });

        modelBuilder.Entity<EventSpeaker>(entity =>
        {
            entity.HasKey(e => new { e.EventId, e.SpeakerId }).HasName("PK__EventSpe__FEDABD0374A79222");

            entity.HasIndex(e => new { e.SpeakerId, e.EventTimeSlot }, "UQ__EventSpe__8B42FE0AA30FB1F6").IsUnique();

            entity.Property(e => e.EventId).HasColumnName("EventID");
            entity.Property(e => e.SpeakerId).HasColumnName("SpeakerID");
            entity.Property(e => e.ParticipationDate).HasColumnType("datetime");

            entity.HasOne(d => d.Event).WithMany(p => p.EventSpeakers)
                .HasForeignKey(d => d.EventId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__EventSpea__Event__07C12930");

            entity.HasOne(d => d.Speaker).WithMany(p => p.EventSpeakers)
                .HasForeignKey(d => d.SpeakerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__EventSpea__Speak__08B54D69");
        });

        modelBuilder.Entity<Participant>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Particip__3214EC273F66BAF7");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CityId).HasColumnName("CityID");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.Gender).HasMaxLength(20);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.PhoneNumber).HasMaxLength(20);

            entity.HasOne(d => d.City).WithMany(p => p.Participants)
                .HasForeignKey(d => d.CityId)
                .HasConstraintName("FK__Participa__CityI__0C85DE4D");
        });

        modelBuilder.Entity<Partner>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Partners__3214EC270AA3E616");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.LogoUrl)
                .HasMaxLength(255)
                .HasColumnName("LogoURL");
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<PresentationSupport>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Presenta__3214EC27FA3DE32D");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.EventId).HasColumnName("EventID");
            entity.Property(e => e.SupportType).HasMaxLength(100);
            entity.Property(e => e.SupportUrl)
                .HasMaxLength(255)
                .HasColumnName("SupportURL");

            entity.HasOne(d => d.Event).WithMany(p => p.PresentationSupports)
                .HasForeignKey(d => d.EventId)
                .HasConstraintName("FK__Presentat__Event__03F0984C");
        });

        modelBuilder.Entity<Session>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Sessions__3214EC2718610AA7");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.EventId).HasColumnName("EventID");
            entity.Property(e => e.Title).HasMaxLength(255);

            entity.HasOne(d => d.Category).WithMany(p => p.Sessions)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK__Sessions__Catego__7D439ABD");

            entity.HasOne(d => d.Event).WithMany(p => p.Sessions)
                .HasForeignKey(d => d.EventId)
                .HasConstraintName("FK__Sessions__EventI__7C4F7684");

            entity.HasMany(d => d.Speakers).WithMany(p => p.Sessions)
                .UsingEntity<Dictionary<string, object>>(
                    "SessionSpeaker",
                    r => r.HasOne<Speaker>().WithMany()
                        .HasForeignKey("SpeakerId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__SessionSp__Speak__01142BA1"),
                    l => l.HasOne<Session>().WithMany()
                        .HasForeignKey("SessionId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__SessionSp__Sessi__00200768"),
                    j =>
                    {
                        j.HasKey("SessionId", "SpeakerId").HasName("PK__SessionS__4E6AE7030B80DE86");
                        j.ToTable("SessionSpeakers");
                        j.IndexerProperty<int>("SessionId").HasColumnName("SessionID");
                        j.IndexerProperty<int>("SpeakerId").HasColumnName("SpeakerID");
                    });
        });

        modelBuilder.Entity<Speaker>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Speakers__3214EC27690A9A0B");

            entity.HasIndex(e => e.UserId, "UQ__Speakers__1788CCADA5919D9E").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Bio)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.CreatedByAdminId).HasColumnName("CreatedByAdminID");
            entity.Property(e => e.Expertise).HasMaxLength(255);
            entity.Property(e => e.FirstName).HasMaxLength(100);
            entity.Property(e => e.Gender).HasMaxLength(20);
            entity.Property(e => e.LastName).HasMaxLength(100);
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.CreatedByAdmin).WithMany(p => p.Speakers)
                .HasForeignKey(d => d.CreatedByAdminId)
                .HasConstraintName("FK__Speakers__Create__6B24EA82");

            entity.HasOne(d => d.User).WithOne(p => p.Speaker)
                .HasForeignKey<Speaker>(d => d.UserId)
                .HasConstraintName("FK__Speakers__UserID__6A30C649");
        });

        modelBuilder.Entity<Sponsor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Sponsors__3214EC27A1764544");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.LogoUrl)
                .HasMaxLength(255)
                .HasColumnName("LogoURL");
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC27DE065C5D");

            entity.HasIndex(e => e.Username, "UQ__Users__536C85E4B5540E8F").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Email)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.EmailConfirmationToken).HasMaxLength(255);
            entity.Property(e => e.IsBlocked).HasDefaultValueSql("((0))");
            entity.Property(e => e.IsEmailConfirmed).HasDefaultValueSql("((0))");
            entity.Property(e => e.PasswordHash).HasMaxLength(255);
            entity.Property(e => e.UserType).HasMaxLength(20);
            entity.Property(e => e.Username).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
