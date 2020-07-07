using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebChat.Domain.Entities;

namespace WebChat.Infra.Data.Maps
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            //
            builder.ToTable("User");
            //


            //
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .UseIdentityColumn();
            //

            //
            builder.HasIndex(x => x.Hash)
                .IsUnique();

            builder.Property(x => x.Hash)
                .IsRequired()
                .HasMaxLength(5)
                .HasColumnType("varchar(5)");
            //


            //
            builder.HasIndex(x => x.Email)
                .IsUnique();

            builder.Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(180)
                .HasColumnType("varchar(180)");
            //


            //
            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(40)
                .HasColumnType("varchar(40)");
            //


            //
            builder.Property(x => x.Password)
                .IsRequired()
                .HasMaxLength(12)
                .HasColumnType("varchar(12)");
            //
        }
    }
}
