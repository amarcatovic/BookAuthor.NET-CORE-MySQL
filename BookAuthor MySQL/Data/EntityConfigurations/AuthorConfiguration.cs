using BookAuthor_MySQL.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAuthor_MySQL.Data.EntityConfigurations
{
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasKey(a => a.Id);
            builder.HasIndex(a => a.FirstName);
            builder.HasIndex(a => a.LastName);

            builder.Property(a => a.FirstName)
                .IsRequired();

            builder.Property(a => a.LastName)
                .IsRequired();

            builder.Property(a => a.DOB)
                .IsRequired();
        }
    }
}
