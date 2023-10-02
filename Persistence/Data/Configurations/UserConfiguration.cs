using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations;
public class UserConfiguration : IEntityTypeConfiguration<User>{
    public void Configure(EntityTypeBuilder<User> builder){
        builder.ToTable("user");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .IsRequired()
            .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
            .HasColumnName("id");
        
        builder.Property(x => x.Username)
            .IsRequired()
            .HasColumnName("username")
            .HasMaxLength(50);
        
        builder.Property(x => x.Email)
            .IsRequired()
            .HasColumnName("email")
            .HasMaxLength(100);
        
        builder.Property(x => x.TwoFactorSecret)            
            .HasColumnName("twoFactorSecret")
            .HasMaxLength(50);
        
        builder.Property(x => x.CreatedDate)
            .IsRequired()
            .HasColumnName("createDate");
            
        builder.HasIndex(u => new{
            u.Username,u.Email
        })
        .HasDatabaseName("IX_Username_Email")
        .IsUnique();
        
                
    }
}
