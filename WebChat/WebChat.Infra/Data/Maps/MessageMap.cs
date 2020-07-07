using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebChat.Domain.Entities;

namespace WebChat.Infra.Data.Maps
{
    public class MessageMap : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder.ToTable("Message");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .UseIdentityColumn();

            builder.Property(x => x.FkIdSender)
                .IsRequired()
                .HasColumnType("int");

            builder.Property(x => x.FkIdReceiver)
                .IsRequired()
                .HasColumnType("int");

            builder.Property(x => x.Text)
                .IsRequired()
                .HasMaxLength(2147483647)
                .HasColumnType("varchar(MAX)");

            builder.Property(x => x.SendDate)
                .IsRequired()
                .HasColumnType("datetime");
        }
    }
}
